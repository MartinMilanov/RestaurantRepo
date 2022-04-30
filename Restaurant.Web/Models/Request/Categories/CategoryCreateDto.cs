using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models.Request.Categories
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
