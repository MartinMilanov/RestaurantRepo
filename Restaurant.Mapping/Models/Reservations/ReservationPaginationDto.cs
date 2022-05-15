using Restaurant.Mapping.Models.Common;

namespace Restaurant.Mapping.Models.Reservations
{
    public class ReservationPaginationDto : PaginationDto
    {
        public string? ReserveeName { get; set; }

        public DateTime? Date { get; set; }
    }
}
