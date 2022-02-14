using FluentValidation;
using GameTournament.Application.ContactUsMessages.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.ContactUsMessages.Validators
{
    public class CreateContactUsMessageCommandValidator : AbstractValidator<CreateContactUsMessageCommand>
    {
        public CreateContactUsMessageCommandValidator()
        {
            RuleFor(v => v.FirstName).NotEmpty();
            RuleFor(v => v.LastName).NotEmpty();
            RuleFor(v => v.Email).NotEmpty();
            RuleFor(v => v.Message).NotEmpty();
        }
    }
}
