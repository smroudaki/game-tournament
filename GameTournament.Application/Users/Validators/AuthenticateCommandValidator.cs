using FluentValidation;
using GameTournament.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Validators
{
    public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator()
        {
            RuleFor(v => v.PhoneNumber).NotEmpty();
            RuleFor(v => v.Token).NotEmpty();
            RuleFor(v => v.RememberMe).NotEmpty();
        }
    }
}
