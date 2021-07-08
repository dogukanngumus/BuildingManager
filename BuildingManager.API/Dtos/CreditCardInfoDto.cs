namespace BuildingManager.API.Dtos
{
    public class CreditCardInfoDto
    {
        public string Owner { get; set; }
        public string CardNumber { get; set; }
        public int ValidMonth { get; set; }
        public int ValidYear { get; set; }
        public int Cvv { get; set; }
        public decimal Balance { get; set; }
    }
}