using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Services.FoodBills;
using Restaurant.Services.Loggers;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Request.Bills;
using Restaurant.Web.Models.Response;

namespace Restaurant.Web.Controllers
{
    public class BillsController : BaseController
    {
        private readonly IFoodBillService _foodBillService;

        public BillsController(IUnitOfWork unitOfWork, ILoggingService loggingService, IFoodBillService foodBillService, IMapper mapper)
            :base(unitOfWork, loggingService, mapper)
        {
            _foodBillService = foodBillService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] BillCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Bill entity = _mapper.Map<Bill>(input);

            await _unitOfWork.Bills.Create(entity);

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

            return Ok(new Response<String>(false, null, "Successfully created Bill"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Bill entity = await _unitOfWork.Bills.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<Bill>(false, "", entity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] BillUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            input.Id = id;

            Bill mappedInput = _mapper.Map<Bill>(input);

            IEnumerable<FoodBill>? foodBillsMapped = input?.FoodData?.Select(x => _mapper.Map<FoodBill>(x));
            
            await _foodBillService.UpdateFoodsAfterBillUpdate(id,foodBillsMapped);

            _unitOfWork.Bills.Update(id, mappedInput);

            await _unitOfWork.SaveChangesAsync();
            
            await _loggingService.LogOnUpdate("Bills");

            return Ok(new Response<string>(false, "", "Succesfully update bill"));
        }

        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            List<Bill> result = (await _unitOfWork.Bills.GetAll()).ToList();

            if (result == null)
            {
                return BadRequest(new Response<string[]>(true, "Could not find records", new string[0]));
            }

            return Ok(new Response<IEnumerable<Bill>>(false, "", result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Bill entity = await _unitOfWork.Bills.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            _unitOfWork.FoodBills.DeleteAllWhere(x => x.BillId == id);
            _unitOfWork.Bills.Delete(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }

    }
}
