using Restaurant.Data.Entities.FoodBills;
using Restaurant.Mapping.Models.Foods;

namespace Restaurant.Services.FoodBills
{
    public interface IFoodBillService
    {
        Task UpdateFoodsAfterBillUpdate(string billId, List<FoodBill> foodBills);

        IEnumerable<FoodBillListDto> GetFoodsByBillId(string billId);
    }
}
