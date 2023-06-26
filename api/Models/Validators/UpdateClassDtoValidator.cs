using api.Models.Dto.Class;
using FluentValidation;

namespace api.Models.Validators;

public class UpdateClassDtoValidator : AbstractValidator<UpdateClassDto>
{
    public UpdateClassDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Description)
            .MaximumLength(250);
    }
}