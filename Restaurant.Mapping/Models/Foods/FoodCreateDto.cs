using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Foods
{
    public class FoodCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
        
    }
}
