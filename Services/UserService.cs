using AmadeusApi.Models;
using AmadeusApi.Repositories;

namespace AmadeusApi.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetAll() => _userRepository.GetAll();
        public Task<User?> GetUserId(int id) => _userRepository.GetUserId(id);
        public Task<User?> GetUserEmail(string email) => _userRepository.GetUserEmail(email);
        public Task<User?> GetUserByName(string name) => _userRepository.GetUserByName(name);
        public Task<User> CreateUser(User user) => _userRepository.CreateUser(user);
        public Task<User> UpdateUser(User user) => _userRepository.UpdateUser(user);

        // Devuelve el usuario eliminado (o null) en lugar de Task<bool>
        public async Task<User?> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserId(id);
            var ok = await _userRepository.DeleteUser(id);
            return ok ? user : null;
        }
    }
}