using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.DataAccess.Abstract
{
    public interface IExpenseRepository: IRepository<Expense>
    {
        Task<List<Expense>> GetExpensesWithRelations();
    }
}