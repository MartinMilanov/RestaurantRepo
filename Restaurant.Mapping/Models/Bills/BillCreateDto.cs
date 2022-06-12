using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Bills
{
    public class BillCreateDto
    {
        [Required]
        public bool IsClosed { get; set; }
        [Required]
        public string? TableId { get; set; }
        [Required]
        public string? CreatedById { get; set; }
        public List<FoodBillDto>? FoodData { get; set; }
    }
}
