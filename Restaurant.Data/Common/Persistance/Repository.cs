using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Restaurant.Data.Common.Persistance
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly RestaurantDbContext _context;

        public Repository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task Create(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetBy(Expression<Func<TEntity,bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
