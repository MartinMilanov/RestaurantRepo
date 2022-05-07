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

        public async Task<IEnumerable<ReservationResultDto>> GetAll()
        {
            var result = (await _reservRepo.GetAll()).Select(x => _mapper.Map<ReservationResultDto>(x));

            return result.ToList();
        }

        public async Task<ReservationResultDto> GetById(string id)
        {
            var result = await _reservRepo.GetBy(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("Could not find reservation");
            }

            return _mapper.Map<ReservationResultDto>(result);
        }

        public async Task Update(string id, ReservationUpdateDto input)
        {
            await ThrowIfReservationDoesntMeetCriteria(input.TableId, id, input.Date);

            var entity = _mapper.Map<Reservation>(input);

            _reservRepo.Update(id,entity);

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
                && (x.Date.Hour + 2 > timeOfReservation.Hour || x.Date.Hour - 2 < timeOfReservation.Hour));

            if (!tableCriteria)
            {
                throw new Exception("This table has a reservation too close to the requested one");
            }
        }
    }
}
