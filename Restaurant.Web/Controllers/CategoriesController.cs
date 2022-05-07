using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Categories;
using Restaurant.Services.Loggers;
using Restaurant.Mapping.Models.Categories;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Categories;

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
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            await _categoryService.Create(input);

            return Ok(new Response<String>(false, null, "Successfully created category"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CategoryUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }
            await _categoryService.Update(id, input);

            return Ok(new Response<String>(false, null, "Successfully updated category"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            CategoryResultDto result = await _categoryService.GetById(id);

            return Ok(new Response<CategoryResultDto>(false, "", result));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryResultDto> categories = (await _categoryService.GetAll()).ToList();

            return Ok(new Response<IEnumerable<CategoryResultDto>>(false, "", categories));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            await _categoryService.Delete(id);

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }
    }
}
