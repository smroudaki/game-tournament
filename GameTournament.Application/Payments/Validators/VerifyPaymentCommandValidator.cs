using FluentValidation;
using GameTournament.Application.Payments.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Payments.Validators
{
    public class VerifyPaymentCommandValidator : AbstractValidator<VerifyPaymentCommand>
    {
        public VerifyPaymentCommandValidator()
        {
            RuleFor(v => v.PaymentGuid).NotEmpty();
            RuleFor(v => v.Authority).NotEmpty();
        }
    }
}
