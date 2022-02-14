using FluentValidation;
using GameTournament.Application.Posts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Posts.Validators
{
    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator()
        {
            RuleFor(v => v.PostGuid).NotEmpty();
        }
    }
}
