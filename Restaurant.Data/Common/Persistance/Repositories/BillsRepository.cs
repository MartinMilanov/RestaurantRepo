using Restaurant.Data.Entities.Bills;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class BillsRepository : Repository<Bill>
    {
        public BillsRepository(RestaurantDbContext context) : base(context)
        {
        }
    }
}
