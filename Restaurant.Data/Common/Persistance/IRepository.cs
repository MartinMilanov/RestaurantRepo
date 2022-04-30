using System.Linq.Expressions;

namespace Restaurant.Data.Common.Persistance
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(string id, TEntity entity);
        Task<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
    }
}
