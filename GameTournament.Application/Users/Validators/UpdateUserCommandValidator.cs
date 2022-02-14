using FluentValidation;
using GameTournament.Application.Common.Validators;
using GameTournament.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.UserGuid).SetValidator(new GuidPropertyValidator());
            RuleFor(v => v.ProfileImageGuid).SetValidator(new GuidPropertyValidator());
            RuleFor(v => v.ProvinceGuid).SetValidator(new GuidPropertyValidator());
            RuleFor(v => v.FirstName).NotEmpty();
            RuleFor(v => v.LastName).NotEmpty();
            RuleFor(v => v.LatinFirstName).NotEmpty();
            RuleFor(v => v.LatinLastName).NotEmpty();
            RuleFor(v => v.NickName).NotEmpty();
            RuleFor(v => v.Gender).SetValidator(new NotAnEmptyUndefinedEnumValidator());
            RuleFor(v => v.Birthday).NotEmpty();
            RuleFor(v => v.Email).NotEmpty();
            RuleFor(v => v.Telephone).NotEmpty();
            RuleFor(v => v.ActivitiesGuids).SetValidator(new NotAnEmptyListPropertyValidator<Guid>());
            RuleFor(v => v.ActivitiesStartYear).NotEmpty();
        }
    }
}
