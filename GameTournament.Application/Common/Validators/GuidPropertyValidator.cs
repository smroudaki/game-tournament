using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Common.Validators
{
    class GuidPropertyValidator : PropertyValidator
    {
        public GuidPropertyValidator()
            : base("Property {PropertyName} must be a guid type.")
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
            {
                return true;
            }

            var @string = context.PropertyValue.ToString();
            Guid.TryParse(@string, out Guid guid);
            return guid != Guid.Empty;
        }
    }
}
