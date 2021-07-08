using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;
using BuildingManager.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(BuildingManagerDbContext context) : base(context)
        {
        }

        public async Task<List<Expense>> GetExpensesWithRelations()
        {
            return await _context.Expenses
                .Include(x => x.ExpenseType)
                .Include(x => x.Flat)
                .ThenInclude(x => x.User).ToListAsync();
        }
    }
}