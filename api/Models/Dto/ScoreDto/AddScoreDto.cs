namespace api.Models.Dto.ScoreDto;

public class AddScoreDto
{
    public decimal PercentOfCorrectAnswers { get; set; }
    public int QuizId { get; set; }
}