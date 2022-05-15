using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Tables
{
    public class TablePaginationDto
    {
        [Required]
        public int Skip { get; set; }
        [Required]
        public int Take { get; set; }
        public int TableNumer { get; set; }
        public int Seats { get; set; }
        [Required]
        public string OrderBy { get; set; }
    }
}
