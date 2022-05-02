using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models.Request.Categories
{
    public class CategoryUpdateDto
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
