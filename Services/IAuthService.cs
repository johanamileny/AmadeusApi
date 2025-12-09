using AmadeusApi.Contracts;
using AmadeusApi.Models;

namespace AmadeusApi.Services
{
    public interface IAuthService
    {
        Task<AuthResponse?> LoginAsync(LoginRequest request);
        Task<AuthResponse?> RegisterAsync(RegisterRequest request);
    }
}