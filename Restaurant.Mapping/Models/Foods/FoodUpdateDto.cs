using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Foods
{
    public class FoodUpdateDto
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
