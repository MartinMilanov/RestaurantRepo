using Restaurant.Data.Entities.Foods;
using Restaurant.Mapping.Models.Foods;
using System.Linq.Expressions;

namespace Restaurant.Services.Foods
{
    public interface IFoodService
    {
        Task Create(FoodCreateDto input);

        Task Update(string id, FoodUpdateDto input);

        Task<FoodResultDto> GetById(string id);

        Task<IEnumerable<FoodListDto>> GetAll(FoodPaginationDto filters);

        IEnumerable<FoodListDto> GetAll(Expression<Func<Food, bool>> predicate);

        Task<int> GetCount(FoodPaginationDto filters);

        Task Delete(string id);
    }
}
