using AmadeusApi.Models;
using AmadeusApi.Services;
using Microsoft.AspNetCore.Mvc;
using AmadeusApi.Contracts;

namespace AmadeusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new User
            {
                // SOLUCIÓN: Usamos 'Name' que ahora existe en ambos modelos.
                Name = request.Name, 
                Email = request.Email,
                // El servicio de autenticación debería hacer el hashing.
                PasswordHash = request.Password 
            };

            var createdUser = await _userService.CreateUser(newUser);
            
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        
        // GET: api/User/email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetUserEmail(string email)
        {
            var user = await _userService.GetUserEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // SOLUCIÓN: Corregimos el nombre del método y el manejo de nulos.
        // GET: api/User/name/{name}
        [HttpGet("name/{name}")]
        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            // Llamamos al método correcto: GetUserByName
            var user = await _userService.GetUserByName(name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        // TODO Update
        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<User> UpdateUser(User user)
        {
            return await _userService.UpdateUser(user);
        }


        // TODO Delete
        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var deletedUser = await _userService.DeleteUser(id);
            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok(deletedUser);
        }
    }
}