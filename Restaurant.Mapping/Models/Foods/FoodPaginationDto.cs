using Restaurant.Mapping.Models.Common;

namespace Restaurant.Mapping.Models.Foods
{
    public class FoodPaginationDto : PaginationDto
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
