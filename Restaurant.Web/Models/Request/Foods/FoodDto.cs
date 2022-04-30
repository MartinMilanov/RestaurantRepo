using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models.Request.Foods
{
    public class FoodDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
        
    }
}
