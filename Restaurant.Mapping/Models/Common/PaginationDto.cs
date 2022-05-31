using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Common
{
    public class PaginationDto
    {
        [Required]
        public int Skip { get; set; }
        [Required]
        public int Take { get; set; }
        [Required]
        public string OrderBy { get; set; }
        [Required]
        public OrderWay OrderWay{ get; set; }
    }
}
