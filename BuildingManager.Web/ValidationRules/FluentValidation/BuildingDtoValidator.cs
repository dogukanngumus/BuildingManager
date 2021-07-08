using BuildingManager.Business.Dtos;
using BuildingManager.Web.ValidationRules.ValidationMessages;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class BuildingDtoValidator:AbstractValidator<BuildingDto>
    {
        public BuildingDtoValidator()
        {
            RuleFor(b => b.BuildingName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(b => b.BuildingName).MaximumLength(1).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(b => b.TotalFlat).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(b => b.TotalFlat).Must(x => x >= 1 && x <= 20).WithMessage(ConstantValidationMessages.TotalFlatMessage);
        }
        public override ValidationResult Validate(ValidationContext<BuildingDto> context)
        {
            return context == null 
                ? new ValidationResult(new [] { new ValidationFailure("BuildingDto", ConstantValidationMessages.NotNull) }) 
                : base.Validate(context);
        }
    }
}