using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Tables
{
    public class TableUpdateDto
    {
        [Required]
        public int TableNumber { get; set; }

        [Required]
        public int Seats { get; set; }
    }
}
