using System.ComponentModel.DataAnnotations;

namespace AmadeusApi.Contracts
{
    public class RegisterRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty; // SOLUCIÓN: Usar 'Name'

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}