using AmadeusApi.Contracts;
using AmadeusApi.Models;
using AmadeusApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmadeusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authService.LoginAsync(request);
            
            if (response == null)
            {
                return Unauthorized(new { message = "Email o contraseña incorrectos" });
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authService.RegisterAsync(request);
            
            if (response == null)
            {
                return BadRequest(new { message = "El usuario ya existe" });
            }

            return CreatedAtAction(nameof(Login), new { email = response.Email }, response);
        }
    }
}