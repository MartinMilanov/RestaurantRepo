using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        private readonly RestaurantDbContext dbContext;
        public DataRepository(RestaurantDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TEntity> Create(TEntity input)
        {
            TEntity result = (await dbContext.AddAsync<TEntity>(input)).Entity;
            dbContext.SaveChanges();

            return result;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            dbContext.Remove(entity);
            return true;
        }

        public IQueryable<TEntity> GetAll() => dbContext.Set<TEntity>();

        public async Task<TEntity> GetById(string id)
        {
            TEntity entity = await dbContext.FindAsync<TEntity>(id);

            return entity;
        }

        public async Task<TEntity> Update(TEntity input)
        {
            dbContext.Update<TEntity>(input);
            dbContext.SaveChanges();

            return input;
        }
    }
}
