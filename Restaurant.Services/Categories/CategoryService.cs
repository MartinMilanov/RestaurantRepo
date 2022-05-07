﻿using AutoMapper;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;
using Restaurant.Data.Entities.Categories;
using Restaurant.Mapping.Models.Categories;
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

            await _catRepo.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnCreate("Categories");
        }

        public async Task Delete(string id)
        {
            var entityToDelete = await _catRepo.GetBy(x => x.Id == id);

            if (entityToDelete == null)
            {
                throw new Exception("Category does not exist");
            }

            _catRepo.Delete(entityToDelete);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryResultDto>> GetAll()
        {
            var result = (await _catRepo.GetAll()).Select(x => _mapper.Map<CategoryResultDto>(x));

            return result.ToList();
        }

        public async Task<CategoryResultDto> GetById(string id)
        {
            var result = await _catRepo.GetBy(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("Could not find category");
            }

            return _mapper.Map<CategoryResultDto>(result);
        }

        public async Task Update(string id, CategoryUpdateDto input)
        {
            var entity = _mapper.Map<Category>(input);

            _catRepo.Update(id, entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnUpdate("Categories");
        }
    }
}
