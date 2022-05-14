using Restaurant.Data.Entities.FoodBills;

namespace Restaurant.Services.FoodBills
{
    public interface IFoodBillService
    {
        Task UpdateFoodsAfterBillUpdate(string billId, List<FoodBill> foodBills);
    }
}
