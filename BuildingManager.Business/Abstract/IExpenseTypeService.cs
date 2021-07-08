using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Business.Dtos;
using BuildingManager.Core.Utilities.Results;

namespace BuildingManager.Business.Abstract
{
    public interface IExpenseTypeService
    {
        Task<IDataResult<ExpenseTypeDto>> GetByIdAsync(int id);

        Task<IDataResult<List<ExpenseTypeDto>>> GetAllAsync();

        Task<IDataResult<ExpenseTypeDto>> AddAsync(ExpenseTypeDto expenseTypeDto);

        Task<IDataResult<List<ExpenseTypeDto>>> AddRangeAsync(List<ExpenseTypeDto> expenseTypeDtos);

        IResult Remove(int id);

        IResult RemoveRange(List<ExpenseTypeDto> expenseTypeDto);

        IDataResult<ExpenseTypeDto> Update(ExpenseTypeDto expenseTypeDto);
    }
}