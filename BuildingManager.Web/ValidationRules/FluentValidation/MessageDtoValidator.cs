using BuildingManager.Business.Dtos;
using BuildingManager.Web.ValidationRules.ValidationMessages;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class MessageDtoValidator:AbstractValidator<MessageDto>
    {
        public MessageDtoValidator()
        {
            RuleFor(m => m.MessageContent).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(m => m.MessageContent).MaximumLength(1000).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(m => m.ReceiverEmail).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(m => m.ReceiverEmail).EmailAddress().WithMessage(ConstantValidationMessages.Email);
        }
        public override ValidationResult Validate(ValidationContext<MessageDto> context)
        {
            return context == null 
                ? new ValidationResult(new [] { new ValidationFailure("MessageDto", ConstantValidationMessages.NotNull) }) 
                : base.Validate(context);
        }
    }
}