using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;
using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Mapping.Models.Bills;
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
                throw new Exception("Bill does not exist");
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
                query = query.Where(x=>x.IsClosed == filters.IsClosed);
            }

            if (filters.TableNumber != 0)
            {
                query = query.Where(x => x.Table.TableNumber == filters.TableNumber);
            }

            if (filters.OrderBy == "Total")
            {
                query = query.OrderBy(x => x.Total);
            }

            if (filters.OrderBy == "Closed")
            {
                query = query.OrderBy(x => x.Closed);
            }

            if (filters.OrderBy == "IsClosed")
            {
                query = query.OrderBy(x => x.IsClosed);
            }

            if (filters.OrderBy == "TableNumber")
            {
                query = query.OrderBy(x => x.Table.TableNumber);
            }

            query = query.Skip(filters.Skip).Take(filters.Take);

            var result = query.Select(x => _mapper.Map<BillListDto>(x));

            return result.ToList();
        }

        public async Task<BillResultDto> GetById(string id)
        {
            var result = await _billRepo
                .GetBy(x => x.Id == id, x => x.Table);

            if (result == null)
            {
                throw new Exception("Could not find bill");
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
            entity.Total = input.Total;
            entity.IsClosed = input.IsClosed;
            entity.CreatedById = input.CreatedById;

            _billRepo.Update(id, entity);

            List<FoodBill>? foodBillsMapped = input?.FoodData?.Select(x => _mapper.Map<FoodBill>(x)).ToList();

            await _foodBillService.UpdateFoodsAfterBillUpdate(id, foodBillsMapped);

            _billRepo.Update(id, entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnUpdate("Bills");
        }
    }
}
