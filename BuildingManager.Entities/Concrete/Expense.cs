using System;
using System.ComponentModel.DataAnnotations;
using BuildingManager.Core.Entities;

namespace BuildingManager.Entities.Concrete
{
    public class Expense:IEntity
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int FlatId { get; set; }
        public Flat Flat { get; set; }

        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}