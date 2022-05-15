using Restaurant.Mapping.Models.Common;

namespace Restaurant.Mapping.Models.Foods
{
    public class FoodPaginationDto : PaginationDto
    {
        public string? Name { get; set; }
        public double Price { get; set; }
    }
}
