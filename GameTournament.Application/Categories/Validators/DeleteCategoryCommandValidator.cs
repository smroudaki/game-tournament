using FluentValidation;
using GameTournament.Application.Categories.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Categories.Validators
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(v => v.CategoryGuid).NotEmpty();
        }
    }
}
