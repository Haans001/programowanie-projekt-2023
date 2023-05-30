namespace api.Models.Entities;

public class Answer
{
    public int Id { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
    public virtual Question Question { get; set; }
    public int QuestionId { get; set; }
}