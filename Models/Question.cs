using System.ComponentModel.DataAnnotations;
using AmadeusApi.Models;


namespace AmadeusApi.Models;

public class Question
{
    public int Id { get; set; }

    [Required, MaxLength(500)]
    public string QuestionText { get; set; } = string.Empty;

    public int Order { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // navegación
    public ICollection<QuestionOption>? QuestionOptions { get; set; }
    public ICollection<Answer>? Answers { get; set; }
}
