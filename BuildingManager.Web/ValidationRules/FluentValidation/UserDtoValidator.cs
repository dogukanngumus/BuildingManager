using BuildingManager.Business.Dtos;
using BuildingManager.Web.ValidationRules.ValidationMessages;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class UserDtoValidator:AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.FirstName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.FirstName).MaximumLength(200).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(u => u.LastName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.LastName).MaximumLength(200).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(u => u.UserName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.UserName).MaximumLength(200).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(u => u.Email).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.Email).EmailAddress().WithMessage(ConstantValidationMessages.Email);
            RuleFor(u => u.IdentificationNumber).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.IdentificationNumber).MaximumLength(11).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(u => u.CarLicensePlate).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(u => u.CarLicensePlate).MaximumLength(20).WithMessage(ConstantValidationMessages.MaxLength);
        }
        public override ValidationResult Validate(ValidationContext<UserDto> context)
        {
            return context == null 
                ? new ValidationResult(new [] { new ValidationFailure("UserDto", ConstantValidationMessages.NotNull) }) 
                : base.Validate(context);
        }
    }
}