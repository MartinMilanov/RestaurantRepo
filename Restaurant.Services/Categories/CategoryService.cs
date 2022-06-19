using AutoMapper;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;
using Restaurant.Data.Entities.Categories;
using Restaurant.Mapping.Models.Categories;
using Restaurant.Mapping.Models.Common;
using Restaurant.Services.Loggers;

namespace Restaurant.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggingService _loggingService;
        private readonly CategoryRepository _catRepo;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILoggingService loggingService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggingService = loggingService;
            _catRepo = unitOfWork.Categories;
        }

        public async Task Create(CategoryCreateDto input)
        {
            var entity = _mapper.Map<Category>(input);

            await ThrowIfCategoryWithSameNameExists(input.Name);

            await _catRepo.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnCreate("Categories");
        }

        public async Task Delete(string id)
        {
            var entityToDelete = await _catRepo.GetBy(x => x.Id == id);

            if (entityToDelete == null)
            {
                throw new Exception("Категорията не съществува");
            }

            _catRepo.Delete(entityToDelete);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryResultDto>> GetAll(CategoryPaginationDto filters)
        {
            var query = _catRepo.GetAll();

            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));
            }

            if (filters.OrderBy == "Name")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.Name);
                }
                else
                {
                    query = query.OrderByDescending(x => x.Name);
                }
            }

            query = query.Skip(filters.Skip).Take(filters.Take);

            var result = query.Select(x => _mapper.Map<CategoryResultDto>(x));

            return result.ToList();
        }

        public async Task<int> GetCount(CategoryPaginationDto filters)
        {
            var query = _catRepo.GetAll();

            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));
            }

            return query.ToList().Count;
        }

        public async Task<CategoryResultDto> GetById(string id)
        {
            var result = await _catRepo.GetBy(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("Категорията не съществува");
            }

            return _mapper.Map<CategoryResultDto>(result);
        }

        public async Task Update(string id, CategoryUpdateDto input)
        {
            var newData = _mapper.Map<Category>(input);

            newData.Id = id;

            _catRepo.Update(id, newData);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnUpdate("Categories");
        }

        private async Task ThrowIfCategoryWithSameNameExists(string name)
        {
            var exists = await _catRepo.Exists(x => x.Name == name);

            if (exists == true)
            {
                throw new Exception("Категория със същото име вече съществува");
            }
        }
    }
}
