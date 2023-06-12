using api.Models.Dto.Question;
using FluentValidation;

namespace api.Models.Validators;

public class UpdateQuestionDtoValidator : AbstractValidator<UpdateQuestionDto>
{
    public UpdateQuestionDtoValidator()
    {
        RuleFor(a => a.Answer1).NotNull().NotEmpty();
        RuleFor(a => a.Answer2).NotNull().NotEmpty();
        RuleFor(a => a.Answer3).NotNull().NotEmpty();
        RuleFor(a => a.Answer4).NotNull().NotEmpty();
    }
}