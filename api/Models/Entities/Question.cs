namespace api.Models.Entities;

public class Question
{
    public int Id { get; set; }
    public string Contents { get; set; }
    public Quiz Quiz { get; set; }
    public int QuizId { get; set; }
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
}