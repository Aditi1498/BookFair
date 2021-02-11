using FluentValidation;
using Shared;

namespace Business.Validations
{
    public static class Validator<T, T1> where T : AbstractValidator<T1>, new()
    {
        public static CustomValidationResult Validate(T1 dto)
        {
            T validator = new T();
            return validator.Validate(dto).ToValidationResult();
        }

        public static CustomValidationResult Validate(T1 dto, string ruleSet)
        {
            T validator = new T();
            return validator.Validate(dto, ruleSet: ruleSet).ToValidationResult();
        }
    }
}

