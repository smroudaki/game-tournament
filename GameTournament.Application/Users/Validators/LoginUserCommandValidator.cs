using FluentValidation;
using GameTournament.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Validators
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(v => v.PhoneNumber).NotEmpty();
        }
    }
}
