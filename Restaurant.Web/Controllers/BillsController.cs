﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.FoodBills;
using Restaurant.Mapping.Models.Bills;
using Restaurant.Web.Controllers.Common;
using Restaurant.Web.Models.Response;
using Restaurant.Services.Bills;

namespace Restaurant.Web.Controllers
{
    public class BillsController : BaseController
    {
        private readonly IFoodBillService _foodBillService;
        private readonly IBillService _billService;

        public BillsController(IFoodBillService foodBillService, IBillService billService)
        {
            _foodBillService = foodBillService;
            _billService = billService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] BillCreateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            await _billService.Create(input);

            return Ok(new Response<String>(false, null, "Successfully created Bill"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillById(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            BillResultDto result = await _billService.GetById(id);

            return Ok(new Response<BillResultDto>(false, "", result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] BillUpdateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<string>(true, "Invalid data provided", "Invalid data provided"));
            }

            input.Id = id;

            await _billService.Update(id, input);

            return Ok(new Response<string>(false, "", "Succesfully update bill"));
        }

        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            List<BillResultDto> result = (await _billService.GetAll()).ToList();

            return Ok(new Response<IEnumerable<BillResultDto>>(false, "", result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest(new Response<string>(true, "Id should not be null", null));
            }

            await _billService.Delete(id);

            return Ok(new Response<String>(false, "", $"Deleted entity with id:{id}"));
        }

    }
}
