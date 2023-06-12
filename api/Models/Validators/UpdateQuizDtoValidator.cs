using api.Models.Dto;
using FluentValidation;

namespace api.Models.Validators;

public class UpdateQuizDtoValidator : AbstractValidator<UpdateQuizDto>
{
    public UpdateQuizDtoValidator()
    { 
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
        
    }
}