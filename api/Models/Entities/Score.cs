namespace api.Models.Entities;

public class Score
{
    public int Id { get; set; }
    public DateTime DateOfCompletion { get; set; }
    public int PercentOfCorrectAnswers { get; set; }
    public virtual Quiz Quiz { get; set; }
    public int QuizId { get; set; }
    public virtual User User { get; set; }
    public int? UserId { get; set; }
}  