using System;
using BuildingManager.API.Dtos;
using FluentValidation;

namespace BuildingManager.API.Validator
{
    public class CreditCardInfoValidator : AbstractValidator<CreditCardInfoDto>
    {
        public CreditCardInfoValidator()
        {
            RuleFor(x => x.Owner).NotEmpty().WithMessage("İsmi Boş geçemezsiniz");
            RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Kart numarası boş olamaz. ");
            RuleFor(x => x.CardNumber).Length(16).WithMessage("Kredi Kartı Numarası 16 haneden az olamaz");
            RuleFor(x => x.ValidMonth).NotEmpty().WithMessage("Lütfen Bir değer giriniz");
            RuleFor(x => x.ValidMonth).InclusiveBetween(1, 12).WithMessage("Değer 1-12 arası olmalıdır");
            RuleFor(x => x.ValidYear).NotEmpty().WithMessage("Lütfen Bir değer giriniz");
            RuleFor(x => x.ValidYear).InclusiveBetween(DateTime.Now.Year, 2100).WithMessage("Geçersiz yıl");
            RuleFor(x => x.Cvv).NotEmpty().WithMessage("Lütfen Bir değer giriniz");
            RuleFor(x => x.Cvv).Must(x => x >= 100 && x <= 999).WithMessage("Geçersiz CVV");
            RuleFor(x => x.Balance).NotEmpty().WithMessage("Bakiye Boş geçilemez");
            RuleFor(x => x.Balance).GreaterThan(0).WithMessage("Bakiye 0'dan az olamaz");

        }
    }
}