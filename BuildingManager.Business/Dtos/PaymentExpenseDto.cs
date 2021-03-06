using System;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Dtos
{
    public class PaymentExpenseDto
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string UserName { get; set; }
        public int FlatId { get; set; }
        public byte FlatNumber { get; set; }
        public string ExpenseTypeName { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
