using Restaurant.Data.Entities.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class FoodRepository:DataRepository<Food>
    {
        public FoodRepository(RestaurantDbContext dbContext) :base(dbContext)
        {
        }
    }
}
