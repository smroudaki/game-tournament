using FluentValidation;
using GameTournament.Application.Admins.Commands;
using GameTournament.Application.Common.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Admins.Validators
{
    public class ChangeUserStateCommandValidator : AbstractValidator<ChangeUserStateCommand>
    {
        public ChangeUserStateCommandValidator()
        {
            RuleFor(v => v.UserGuid).SetValidator(new GuidPropertyValidator());
            RuleFor(v => v.AccountState).SetValidator(new NotAnEmptyUndefinedEnumValidator());
        }
    }
}
