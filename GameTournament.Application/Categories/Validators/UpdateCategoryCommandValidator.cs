using FluentValidation;
using GameTournament.Application.Categories.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Categories.Validators
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(v => v.CategoryGuid).NotEmpty();
            RuleFor(v => v.Title).NotEmpty();
        }
    }
}
