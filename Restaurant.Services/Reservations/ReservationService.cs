using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;
using Restaurant.Data.Entities.Reservations;
using Restaurant.Services.Loggers;
using Restaurant.Mapping.Models.Reservations;

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

            await ThrowIfReservationDoesntMeetCriteria(input.TableId, entity.Id, input.Date);

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

        public async Task<IEnumerable<ReservationResultDto>> GetAll(ReservationPaginationDto filters)
        {
            var query = _reservRepo.GetAll().Include(x=>x.CreatedBy).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.ReserveeName))
            {
                query = query.Where(x => x.ReserveeName == filters.ReserveeName);
            }

            if (filters.Date != null)
            {
                query = query.Where(x => x.Date == filters.Date);
            }

            if (filters.OrderBy == "ReserveeName")
            {
                query = query.OrderBy(x => x.ReserveeName);
            }

            if (filters.OrderBy == "PeopleCount")
            {
                query = query.OrderBy(x => x.PeopleCount);
            }

            if (filters.OrderBy == "Date")
            {
                query = query.OrderBy(x => x.Date);
            }

            if (filters.OrderBy == "CreatedByName")
            {
                query = query.OrderBy(x => x.CreatedBy.UserName);
            }

            query = query.Skip(filters.Skip).Take(filters.Take);

            var result = query.Select(x => _mapper.Map<ReservationResultDto>(x));

            return result.ToList();
        }

        public async Task<ReservationResultDto> GetById(string id)
        {
            var result = await _reservRepo.GetBy(x => x.Id == id);

            var createdBy = await _unitOfWork.Users.GetBy(x=>x.Id == result.CreatedById);

            result.CreatedBy = createdBy;

            if (result == null)
            {
                throw new Exception("Could not find reservation");
            }

            return _mapper.Map<ReservationResultDto>(result);
        }

        public async Task Update(string id, ReservationUpdateDto input)
        {
            await ThrowIfReservationDoesntMeetCriteria(input.TableId, id, input.Date);

            Reservation reservation = await _reservRepo.GetBy(x => x.Id == id);

            if(reservation== null)
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

        private async Task ThrowIfReservationDoesntMeetCriteria(string tableId, string reservationId, DateTime timeOfReservation)
        {
            var table = await _unitOfWork.Tables
                .GetAll(x => x.Id == tableId)
                .Include(x => x.Reservations)
                .FirstOrDefaultAsync();

            if (table == null)
            {
                throw new Exception("Table does not exist");
            }

            bool tableCriteria = table.Reservations.Any(x =>
                x.Id != reservationId
                && x.Date.Day == timeOfReservation.Day
                && x.Date.Month == timeOfReservation.Month
                && x.Date.Year == timeOfReservation.Year
                && x.Date.Hour == timeOfReservation.Hour);

            if (tableCriteria)
            {
                throw new Exception("This table has a reservation too close to the requested one");
            }
        }
    }
}
