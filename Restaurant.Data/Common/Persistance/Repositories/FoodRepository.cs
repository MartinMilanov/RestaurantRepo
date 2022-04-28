using Restaurant.Data.Entities.Foods;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class FoodRepository : Repository<Food>
    {
        public FoodRepository(RestaurantDbContext context) : base(context)
        {
        }
    }
}
