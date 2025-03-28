using AMADEUSAPI.Contracts;
using AMADEUSAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMADEUSAPI.Controllers {
    [Route("api/cities")]
    [ApiController]
    
    public class CityController : ControllerBase
    {
        private readonly CityService _service;

        public CityController(CityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllCities());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetCityById(id));
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create([FromBody] CreateCityRequest request)
        {
            await _service.CreateCity(request.Description);
            return Ok(new { message = "City created successfully" });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] City city)
        {
            if (id != city.Id)
            {
                return BadRequest("The ID in the URL does not match the ID in the request body.");
            }

            try
            {
                await _service.UpdateCity(city);
                return NoContent(); // 204 status code (Successful update with no response content)
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                await _service.DeleteCity(id);
                return NoContent(); // 204 status code (Successful update with no response content)
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}