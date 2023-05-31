using api.DatabaseContext;
using api.Models.Dto;
using FluentValidation;

namespace api.Models.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator(QuizDbContext Dbcontext)
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).MinimumLength(5);
        RuleFor(x=>x.ConfirmPassword).Equal(x=>x.Password);
        RuleFor(x=>x.Email).Custom((value,context)=>
        {
            var emailInUse = Dbcontext.Users.Any(u => u.Email == value);
            if (emailInUse)
            {
                context.AddFailure("Email","That email is taken");
            }
        });
    }
}