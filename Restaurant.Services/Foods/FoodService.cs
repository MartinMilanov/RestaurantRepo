using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;

namespace Restaurant.Services.Foods
{
    public class FoodService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
