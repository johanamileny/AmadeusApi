using Amadeus.Models;
using Amadeus.Repositories;

public class UserService
{
    // Inyeccion de dependencias (Depende del repositorio)
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    // TODO Read
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetUserId(int id)
    {
        try
        {
            return await _userRepository.GetUserId(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<User> GetUserEmail(string email)
    {
        try
        {
            return await _userRepository.GetUserEmail(email);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<User> GetUserName(string full_name)
    {
        try
        {
            return await _userRepository.GetUserName(full_name);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    // TODO Create
    public async Task<User> CreateUser(User user)
    {
        // Si el usuario es menor a 18 no crear
        // if (user.age < 18)
        // {
        //     throw new Exception("User is under 18 years old");
        // }
        try
        {
            return await _userRepository.CreateUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    // TODO Update
    public async Task<User> UpdateUser(User user)
    {
        try
        {
            return await _userRepository.UpdateUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    // TODO Delete
    public async Task<User> DeleteUser(int id)
    {
        // Comprobar que exista
        var user = await _userRepository.GetUserId(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        try
        {
            return await _userRepository.DeleteUser(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}