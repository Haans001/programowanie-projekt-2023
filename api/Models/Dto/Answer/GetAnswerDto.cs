namespace api.Models.Dto.Answer;

public class GetAnswerDto
{
    public int id { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
}