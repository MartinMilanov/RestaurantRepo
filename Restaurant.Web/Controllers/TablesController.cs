using Microsoft.AspNetCore.Mvc;
using Restaurant.Mapping.Models.Tables;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Tables;
using Restaurant.Mapping.Models.Common;

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
                throw new Exception("Invalid data provided");
            }

            await _tableService.Create(input);

            return Ok(new Response<String>(false, null, "Successfully created Table"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TableUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid data provided");
            }

            await _tableService.Update(id, input);

            return Ok(new Response<String>(false, null, "Successfully updated Table"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                throw new Exception("Id should not be null");
            }

            TableResultDto entity = await _tableService.GetById(id);

            return Ok(new Response<TableResultDto>(false, "", entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetTables([FromQuery]TablePaginationDto filters)
        {
            List<TableListDto> items = (await _tableService.GetAll(filters)).ToList();
            int count = await _tableService.GetCount(filters);

            var result = new PaginatedResult<TableListDto>(count, items);

            return Ok(new Response<PaginatedResult<TableListDto>>(false, "", result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                throw new Exception("Id should not be null");
            }

            await _tableService.Delete(id);

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }
    }
}
