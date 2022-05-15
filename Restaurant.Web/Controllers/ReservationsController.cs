﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Controllers.Common;
using Restaurant.Mapping.Models.Reservations;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Reservations;

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
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            await _reservationService.Create(input);

            return Ok(new Response<String>(false, null, "Successfully created Reservation"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ReservationUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            await _reservationService.Update(id, input);

            return Ok(new Response<String>(false, null, "Successfully updated Reservation"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            ReservationResultDto entity = await _reservationService.GetById(id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<ReservationResultDto>(false, "", entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations([FromQuery] ReservationPaginationDto filters)
        {
            List<ReservationResultDto> reservations = (await _reservationService.GetAll(filters)).ToList();

            if (reservations == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<IEnumerable<ReservationResultDto>>(false, "", reservations));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            await _reservationService.Delete(id);

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }
    }
}
