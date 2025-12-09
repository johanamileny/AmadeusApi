using System.ComponentModel.DataAnnotations;

namespace AmadeusApi.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;


        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = "User"; // Valor por defecto "User"

        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        // Navegación si es necesaria
        public ICollection<Answer>? Answers { get; set; }
    }
}

