using Restaurant.Mapping.Models.Reservations;

namespace Restaurant.Services.Reservations
{
    public interface IReservationService
    {
        Task Create(ReservationCreateDto input);

        Task Update(string id, ReservationUpdateDto input);

        Task<ReservationResultDto> GetById(string id);

        Task<IEnumerable<ReservationListDto>> GetAll(ReservationPaginationDto filters);

        Task<int> GetCount(ReservationPaginationDto filters);

        Task Delete(string id);
    }
}
