using System.ComponentModel.DataAnnotations;

namespace Restaurant.Mapping.Models.Categories
{
    public class CategoryUpdateDto
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
