
using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Models.Response;

namespace Restaurant.Web.Controllers
{
    [Route("/api/[controller]")]
    public class FoodsController:ControllerBase
    {
        public FoodsController()
        {

        }

        [HttpPost("/")]
        public async Task<IActionResult> Create()
        {
            return Ok(new Response<String>(false, "", new string(new char[] { 'a' })));
        }
        [HttpPut("/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            return Ok(new Response<String>(false, "", new string(new char[] { 'a' })));
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(new Response<String>(false, "", new string(new char[] { 'a' })));
        }
        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(new Response<String>(false, "", new string(new char[] { 'a' })));
        }
        [HttpGet("/getAllByCategory/{categoryId}")]
        public async Task<IActionResult> GetAllByCategory(string categoryId)
        {
            return Ok(new Response<String>(false, "", new string(new char[] { 'a' })));
        }
    }
}
