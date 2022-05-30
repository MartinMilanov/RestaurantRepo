using Microsoft.AspNetCore.Mvc;
using Restaurant.Mapping.Models.Foods;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Foods;
using Restaurant.Mapping.Models.Common;

namespace Restaurant.Web.Controllers
{
    public class FoodsController : BaseController
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] FoodCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            await _foodService.Create(input);

            return Ok(new Response<String>(false, null, "Successfully created food"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] FoodUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            await _foodService.Update(id, input);

            return Ok(new Response<String>(false, null, "Successfully updated food"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            FoodResultDto entity = await _foodService.GetById(id);

            return Ok(new Response<FoodResultDto>(false, "", entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoods([FromQuery] FoodPaginationDto filters)
        {
            List<FoodListDto> items = (await _foodService.GetAll(filters)).ToList();
            int count = await _foodService.GetCount(filters);

            var result = new PaginatedResult<FoodListDto>(count, items);

            return Ok(new Response<PaginatedResult<FoodListDto>>(false, "", result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            await _foodService.Delete(id);

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }

        [HttpGet("getAllByCategory/{categoryId}")]
        public async Task<IActionResult> GetAllByCategory(string categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest(new Response<string>(true, "Category id should not be null", null));
            }

            IEnumerable<FoodResultDto> foods = _foodService.GetAll(x => x.Id == categoryId);

            return Ok(new Response<IEnumerable<FoodResultDto>>(false, "", foods));
        }
    }
}
