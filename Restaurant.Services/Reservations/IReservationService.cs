using Restaurant.Mapping.Models.Reservations;

namespace Restaurant.Services.Reservations
{
    public interface IReservationService
    {
        Task Create(ReservationCreateDto input);

        Task Update(string id, ReservationUpdateDto input);

        Task<ReservationResultDto> GetById(string id);

        Task<IEnumerable<ReservationResultDto>> GetAll();

        Task Delete(string id);
    }
}
