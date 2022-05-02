using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.FoodBills;

namespace Restaurant.Services.FoodBills
{
    public class FoodBillService : IFoodBillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodBillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateFoodsAfterBillUpdate(string billId, IEnumerable<FoodBill> foodBills)
        {
            var foodBillRepo = _unitOfWork.FoodBills;

            foreach (var foodBillInput in foodBills)
            {
                foodBillInput.BillId = billId;

                FoodBill foodBillData = await foodBillRepo.GetBy(x =>
                      x.FoodId == foodBillInput.FoodId &&
                      x.BillId == foodBillInput.BillId);

                if (foodBillData == null)
                {
                    await foodBillRepo.Create(foodBillInput);
                }
            }

            List<string> latestFoodIds = foodBills.Select(lfb => lfb.FoodId).ToList();

            foodBillRepo.DeleteAllWhere(fb => latestFoodIds.Any(id => id == fb.FoodId) == false);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
