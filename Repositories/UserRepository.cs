using Amadeus.Models;
using Microsoft.EntityFrameworkCore;

namespace Amadeus.Repositories;

public class UserRepository
{
    // Inyeccion de dependencias (Depende del contexto de la base de datos)
    private readonly AmadeusDbContext _context;

    public UserRepository(AmadeusDbContext context)
    {
        _context = context;
    }

    // TODO Read
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserId(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> GetUserEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.email == email);
    }

    public async Task<User> GetUserName(string full_name)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.full_name.Contains(full_name));
    }


    // TODO Create
    public async Task<User> CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }


    // TODO Update
    public async Task<User> UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }


    // TODO Delete
    public async Task<User> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
}