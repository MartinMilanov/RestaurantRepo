using Restaurant.Data.Entities.Tables;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class TableRepository : Repository<Table>
    {
        public TableRepository(RestaurantDbContext context) : base(context)
        {
        }
    }
}
