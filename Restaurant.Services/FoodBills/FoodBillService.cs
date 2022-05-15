using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Mapping.Models.Foods;

namespace Restaurant.Services.FoodBills
{
    public class FoodBillService : IFoodBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FoodBillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task UpdateFoodsAfterBillUpdate(string billId, List<FoodBill> foodBills)
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

                foodBillData.Quantity = foodBillInput.Quantity;

                foodBillRepo.Update(foodBillData.BillId, foodBillData);
            }

            List<string> latestFoodIds = foodBills.Select(lfb => lfb.FoodId).ToList();

            foodBillRepo.DeleteAllWhere(fb => latestFoodIds.Any(id => id == fb.FoodId) == false && fb.BillId == billId);

            await _unitOfWork.SaveChangesAsync();
        }
    
        public IEnumerable<FoodBillListDto> GetFoodsByBillId(string billId)
        {
            var foodBills = _unitOfWork.FoodBills
                .GetAll(x => x.BillId == billId)
                .Include(x => x.Food);

            var foodListObjects = foodBills.Select(x => _mapper.Map<FoodBillListDto>(x)).ToList();

            return foodListObjects;
        }
    }
}
