using System.ComponentModel.DataAnnotations.Schema;

public class Answer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int QuestionId { get; set; }

    public int QuestionOptionId { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
}
