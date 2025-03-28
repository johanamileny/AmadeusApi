using AMADEUSAPI.Models;
using AMADEUSAPI.Services;
using Microsoft.AspNetCore.Mvc;
using AMADEUSAPI.Contracts;


namespace AMADEUSAPI.Controllers
{
    [Route("api/destinations")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationController(IDestinationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllDestinations());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetDestinationById(id));
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create([FromBody] CreateDestinationRequest request)
        {
            await _service.CreateDestination(request.QuestionOptionIds, request.FirstCityId, request.SecondCityId);
            return Ok(new { message = "Destination created successfully" });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateDestination(int id, [FromBody] Destination destination)
        {
            if (id != destination.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo de la solicitud.");
            }

            try
            {
                await _service.UpdateDestination(destination);
                return NoContent(); // Código 204 (Actualización exitosa sin contenido de respuesta)
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            try
            {
                await _service.DeleteDestination(id);
                return NoContent(); // Código 204 (Eliminación exitosa sin contenido de respuesta)
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}