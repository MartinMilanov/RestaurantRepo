using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Services.FoodBills;
using Restaurant.Services.Loggers;
using Restaurant.Mapping.Models.Bills;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Bills;

namespace Restaurant.Web.Controllers
{
    public class BillsController : BaseController
    {
        private readonly IFoodBillService _foodBillService;
        private readonly IBillService _billService;

        public BillsController(IFoodBillService foodBillService, IBillService billService)
        {
            _foodBillService = foodBillService;
            _billService = billService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] BillCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            await _billService.Create(input);

            //if (input.FoodData != null)
            //{
            //    foreach (var food in input.FoodData)
            //    {
            //        food.BillId = entity.Id;
            //    }

            //    await _unitOfWork.FoodBills.CreateBatch(input.FoodData.Select(x => _mapper.Map<FoodBill>(x)));
            //}

            return Ok(new Response<String>(false, null, "Successfully created Bill"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            BillResultDto result = await _billService.GetById(id);

            return Ok(new Response<BillResultDto>(false, "", result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] BillUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            input.Id = id;

            await _billService.Update(id, input);

            //Bill mappedInput = _mapper.Map<Bill>(input);

            //IEnumerable<FoodBill>? foodBillsMapped = input?.FoodData?.Select(x => _mapper.Map<FoodBill>(x));

            //await _foodBillService.UpdateFoodsAfterBillUpdate(id, foodBillsMapped);

            //_unitOfWork.Bills.Update(id, mappedInput);

            return Ok(new Response<string>(false, "", "Succesfully update bill"));
        }

        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            List<BillResultDto> result = (await _billService.GetAll()).ToList();

            return Ok(new Response<IEnumerable<BillResultDto>>(false, "", result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            await _billService.Delete(id);

            //_unitOfWork.FoodBills.DeleteAllWhere(x => x.BillId == id);
            //_unitOfWork.Bills.Delete(entity);

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }

    }
}
