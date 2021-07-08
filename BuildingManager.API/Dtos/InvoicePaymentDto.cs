namespace BuildingManager.API.Dtos
{
    public class InvoicePaymentDto
    {
        public string Owner { get; set; }
        public string CardNumber { get; set; }
        public int ValidMonth { get; set; }
        public int ValidYear { get; set; }
        public int Cvv { get; set; }
        public int FlatId { get; set; }
        public int ExpenseId { get; set; }
        public decimal InvoiceAmount { get; set; }
    }
}