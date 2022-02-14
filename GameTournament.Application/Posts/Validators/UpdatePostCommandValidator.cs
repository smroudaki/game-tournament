using FluentValidation;
using GameTournament.Application.Posts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Posts.Validators
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(v => v.PostGuid).NotEmpty();
            RuleFor(v => v.CoverImageGuid).NotEmpty();
            RuleFor(v => v.Title).NotEmpty();
            RuleFor(v => v.Abstract).NotEmpty();
            RuleFor(v => v.Description).NotEmpty();
        }
    }
}
