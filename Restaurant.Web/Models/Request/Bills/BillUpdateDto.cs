using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models.Request.Bills
{
    public class BillUpdateDto
    {
        public string? Id { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public bool IsClosed { get; set; }
        [Required]
        public string TableId { get; set; }
        [Required]
        public string CreatedById { get; set; }

        public IEnumerable<FoodBillDto>? FoodData { get; set; }
    }
}
