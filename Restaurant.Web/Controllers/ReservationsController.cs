﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Common.Persistance;
using Restaurant.Data.Entities.Reservations;
using Restaurant.Services.Loggers;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Request.Reservations;
using Restaurant.Web.Models.Response;

namespace Restaurant.Web.Controllers
{
    public class ReservationsController: BaseController
    {
        public ReservationsController(IUnitOfWork unitOfWork,ILoggingService loggingService, IMapper mapper) : base(unitOfWork, loggingService, mapper)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ReservationCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Reservation entity = _mapper.Map<Reservation>(input);

            await _unitOfWork.Reservations.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, null, "Successfully created Reservation"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ReservationUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            Reservation entity = _mapper.Map<Reservation>(input);

            input.Id = id;

            _unitOfWork.Reservations.Update(id, entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, null, "Successfully updated Reservation"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Reservation entity = await _unitOfWork.Reservations.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<Reservation>(false, "", entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            List<Reservation> reservations = (await _unitOfWork.Reservations.GetAll()).ToList();

            if (reservations == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            return Ok(new Response<IEnumerable<Reservation>>(false, "", reservations));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            Reservation entity = await _unitOfWork.Reservations.GetBy(x => x.Id == id);

            if (entity == null)
            {
                return BadRequest(new Response<string>(true, "Could not find record", null));
            }

            _unitOfWork.Reservations.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }
    }
}
