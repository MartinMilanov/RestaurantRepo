using Restaurant.Data.Entities.FoodBills;
using System.Linq.Expressions;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class FoodBillRepository : Repository<FoodBill>
    {
        public FoodBillRepository(RestaurantDbContext context) : base(context)
        {
        }

        public void DeleteAllWhere(Expression<Func<FoodBill, bool>> predicate)
        {
            IEnumerable<FoodBill> foodBillsToBeDeleted = _context.FoodBills.Where(predicate);

            this._context.Set<FoodBill>().RemoveRange(foodBillsToBeDeleted);
        }
    }
}
