using Restaurant.Data.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class TableRepository : Repository<Table>
    {
        public TableRepository(RestaurantDbContext context) : base(context)
        {
        }
    }
}
