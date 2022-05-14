using System.Linq.Expressions;

namespace Restaurant.Data.Common.Persistance
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);

        Task CreateBatch(IEnumerable<TEntity> entity);

        void Delete(TEntity entity);

        void Update(string id, TEntity entity);

        Task<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
    }
}
