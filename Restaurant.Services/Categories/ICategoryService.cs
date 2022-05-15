using Restaurant.Mapping.Models.Categories;

namespace Restaurant.Services.Categories
{
    public interface ICategoryService
    {
        Task Create(CategoryCreateDto input);

        Task Update(string id, CategoryUpdateDto input);

        Task<CategoryResultDto> GetById(string id);

        Task<IEnumerable<CategoryResultDto>> GetAll(CategoryPaginationDto filters);

        Task Delete(string id);
    }
}
