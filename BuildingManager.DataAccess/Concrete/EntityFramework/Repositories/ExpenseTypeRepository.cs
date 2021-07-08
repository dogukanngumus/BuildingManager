using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class ExpenseTypeRepository: Repository<ExpenseType>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(BuildingManagerDbContext context) : base(context)
        {
        }
    }
}