using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Foods
{
    public class FoodCreateDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? CategoryId { get; set; }
    }
}
