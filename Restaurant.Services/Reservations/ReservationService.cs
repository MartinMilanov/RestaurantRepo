using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;
using Restaurant.Data.Entities.Reservations;
using Restaurant.Services.Loggers;
using Restaurant.Mapping.Models.Reservations;
using Restaurant.Mapping.Models.Common;

namespace Restaurant.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggingService _loggingService;
        private readonly ReservationRepository _reservRepo;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper, ILoggingService loggingService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggingService = loggingService;
            _reservRepo = unitOfWork.Reservations;
        }

        public async Task Create(ReservationCreateDto input)
        {
            var entity = _mapper.Map<Reservation>(input);

            await ThrowIfReservationDoesntMeetCriteria(input.TableId, entity.Id, input.Date, input.PeopleCount);

            await _reservRepo.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnCreate("Reservations");
        }

        public async Task Delete(string id)
        {
            var entityToDelete = await _reservRepo.GetBy(x => x.Id == id);

            if (entityToDelete == null)
            {
                throw new Exception("Reservation does not exist");
            }

            _reservRepo.Delete(entityToDelete);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReservationListDto>> GetAll(ReservationPaginationDto filters)
        {
            var query = _reservRepo
                .GetAll()
                .Include(x => x.CreatedBy)
                .Include(x => x.Table)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.ReserveeName))
            {
                query = query.Where(x => x.ReserveeName.ToLower().Contains(filters.ReserveeName.ToLower()));
            }

            if (filters.Date != null)
            {
                query = query.Where(x => x.Date == filters.Date);
            }

            if (filters.OrderBy == "ReserveeName")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.ReserveeName);
                }
                else
                {
                    query = query.OrderByDescending(x => x.ReserveeName);
                }
            }

            if (filters.OrderBy == "PeopleCount")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.PeopleCount);
                }
                else
                {
                    query = query.OrderByDescending(x => x.PeopleCount);
                }
            }

            if (filters.OrderBy == "Date")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.Date);
                }
                else
                {
                    query = query.OrderByDescending(x => x.Date);
                }
            }

            if (filters.OrderBy == "CreatedBy")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.CreatedBy.UserName);
                }
                else
                {
                    query = query.OrderByDescending(x => x.CreatedBy.UserName);
                }
            }

            if (filters.OrderBy == "TableNumber")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.Table.TableNumber);
                }
                else
                {
                    query = query.OrderByDescending(x => x.Table.TableNumber);
                }
            }

            query = query.Skip(filters.Skip).Take(filters.Take);

            var result = query.Select(x => _mapper.Map<ReservationListDto>(x));

            return result.ToList();
        }

        public async Task<int> GetCount(ReservationPaginationDto filters)
        {
            var query = _reservRepo.GetAll();

            if (!string.IsNullOrWhiteSpace(filters.ReserveeName))
            {
                query = query.Where(x => x.ReserveeName.ToLower().Contains(filters.ReserveeName.ToLower()));
            }

            if (filters.Date != null)
            {
                query = query.Where(x => x.Date == filters.Date);
            }

            return query.ToList().Count;
        }

        public async Task<ReservationResultDto> GetById(string id)
        {
            var result = await _reservRepo.GetBy(x => x.Id == id);

            var createdBy = await _unitOfWork.Users.GetBy(x => x.Id == result.CreatedById);

            var table = await _unitOfWork.Tables.GetBy(x => x.Id == result.TableId);

            result.CreatedBy = createdBy;
            result.Table = table;

            if (result == null)
            {
                throw new Exception("Could not find reservation");
            }

            return _mapper.Map<ReservationResultDto>(result);
        }

        public async Task Update(string id, ReservationUpdateDto input)
        {
            await ThrowIfReservationDoesntMeetCriteria(input.TableId, id, input.Date, input.PeopleCount);

            Reservation reservation = await _reservRepo.GetBy(x => x.Id == id);

            if (reservation == null)
            {
                throw new Exception("Cannot find reservation with this id");
            }

            reservation.Date = input.Date;
            reservation.CreatedById = input.CreatedById;
            reservation.ReserveeName = input.ReserveeName;
            reservation.PeopleCount = input.PeopleCount;
            reservation.TableId = input.TableId;

            _reservRepo.Update(id, reservation);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnUpdate("Reservations");
        }

        private async Task ThrowIfReservationDoesntMeetCriteria(string tableId, string reservationId, DateTime timeOfReservation, int peopleCount)
        {
            var table = await _unitOfWork.Tables
                .GetAll(x => x.Id == tableId)
                .Include(x => x.Reservations)
                .FirstOrDefaultAsync();

            if (table == null)
            {
                throw new Exception("Table does not exist");
            }

            bool doesNotMeetTimeCriteria = table.Reservations.Any(x => 
                x.Id != reservationId
                && (
                    (x.Date.AddHours(4) >= timeOfReservation && x.Date <= timeOfReservation)
                    || (x.Date.AddHours(-4) <= timeOfReservation && x.Date >= timeOfReservation)
                    || x.Date == timeOfReservation
                   ));

            bool doesNotMeetPeopleCriteria = table.Seats < peopleCount;


            if (doesNotMeetTimeCriteria)
            {
                throw new Exception("This table has a reservation too close to the requested one");
            }

            if (doesNotMeetPeopleCriteria)
            {
                throw new Exception("This table has less seats than reservation people count");
            }
        }
    }
}
