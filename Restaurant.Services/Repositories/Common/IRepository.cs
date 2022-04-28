using System.Linq.Expressions;

namespace Restaurant.Services.Repositories.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
