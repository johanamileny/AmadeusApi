using Amadeus.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amadeus.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // Inyeccion de dependencias (Depende del servicio)
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }


    // TODO Read
    // GET: api/User
    [HttpGet]
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userService.GetAll();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<User> GetUserId(int id)
    {
        return await _userService.GetUserId(id);
    }

    // GET: api/User/email
    [HttpGet("email/{email}")]
    public async Task<User> GetUserEmail(string email)
    {
        return await _userService.GetUserEmail(email);
    }

    // GET: api/User/full_name
    [HttpGet("full_name/{full_name}")]
    public async Task<User> GetUserName(string full_name)
    {
        return await _userService.GetUserName(full_name);
    }


    // TODO Create
    // POST: api/User
    [HttpPost]
    public async Task<User> CreateUser(User user)
    {
        return await _userService.CreateUser(user);
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
    public async Task<User> DeleteUser(int id)
    {
        return await _userService.DeleteUser(id);
    }
}