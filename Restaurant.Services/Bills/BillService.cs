using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;
using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Mapping.Models.Bills;
using Restaurant.Mapping.Models.Common;
using Restaurant.Services.FoodBills;
using Restaurant.Services.Loggers;

namespace Restaurant.Services.Bills
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggingService _loggingService;
        private readonly BillsRepository _billRepo;
        private readonly IFoodBillService _foodBillService;

        public BillService(IUnitOfWork unitOfWork, IMapper mapper, ILoggingService loggingService, IFoodBillService foodBillService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggingService = loggingService;
            _foodBillService = foodBillService;
            _billRepo = unitOfWork.Bills;
        }

        public async Task Create(BillCreateDto input)
        {
            var entity = _mapper.Map<Bill>(input);

            entity.Total = await CalculateTotal(input.FoodData);

            await _billRepo.Create(entity);

            if (input.FoodData != null)
            {
                foreach (var food in input.FoodData)
                {
                    food.BillId = entity.Id;
                }

                await _unitOfWork.FoodBills.CreateBatch(input.FoodData.Select(x => _mapper.Map<FoodBill>(x)));
            }

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnCreate("Bills");
        }

        public async Task Delete(string id)
        {
            var entityToDelete = await _billRepo.GetBy(x => x.Id == id);

            if (entityToDelete == null)
            {
                throw new Exception("Сметката не съществува");
            }

            _billRepo.Delete(entityToDelete);

            _unitOfWork.FoodBills.DeleteAllWhere(x => x.BillId == id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<BillListDto>> GetAll(BillsPaginationDto filters)
        {
            var query = _billRepo
                .GetAll()
                .Include(x => x.Table)
                .Include(x => x.CreatedBy)
                .AsQueryable();

            if (filters.IsClosed != null)
            {
                query = query.Where(x => x.IsClosed == filters.IsClosed);
            }

            if (filters.TableNumber != 0)
            {
                query = query.Where(x => x.Table.TableNumber == filters.TableNumber);
            }

            if (filters.OrderBy == "Total")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.Total);
                }
                else
                {
                    query = query.OrderByDescending(x => x.Total);
                }
            }

            if (filters.OrderBy == "Closed")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.Closed);
                }
                else
                {
                    query = query.OrderByDescending(x => x.Closed);
                }
            }

            if (filters.OrderBy == "IsClosed")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.IsClosed);
                }
                else
                {
                    query = query.OrderByDescending(x => x.IsClosed);
                }
            }

            if (filters.OrderBy == "TableNumber")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.Table.TableNumber);
                }
                else
                {
                    query = query.OrderByDescending(x => x.Table.TableNumber);
                }
            }

            if (filters.OrderBy == "CreatedBy")
            {
                if (filters.OrderWay == OrderWay.Ascending)
                {
                    query = query.OrderBy(x => x.CreatedBy.UserName);
                }
                else
                {
                    query = query.OrderByDescending(x => x.CreatedBy.UserName);
                }
            }

            query = query.Skip(filters.Skip).Take(filters.Take);

            var result = query.Select(x => _mapper.Map<BillListDto>(x));

            return result.ToList();
        }

        public async Task<int> GetCount(BillsPaginationDto filters)
        {
            var query = _billRepo.GetAll();

            if (filters.IsClosed != null)
            {
                query = query.Where(x => x.IsClosed == filters.IsClosed);
            }

            if (filters.TableNumber != 0)
            {
                query = query.Where(x => x.Table.TableNumber == filters.TableNumber);
            }

            return query.ToList().Count;
        }

        public async Task<BillResultDto> GetById(string id)
        {
            var result = await _billRepo.GetBy(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("Сметката не съществува");
            }

            var foods = _foodBillService.GetFoodsByBillId(id);

            var bill = _mapper.Map<BillResultDto>(result);

            bill.FoodsOrdered = foods.ToList();

            return bill;
        }

        public async Task Update(string id, BillUpdateDto input)
        {
            var entity = await _billRepo.GetBy(x => x.Id == id);

            entity.TableId = input.TableId;
            entity.IsClosed = input.IsClosed;
            entity.CreatedById = input.CreatedById;
            entity.Total = await CalculateTotal(input.FoodData);

            _billRepo.Update(id, entity);

            List<FoodBill>? foodBillsMapped = input?.FoodData?.Select(x => _mapper.Map<FoodBill>(x)).ToList();

            await _foodBillService.UpdateFoodsAfterBillUpdate(id, foodBillsMapped);

            _billRepo.Update(id, entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnUpdate("Bills");
        }
    
        private async Task<decimal> CalculateTotal(IEnumerable<FoodBillDto> foodData)
        {
            decimal total = 0;

            foreach (var food in foodData)
            {
                var foodEntity = await _unitOfWork.Foods.GetBy(x => x.Id == food.FoodId);

                if (foodEntity == null)
                {
                    throw new Exception("Храна с посочено id не съществува. Сметката не може да бъде създадена");
                }

                total += food.Quantity * foodEntity.Price;
            }

            return total;
        }
    }
}
