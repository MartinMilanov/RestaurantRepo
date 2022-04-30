using Restaurant.Data.Entities.Categories;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(RestaurantDbContext context) : base(context)
        {
        }
    }
}
