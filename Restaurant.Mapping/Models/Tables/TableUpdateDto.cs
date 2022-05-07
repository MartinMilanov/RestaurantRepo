using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Tables
{
    public class TableUpdateDto
    {
        public string? Id { get; set; }

        [Required]
        public int TableNumber { get; set; }

        [Required]
        public int Seats { get; set; }
    }
}
