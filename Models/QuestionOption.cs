using System.ComponentModel.DataAnnotations.Schema;

public class QuestionOption
{
    [Column("id")]
    public int Id { get; set; } // PK
    [Column("question_id")]
    public int QuestionId { get; set; } // FK
    [Column("description")]
    public string Description { get; set; } = string.Empty;
}
