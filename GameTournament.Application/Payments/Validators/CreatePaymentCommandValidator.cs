using FluentValidation;
using GameTournament.Application.Payments.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Payments.Validators
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(v => v.UserGuid).NotEmpty();
            //RuleFor(v => v.RealAmount).NotEmpty();
            //RuleFor(v => v.PayAmount).NotEmpty();
        }
    }
}
