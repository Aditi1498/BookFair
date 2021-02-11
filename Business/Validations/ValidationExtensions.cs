using FluentValidation.Results;
using Shared;
using System.Collections.Generic;

namespace Business.Validations
{
    public static class ValidationExtensions
    {
        public static CustomValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<CustomValidationFailure> errors = new List<CustomValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new CustomValidationResult(errors);
        }

        public static CustomValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new CustomValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }

    }
}
