using FluentValidation;
using GameTournament.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Validators
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(v => v.UserGuid).NotEmpty();
        }
    }
}
