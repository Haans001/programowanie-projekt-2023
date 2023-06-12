using api.Models.Dto.Question;

namespace api.Models.Dto;

public class CreateQuizDto
{
    public string Name { get; set; }
    public int ClassId { get; set; }
    public List<CreateQuestionDto> Questions { get; set; }
}