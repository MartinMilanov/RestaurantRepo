using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    interface IDataRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity input);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(string id);
        Task<TEntity> Update(TEntity input);
        Task<bool> Delete(TEntity entity);
    }
}
