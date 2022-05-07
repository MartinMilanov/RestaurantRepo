using AutoMapper;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Common.Persistance.Repositories;
using Restaurant.Data.Entities.Bills;
using Restaurant.Mapping.Models.Bills;
using Restaurant.Services.Loggers;

namespace Restaurant.Services.Bills
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggingService _loggingService;
        private readonly BillsRepository _billRepo;

        public BillService(IUnitOfWork unitOfWork, IMapper mapper, ILoggingService loggingService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggingService = loggingService;
            _billRepo = unitOfWork.Bills;
        }

        public async Task Create(BillCreateDto input)
        {
            var entity = _mapper.Map<Bill>(input);

            await _billRepo.Create(entity);

            //Create the FoodBills stuff

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

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<BillResultDto>> GetAll()
        {
            var result = (await _billRepo.GetAll()).Select(x => _mapper.Map<BillResultDto>(x));

            return result.ToList();
        }

        public async Task<BillResultDto> GetById(string id)
        {
            var result = await _billRepo.GetBy(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("Could not find bill");
            }

            return _mapper.Map<BillResultDto>(result);
        }

        public async Task Update(string id, BillUpdateDto input)
        {
            var entity = _mapper.Map<Bill>(input);

            _billRepo.Update(id, entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnUpdate("Bills");
        }
    }
}
