using api.DatabaseContext;
using api.Models.Dto;
using FluentValidation;

namespace api.Models.Validators;

public class LoginUserDtoValidator : AbstractValidator<LoginDto>
{
    public LoginUserDtoValidator(QuizDbContext Dbcontext)
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).MinimumLength(5);
    }
}