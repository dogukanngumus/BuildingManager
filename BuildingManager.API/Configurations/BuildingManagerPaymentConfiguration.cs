namespace BuildingManager.API.Configurations
{
    public class BuildingManagerPaymentConfiguration
    {
        public string DbName { get; set; }
        public string ConnectionString { get; set; }
        public string InvoicePaymentCollection { get; set; }
        public string CreditCardInfoCollection{ get; set; }
    }
}