using FluentValidation.Validators;
using GameTournament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Common.Validators
{
    public class NotAnEmptyUndefinedEnumValidator : PropertyValidator
    {
        public NotAnEmptyUndefinedEnumValidator()
            : base("Property {PropertyName} must not be empty.")
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null ||
                !Enum.IsDefined(typeof(Gender), context.PropertyValue))
            {
                return false;
            }

            return true;
        }
    }
}
