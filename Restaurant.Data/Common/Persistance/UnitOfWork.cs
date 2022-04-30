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
            Categories = new CategoryRepository(context);
            Tables = new TableRepository(context);
        }

        public FoodRepository Foods {get;set;}

        public CategoryRepository Categories {get;set; }

        public TableRepository Tables { get; set; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
