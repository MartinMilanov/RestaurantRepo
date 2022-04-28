using Restaurant.Data.Common.Persistance.Repositories;

namespace Restaurant.Data.Common.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDbContext _context;

        public UnitOfWork(RestaurantDbContext context)
        {
            _context = context;
            Foods = new FoodRepository(context);
        }
        public FoodRepository Foods {get;set;}

        public  async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
