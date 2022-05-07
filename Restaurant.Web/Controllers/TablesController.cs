using Microsoft.AspNetCore.Mvc;
using Restaurant.Mapping.Models.Tables;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Tables;

namespace Restaurant.Web.Controllers
{
    public class TablesController : BaseController
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TableCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            await _tableService.Create(input);

            return Ok(new Response<String>(false, null, "Successfully created Table"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TableUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            await _tableService.Update(id, input);

            return Ok(new Response<String>(false, null, "Successfully updated Table"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            TableResultDto entity = await _tableService.GetById(id);

            return Ok(new Response<TableResultDto>(false, "", entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetTables()
        {
            List<TableResultDto> tables = (await _tableService.GetAll()).ToList();

            return Ok(new Response<IEnumerable<TableResultDto>>(false, "", tables));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            await _tableService.Delete(id);

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }
    }
}
