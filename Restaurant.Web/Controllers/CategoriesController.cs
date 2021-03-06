using Microsoft.AspNetCore.Mvc;
using Restaurant.Mapping.Models.Categories;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Categories;
using Restaurant.Mapping.Models.Common;

namespace Restaurant.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Невалидни данни");
            }

            await _categoryService.Create(input);

            return Ok(new Response<String>(false, null, "Успешно създадохте категорията"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CategoryUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Невалидни данни");
            }
            await _categoryService.Update(id, input);

            return Ok(new Response<String>(false, null, "Успешно обновихте категорията"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                throw new Exception("Id не трябва да е празно");
            }

            CategoryResultDto result = await _categoryService.GetById(id);

            return Ok(new Response<CategoryResultDto>(false, "", result));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] CategoryPaginationDto filters)
        {
            List<CategoryResultDto> items = (await _categoryService.GetAll(filters)).ToList();
            int count = await _categoryService.GetCount(filters);

            var result = new PaginatedResult<CategoryResultDto>(count, items);

            return Ok(new Response<PaginatedResult<CategoryResultDto>>(false, "", result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                throw new Exception("Id не трябва да е празно");
            }

            await _categoryService.Delete(id);

            return Ok(new Response<String>(false, "", $"Категорията с id:{id} бе изтрита"));
        }
    }
}
