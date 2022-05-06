using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Foods;
using Restaurant.Services.Loggers;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Request.Foods;
using Restaurant.Web.Models.Response;

namespace Restaurant.Web.Controllers
{
    public class FoodsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FoodsController(IUnitOfWork unitOfWork, ILoggingService loggingService, IMapper mapper) : base(unitOfWork, loggingService, mapper)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] FoodDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Food entity = _mapper.Map<Food>(input);

            await _unitOfWork.Foods.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnCreate("Foods");
           
            return Ok(new Response<String>(false, null, "Successfully created food"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] FoodUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            input.Id = id;

            Food entity = _mapper.Map<Food>(input);

            _unitOfWork.Foods.Update(id, entity);

            await _unitOfWork.SaveChangesAsync();
            
            await _loggingService.LogOnCreate("Foods");

            return Ok(new Response<String>(false, null, "Successfully updated food"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Food entity = await _unitOfWork.Foods.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<Food>(false, "", entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoods()
        {
            List<Food> foods = (await _unitOfWork.Foods.GetAll()).ToList();

            if (foods == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<IEnumerable<Food>>(false, "", foods));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Food entity = await _unitOfWork.Foods.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            _unitOfWork.Foods.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }

        [HttpGet("getAllByCategory/{categoryId}")]
        public async Task<IActionResult> GetAllByCategory(string categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest(new Response<string>(true, "Category id should not be null", null));
            }

            IEnumerable<Food> foods = await _unitOfWork.Foods.GetAll(x => x.Id == categoryId);

            return Ok(new Response<IEnumerable<Food>>(false, "", foods));
        }
    }
}
