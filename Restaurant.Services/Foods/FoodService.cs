﻿using AutoMapper;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;
using Restaurant.Data.Entities.Foods;
using Restaurant.Mapping.Models.Foods;
using Restaurant.Services.Loggers;
using System.Linq.Expressions;

namespace Restaurant.Services.Foods
{
    public class FoodService : IFoodService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggingService _loggingService;
        private readonly FoodRepository _foodRepo;

        public FoodService(IUnitOfWork unitOfWork, IMapper mapper, ILoggingService loggingService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggingService = loggingService;
            _foodRepo = unitOfWork.Foods;
        }

        public async Task Create(FoodCreateDto input)
        {
            await ThrowIfFoodWithSameNameExists(input.Name, null);

            await ThrowIfCategoryDoesNotExist(input.CategoryId);

            var entity = _mapper.Map<Food>(input);

            await _foodRepo.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnCreate("Foods");
        }

        public async Task Delete(string id)
        {
            var entityToDelete = await _foodRepo.GetBy(x => x.Id == id);

            if (entityToDelete == null)
            {
                throw new Exception("Food does not exist");
            }

            _foodRepo.Delete(entityToDelete);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<FoodResultDto>> GetAll()
        {
            var result = (_foodRepo.GetAll().ToList()).Select(x => _mapper.Map<FoodResultDto>(x));

            return result.ToList();
        }

        public IEnumerable<FoodResultDto> GetAll(Expression<Func<Food, bool>> predicate)
        {
            var result = _foodRepo
                .GetAll(predicate: predicate)
                .Select(x => _mapper.Map<FoodResultDto>(x))
                .ToList();

            return result;
        }

        public async Task<FoodResultDto> GetById(string id)
        {
            var result = await _foodRepo.GetBy(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("Could not find food");
            }

            return _mapper.Map<FoodResultDto>(result);
        }

        public async Task Update(string id, FoodUpdateDto input)
        {
            await ThrowIfFoodWithSameNameExists(input.Name, id);

            await ThrowIfCategoryDoesNotExist(input.CategoryId);

            var entity = _mapper.Map<Food>(input);

            entity.Id = id;

            if (string.IsNullOrWhiteSpace(input.CategoryId))
            {
                entity.CategoryId = null;
            }

            _foodRepo.Update(id, entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnUpdate("Foods");
        }

        private async Task ThrowIfFoodWithSameNameExists(string name, string id)
        {
            var foodExists = await _foodRepo.Exists(x => x.Name == name && x.Id != id);

            if (foodExists == true)
            {
                throw new Exception("Food with such name already exists");
            }
        }

        private async Task ThrowIfCategoryDoesNotExist(string id)
        {
            var category = string.IsNullOrWhiteSpace(id) ? true : await _unitOfWork.Categories.Exists(x => x.Id == id);

            if (category == false)
            {
                throw new Exception("Catgory with such id does not exists and cant be added to food");
            }
        }
    }
}
