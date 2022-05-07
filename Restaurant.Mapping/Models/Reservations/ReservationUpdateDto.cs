using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Reservations
{
    public class ReservationUpdateDto
    {
        public string? Id { get; set; }
        [Required]
        public string ReserveeName { get; set; }
        [Required]
        public int PeopleCount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string TableId { get; set; }
        [Required]
        public string CreatedById { get; set; }
    }
}
