using Restaurant.Data.Common.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Common.Persistance
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        public FoodRepository FoodRepository { get; set; }
        private readonly RestaurantDbContext dbContext;

        public UnitOfWork(RestaurantDbContext dbContext)
        {
            this.dbContext = dbContext;
            FoodRepository = new FoodRepository(dbContext);
        }
        public async Task Save()
        {
            this.dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
