using BuildingManager.Business.Dtos;
using BuildingManager.Web.ValidationRules.ValidationMessages;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class AnnouncementDtoValidator:AbstractValidator<AnnouncementDto>
    {
        public AnnouncementDtoValidator()
        {
            RuleFor(a => a.AnnouncementText).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(a => a.AnnouncementText).MaximumLength(1000).WithMessage(ConstantValidationMessages.MaxLength);
        }
        
        public override ValidationResult Validate(ValidationContext<AnnouncementDto> context)
        {
            return context == null 
                ? new ValidationResult(new [] { new ValidationFailure("AnnouncementDto", ConstantValidationMessages.NotNull) }) 
                : base.Validate(context);
        }
    }
}