using System;
using BuildingManager.API.Dtos;
using BuildingManager.API.Validator.ValidationMessages;
using FluentValidation;

namespace BuildingManager.API.Validator
{
    
        public class CreateInvoicePaymentValidator : AbstractValidator<InvoicePaymentDto>
        {
            public CreateInvoicePaymentValidator()
            {
                RuleFor(x => x.Owner).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
                RuleFor(x => x.CardNumber).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
                RuleFor(x => x.CardNumber).Length(16).WithMessage(ConstantValidationMessages.CreditCardError);
                RuleFor(x => x.ValidMonth).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
                RuleFor(x => x.ValidMonth).InclusiveBetween(1, 12).WithMessage(ConstantValidationMessages.BetweenError);
                RuleFor(x => x.ValidYear).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
                RuleFor(x => x.ValidYear).InclusiveBetween(DateTime.Now.Year, 2100).WithMessage(ConstantValidationMessages.YearError);
                RuleFor(x => x.Cvv).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
                RuleFor(x => x.Cvv).Must(x => x >= 100 && x <= 999).WithMessage(ConstantValidationMessages.CvvError);
                RuleFor(x => x.FlatId).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
                RuleFor(x => x.ExpenseId).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
                RuleFor(x => x.InvoiceAmount).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
                RuleFor(x => x.InvoiceAmount).GreaterThan(0);
            }
        }
    }
