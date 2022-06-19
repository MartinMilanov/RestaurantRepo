using Microsoft.AspNetCore.Mvc;
using Restaurant.Mapping.Models.Bills;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Bills;
using Restaurant.Mapping.Models.Common;

namespace Restaurant.Web.Controllers
{
    public class BillsController : BaseController
    {
        private readonly IBillService _billService;

        public BillsController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] BillCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Невалидни данни");
            }

            await _billService.Create(input);

            return Ok(new Response<String>(false, null, "Успешно създадохте сметка"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillById(string id)
        {
            if (id == null)
            {
                throw new Exception("Id не трябва да е празно");
            }

            BillResultDto result = await _billService.GetById(id);

            return Ok(new Response<BillResultDto>(false, "", result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] BillUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Невалидни данни");
            }

            await _billService.Update(id, input);

            return Ok(new Response<string>(false, "", "Успешно обновихте сметка"));
        }

        [HttpGet]
        public async Task<IActionResult> GetBills([FromQuery] BillsPaginationDto filters)
        {
            List<BillListDto> items = (await _billService.GetAll(filters)).ToList();
            int count = await _billService.GetCount(filters);

            var result = new PaginatedResult<BillListDto>(count, items);

            return Ok(new Response<PaginatedResult<BillListDto>>(false, "", result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                throw new Exception("Id не трябва да е празно", null);
            }

            await _billService.Delete(id);

            return Ok(new Response<String>(false, "", $"Успешно изтрихте сметка със id:{id}"));
        }

    }
}
