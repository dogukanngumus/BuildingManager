using System.ComponentModel.DataAnnotations;

namespace BuildingManager.Business.Dtos
{
    public class ExpenseTypeDto
    {
        public int Id { get; set; }
        public string ExpenseTypeName { get; set; }
    }
}