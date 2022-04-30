using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models.Request.Tables
{
    public class TableCreateDto
    {
        [Required]
        public int TableNumber { get; set; }
        [Required]
        public int Seats { get; set; }
    }
}
