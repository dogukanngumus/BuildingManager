using BuildingManager.Business.Dtos;
using BuildingManager.Web.ValidationRules.ValidationMessages;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class ExpenseTypeDtoValidator:AbstractValidator<ExpenseTypeDto>
    {
        public ExpenseTypeDtoValidator()
        {
            RuleFor(e => e.ExpenseTypeName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(e => e.ExpenseTypeName).MaximumLength(50).WithMessage(ConstantValidationMessages.MaxLength);
        }
        public override ValidationResult Validate(ValidationContext<ExpenseTypeDto> context)
        {
            return context == null 
                ? new ValidationResult(new [] { new ValidationFailure("ExpenseTypeDto", ConstantValidationMessages.NotNull) }) 
                : base.Validate(context);
        }
    }
}