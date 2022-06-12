using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Bills
{
    public class BillUpdateDto
    {
        [Required]
        public bool IsClosed { get; set; }
        [Required]
        public string TableId { get; set; }
        [Required]
        public string CreatedById { get; set; }

        public IEnumerable<FoodBillDto>? FoodData { get; set; }
    }
}
