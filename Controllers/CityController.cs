using AmadeusApi.Contracts;
using AmadeusApi.Models;
using AmadeusApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmadeusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<City>> GetCityByName(string name)
        {
            var city = await _cityService.GetCityByNameAsync(name);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<City>> CreateCity([FromBody] City city)
        {
            var createdCity = await _cityService.CreateCityAsync(city);
            return CreatedAtAction(nameof(GetCity), new { id = createdCity.Id }, createdCity);
        }
    }
}