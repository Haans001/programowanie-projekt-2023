namespace api.Models.Dto.Question;

public class CreateQuestionDto
{
    public string Content { get; set; }
    public string Answer1 { get; set; }
    public bool IsCorrect1 { get; set; }
    public string Answer2 { get; set; }
    public bool IsCorrect2 { get; set; }
    public string Answer3 { get; set; }
    public bool IsCorrect3 { get; set; }
    public string Answer4 { get; set; }
    public bool IsCorrect4 { get; set; }
}