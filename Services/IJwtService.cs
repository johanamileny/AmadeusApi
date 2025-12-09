using AmadeusApi.Models;

namespace AmadeusApi.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
    }
}