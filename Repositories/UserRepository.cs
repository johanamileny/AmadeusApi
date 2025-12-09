using AmadeusApi.Data;
using AmadeusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AmadeusApi.Repositories
{
    public class UserRepository
    {
        private readonly AmadeusDbContext _context;

        public UserRepository(AmadeusDbContext context)
        {
            _context = context;
        }

        // Llamado por UserService.GetAll
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        // Llamado por UserService.GetUserId
        public async Task<User?> GetUserId(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Llamado por UserService.GetUserEmail
        public async Task<User?> GetUserEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        // Llamado por UserService.GetUserName
        public Task<User?> GetUserName(string userName)
        {
            // Tu modelo no tiene UserName; devolvemos null sin romper compilación
            return Task.FromResult<User?>(null);
        }

        // Llamado por UserService.CreateUser
        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Llamado por UserService.UpdateUser
        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Llamado por UserService.DeleteUser
        public async Task<bool> DeleteUser(int id)
        {
            var u = await _context.Users.FindAsync(id);
            if (u == null) return false;
            _context.Users.Remove(u);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}