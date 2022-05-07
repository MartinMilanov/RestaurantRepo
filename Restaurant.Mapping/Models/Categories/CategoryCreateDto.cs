using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Categories
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
