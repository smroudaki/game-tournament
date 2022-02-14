using FluentValidation;
using GameTournament.Application.Categories.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Categories.Validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(v => v.Title).NotEmpty();
        }
    }
}
