using System.Collections.Generic;
using BuildingManager.Core.Entities;

namespace BuildingManager.Entities.Concrete
{
    public class ExpenseType:IEntity
    {
        public int Id { get; set; }

        public string ExpenseTypeName { get; set; } 

        public List<Expense> Expenses { get; set; }
    }
}