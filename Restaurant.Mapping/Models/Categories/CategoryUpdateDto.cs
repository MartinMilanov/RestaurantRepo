using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Categories
{
    public class CategoryUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
