using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Categories;
using Restaurant.Services.Loggers;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Request.Categories;
using Restaurant.Web.Models.Response;

namespace Restaurant.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork unitOfWork, ILoggingService loggingService, IMapper mapper): base(unitOfWork, loggingService, mapper)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Category entity = _mapper.Map<Category>(input);

            await _unitOfWork.Categories.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, null, "Successfully created category"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CategoryUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Category entity = _mapper.Map<Category>(input);

            input.Id = id;

            _unitOfWork.Categories.Update(id, entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, null, "Successfully updated category"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Category entity = await _unitOfWork.Categories.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<Category>(false, "", entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<Category> catgories = (await _unitOfWork.Categories.GetAll()).ToList();

            if (catgories == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<IEnumerable<Category>>(false, "", catgories));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Category entity = await _unitOfWork.Categories.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            _unitOfWork.Categories.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }
    }
}
