using Restaurant.Data;
using Restaurant.Data.Entities.Foods;
using Restaurant.Services.Repositories.Common;

namespace Restaurant.Services.Repositories
{
    public class FoodRepository : Repository<Food>
    {
        private readonly RestaurantDbContext _context;

        public FoodRepository(RestaurantDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
