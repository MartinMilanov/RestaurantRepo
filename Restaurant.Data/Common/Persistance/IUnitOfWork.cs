using Restaurant.Data.Common.Persistance.Repositories;

namespace Restaurant.Data.Common.Persistance
{
    public interface IUnitOfWork
    {
        FoodRepository Foods { get; }
        CategoryRepository Categories { get; }
        TableRepository Tables { get; }
        ReservationRepository Reservations { get; }
        BillsRepository Bills { get; }
        FoodBillRepository FoodBills { get; }  
        UserRepository Users { get; }
        Task SaveChangesAsync();
    }
}
