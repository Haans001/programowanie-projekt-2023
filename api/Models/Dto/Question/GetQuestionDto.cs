using api.Models.Dto.Answer;

namespace api.Models.Dto.Question;

public class GetQuestionDto
{
    public int Id { get; set; }
    public int Content { get; set; }
    public List<GetAnswerDto> AnswersDtos { get; set; }
}