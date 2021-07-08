using BuildingManager.Business.Dtos;
using BuildingManager.Web.ValidationRules.ValidationMessages;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class LoginDtoValidator:AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage(ConstantValidationMessages.Email);
            RuleFor(u => u.Email).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.Password).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
        }

        public override ValidationResult Validate(ValidationContext<LoginDto> context)
        {
            return context == null 
                ? new ValidationResult(new [] { new ValidationFailure("LoginDto", ConstantValidationMessages.NotNull) }) 
                : base.Validate(context);
        }
    }
}