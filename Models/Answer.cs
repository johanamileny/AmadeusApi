using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmadeusApi.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int QuestionOptionId { get; set; }

        public DateTime AnsweredAt { get; set; } = DateTime.UtcNow;
        public string? UserAgent { get; set; }
        public string? IpAddress { get; set; }
        public int? SessionId { get; set; }

        // navegación
        public User User { get; set; } = null!;
        public Question Question { get; set; } = null!;
        public QuestionOption QuestionOption { get; set; } = null!;
    }
}
