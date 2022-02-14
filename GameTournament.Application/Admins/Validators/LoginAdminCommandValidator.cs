using FluentValidation;
using GameTournament.Application.Admins.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Admins.Validators
{
    public class LoginAdminCommandValidator : AbstractValidator<LoginAdminCommand>
    {
        public LoginAdminCommandValidator()
        {
            RuleFor(v => v.PhoneNumber).NotEmpty();
        }
    }
}
