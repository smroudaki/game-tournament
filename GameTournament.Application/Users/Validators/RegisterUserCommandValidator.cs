using FluentValidation;
using GameTournament.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(v => v.FirstName).NotEmpty();
            RuleFor(v => v.LastName).NotEmpty();
            RuleFor(v => v.PhoneNumber).NotEmpty();
        }
    }
}
