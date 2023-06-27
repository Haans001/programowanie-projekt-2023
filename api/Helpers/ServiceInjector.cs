using api.Authorization;
using api.Middlewares;
using api.Models.Dto;
using api.Models.Dto.Account;
using api.Models.Dto.Class;
using api.Models.Dto.Question;
using api.Models.Entities;
using api.Models.Validators;
using api.Services;
using api.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace api.Helpers;

public static class ServiceInjector
{
    public static void Inject(this IServiceCollection collection)
    {
        collection.AddScoped<IQuestionService,QuestionService>();
        collection.AddScoped<IScoreService,ScoreService>();
        collection.AddScoped<IQuizService, QuizService>();
        
        collection.AddScoped<ErrorHandlingMiddleware>();

        collection.AddAutoMapper(typeof(Program).Assembly);
        collection.AddScoped<IClassService, ClassService>();

        collection.AddScoped<IUserContextService, UserContextService>();
        collection.AddHttpContextAccessor();
        collection.AddScoped<IAccountService,AccountService>();
        collection.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        #region Validators
        collection.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
        collection.AddScoped<IValidator<LoginDto>, LoginUserDtoValidator>();
        collection.AddScoped<IValidator<CreateClassDto>,CreateClassDtoValidator>();
        collection.AddScoped<IValidator<CreateQuestionDto>, CreateQuestionDtoValidator>();
        collection.AddScoped<IValidator<CreateQuizDto>,CreateQuizDtoValidator>();
        collection.AddScoped<IValidator<UpdateClassDto>, UpdateClassDtoValidator>();
        collection.AddScoped<IValidator<UpdateQuestionDto>, UpdateQuestionDtoValidator>();
        collection.AddScoped<IValidator<UpdateQuizDto>, UpdateQuizDtoValidator>();
        #endregion
        collection.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();

    }
}