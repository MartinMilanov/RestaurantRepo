using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Tables;
using Restaurant.Services.Loggers;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Request.Tables;
using Restaurant.Web.Models.Response;

namespace Restaurant.Web.Controllers
{
    public class TablesController : BaseController
    {
        public TablesController(IUnitOfWork unitOfWork, ILoggingService loggingService, IMapper mapper) : base(unitOfWork, loggingService, mapper)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TableCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Table entity = _mapper.Map<Table>(input);

            await _unitOfWork.Tables.Create(entity);

            await _unitOfWork.SaveChangesAsync();
            
            await _loggingService.LogOnCreate("Tables");

            return Ok(new Response<String>(false, null, "Successfully created Table"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TableUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            input.Id = id;

            Table entity = _mapper.Map<Table>(input);

            _unitOfWork.Tables.Update(id, entity);

            await _unitOfWork.SaveChangesAsync();

            await _loggingService.LogOnCreate("Tables");
            
            return Ok(new Response<String>(false, null, "Successfully updated Table"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Table entity = await _unitOfWork.Tables.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<Table>(false, "", entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetTables()
        {
            List<Table> catgories = (await _unitOfWork.Tables.GetAll()).ToList();

            if (catgories == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<IEnumerable<Table>>(false, "", catgories));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Table entity = await _unitOfWork.Tables.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            _unitOfWork.Tables.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }
    }
}
