using System.ComponentModel.DataAnnotations.Schema;

public class Answer
{
    [Column("id")]  // Asegura que coincida con la base de datos
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("question_id")]
    public int QuestionId { get; set; }

    [Column("question_option_id")]
    public int QuestionOptionId { get; set; }

    [Column("date")]
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
