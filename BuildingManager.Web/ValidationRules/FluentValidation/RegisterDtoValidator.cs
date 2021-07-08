using BuildingManager.Business.Dtos;
using BuildingManager.Web.ValidationRules.ValidationMessages;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.FirstName).MaximumLength(200).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(u => u.LastName).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.LastName).MaximumLength(200).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(u => u.UserName).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.UserName).MaximumLength(200).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(u => u.Email).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.Email).EmailAddress().WithMessage(ConstantValidationMessages.Email);
            RuleFor(u => u.IdentificationNumber).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.IdentificationNumber).MaximumLength(11).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(u => u.CarLicensePlate).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.CarLicensePlate).MaximumLength(20).WithMessage(ConstantValidationMessages.MaxLength);
        }
        public override ValidationResult Validate(ValidationContext<RegisterDto> context)
        {
            return context == null 
                ? new ValidationResult(new [] { new ValidationFailure("RegisterDto", ConstantValidationMessages.NotNull) }) 
                : base.Validate(context);
        }
    }
}