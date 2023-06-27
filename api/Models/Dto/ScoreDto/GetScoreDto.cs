namespace api.Models.Dto.ScoreDto;

public class GetScoreDto
{
    public int Id { get; set; }
    public DateTime DateOfCompletion { get; set; }
    public decimal PercentOfCorrectAnswers { get; set; }
    public int QuizId { get; set; }
    public int UserId { get; set; }
}