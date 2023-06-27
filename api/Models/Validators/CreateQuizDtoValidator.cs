using System.Data;
using api.Models.Dto;
using FluentValidation;

namespace api.Models.Validators;

public class CreateQuizDtoValidator : AbstractValidator<CreateQuizDto>
{
    public CreateQuizDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}