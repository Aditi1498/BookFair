using FluentValidation;
using Shared;

namespace Business.Validations
{
    public class SampleValidator : AbstractValidator<UserDTO>
    {
        public SampleValidator()
        {
            //SampleProperty2 value should be not be null or empty
            //RuleFor(dto => dto.BookTitle).NotNull().NotEmpty();

            //SampleProperty1 value should be greater than 10
            //RuleFor(dto => dto.UniqueID).GreaterThan(10);

            RuleSet("SignUpValidation", () =>
            {
                RuleFor(dto => dto.Password).Length(5,30);
                RuleFor(dto => dto.Password.Contains("(!@#$%^&*(),.?:{}|<>)"));
                
            });
        }
    }
}

