namespace BuildingManager.API.Validator.ValidationMessages
{
    public static class ConstantValidationMessages
    {
        public static string NotNull = "Lütfen bu alanı boş bırakmayınız.";
        public static string CreditCardError = "Kredi Kartı Numarası 16 haneden az olamaz";
        public static string CvvError = "Geçersiz CVV";
        public static string BetweenError = "Değer 1-12 arası olmalıdır";
        public static string YearError = "Geçersiz yıl";
    }
}