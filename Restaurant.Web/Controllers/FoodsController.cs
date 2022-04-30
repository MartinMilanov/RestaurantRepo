using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Foods;
using Restaurant.Web.Models.Request.Foods;
using Restaurant.Web.Models.Response;

namespace Restaurant.Web.Controllers
{
    [Route("/api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FoodsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("/")]
        public async Task<IActionResult> Create([FromBody] FoodDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Food entity = _mapper.Map<Food>(input);

            await _unitOfWork.Foods.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, "Successfully created food", null));
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> Update([FromBody] FoodDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Food entity = _mapper.Map<Food>(input);

            _unitOfWork.Foods.Update(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, "Successfully updated food", null));
        }

        [HttpGet("/{id}")]
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

        [HttpDelete("/{id}")]
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

            return Ok(new Response<String>(false, "", new string(new char[] { 'a' })));
        }

        [HttpGet("/getAllByCategory/{categoryId}")]
        public async Task<IActionResult> GetAllByCategory(string categoryId)
        {
            if(categoryId == null)
            {
                return BadRequest(new Response<string>(true, "Category id should not be null", null));
            }

            IEnumerable<Food> foods = await _unitOfWork.Foods.GetAll(x=>x.Id == categoryId);

            return Ok(new Response<IEnumerable<Food>>(false, "", foods));
        }
    }
}
