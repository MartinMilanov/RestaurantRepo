using Restaurant.Data.Common.Persistance.Repositories;

namespace Restaurant.Data.Common.Persistance
{
    public interface IUnitOfWork
    {
        FoodRepository Foods { get; }
        Task SaveChanges();
    }
}
