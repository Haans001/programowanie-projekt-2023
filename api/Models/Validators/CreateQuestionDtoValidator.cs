using api.Models.Dto.Class;
using api.Models.Dto.Question;
using FluentValidation;

namespace api.Models.Validators;
 
public class CreateQuestionDtoValidator: AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionDtoValidator()
    {
        RuleFor(x=>x.Answer1).NotEmpty();
        RuleFor(x=>x.Answer2).NotEmpty();
        RuleFor(x=>x.Answer3).NotEmpty();
        RuleFor(x=>x.Answer4).NotEmpty();
        RuleFor(x => x.Content).NotEmpty();
    }
}