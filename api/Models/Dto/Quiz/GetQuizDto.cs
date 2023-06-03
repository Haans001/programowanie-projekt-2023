using api.Models.Dto.Account;
using api.Models.Dto.Class;
using api.Models.Dto.Question;

namespace api.Models.Dto;

public class GetQuizDto
{
    public int Id { get; set; }   
    public string Name { get; set; }
    public DateTime DateOfCreation { get; set; }
    public bool isOpen { get; set; }
    public List<GetQuestionDto> Questions { get; set; }
    public GetAccountDto User { get; set; }
    public int UserId { get; set; }
    public GetClassDto Class { get; set; }
    public int ClassId { get; set; }
}