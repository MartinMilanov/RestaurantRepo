using Restaurant.Data.Entities.Common;
using Restaurant.Data.Entities.Foods;

namespace Restaurant.Data.Entities.Categories
{
    public class Category : BaseEntity, ICategory
    {
        public string Name { get; set; }
        public List<Food> Foods { get; set; }
    }
}