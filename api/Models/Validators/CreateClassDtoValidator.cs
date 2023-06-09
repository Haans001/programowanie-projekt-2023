﻿using api.Models.Dto.Class;
using FluentValidation;

namespace api.Models.Validators;

public class CreateClassDtoValidator : AbstractValidator<CreateClassDto>
{
    public CreateClassDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}