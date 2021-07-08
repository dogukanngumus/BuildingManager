using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingManager.Business.Dtos
{
    public class UpdateExpenseDto
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int ExpenseTypeId { get; set; }
        public int FlatId { get; set; }
        public string ExpenseTypeName { get; set; }

        public byte FlatNumber { get; set; }
        public IEnumerable<ExpenseTypeDto> ExpenseTypes { get; set; }
        public IEnumerable<FlatDto> Flats { get; set; }
    }
}