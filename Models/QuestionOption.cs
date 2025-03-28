using System.ComponentModel.DataAnnotations.Schema;

public class QuestionOption
{
    public int Id { get; set; } // PK
    public int QuestionId { get; set; } // FK
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image {get; set;} = string.Empty;
}
