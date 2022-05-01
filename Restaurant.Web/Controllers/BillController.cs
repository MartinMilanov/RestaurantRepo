using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Web.Models.Request.Bills;
using Restaurant.Web.Models.Response;

namespace Restaurant.Web.Controllers
{
    public class BillController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BillController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("/")]
        public async Task<IActionResult> Create([FromBody] BillCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Bill entity = _mapper.Map<Bill>(input);

            await _unitOfWork.Bills.Create(entity);

            if (input.Foods != null)
            {
                foreach (var food in input.Foods)
                {
                    food.BillId = entity.Id;
                }

                await _unitOfWork.FoodBills.CreateBatch(input.Foods.Select(x => _mapper.Map<FoodBill>(x)));
            }

            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, null, "Successfully created Bill"));
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(string id)
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

        [HttpPut("/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] BillCreateDto input)
        {
            //Think of a way to update the bill without updating the bill


            // The bill can be updated only by adding or removing food items, which can be applied in the foods controller

            throw new NotImplementedException();
        }


        [HttpGet("/")]
        public async Task<IActionResult> GetBills()
        {
            List<Bill> result = (await _unitOfWork.Bills.GetAll()).ToList();

            if (result == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<IEnumerable<Bill>>(false, "", result));
        }

        [HttpDelete("/{id}")]
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

            _unitOfWork.FoodBills.Delete(x => x.BillId == id);
            _unitOfWork.Bills.Delete(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }
    }
}
