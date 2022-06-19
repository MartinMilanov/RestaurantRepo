using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Controllers.Common;
using Restaurant.Mapping.Models.Reservations;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Reservations;
using Restaurant.Mapping.Models.Common;

namespace Restaurant.Web.Controllers
{
    public class ReservationsController: BaseController
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ReservationCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Невалидни данни");
            }

            await _reservationService.Create(input);

            return Ok(new Response<String>(false, null, "Успешно създадохте резервация"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ReservationUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Невалидни данни");
            }

            await _reservationService.Update(id, input);

            return Ok(new Response<String>(false, null, "Успешно обновихте резервация"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                throw new Exception("Id не трябва да бъде празно");
            }

            ReservationResultDto entity = await _reservationService.GetById(id);

            if (entity == null)
            {
                throw new Exception("Резервацията не може да бъде намерена");
            }

            return Ok(new Response<ReservationResultDto>(false, "", entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations([FromQuery] ReservationPaginationDto filters)
        {
            List<ReservationListDto> items = (await _reservationService.GetAll(filters)).ToList();
            int count = await _reservationService.GetCount(filters);

            var result = new PaginatedResult<ReservationListDto>(count, items);
            
            return Ok(new Response<PaginatedResult<ReservationListDto>>(false, "", result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                throw new Exception("Id не трябва да бъде празно");
            }

            await _reservationService.Delete(id);

            return Ok(new Response<String>(false, "", $"Успешно изтрихте резервация с id:{id}"));
        }
    }
}
