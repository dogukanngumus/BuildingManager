using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Business.Dtos;
using BuildingManager.Core.Utilities.Results;

namespace BuildingManager.Business.Abstract
{
    public interface IExpenseService
    {
        Task<IDataResult<ExpenseDto>> GetByIdAsync(int id);

        Task<IDataResult<List<ExpenseDto>>> GetAllAsync();

        Task<IDataResult<CreateExpenseDto>> AddAsync(CreateExpenseDto createExpenseDto);

        Task<IDataResult<List<CreateExpenseDto>>> AddRangeAsync(List<CreateExpenseDto> createExpenseDtos);

        Result Remove(int id);

        Result RemoveRange(List<ExpenseDto> expenseDto);

        IDataResult<UpdateExpenseDto> Update(UpdateExpenseDto updateExpenseDto);
        IDataResult<PaymentExpenseDto> UpdateForPayment(PaymentExpenseDto paymentExpenseDto);
        Task<IDataResult<PaymentExpenseDto>> GetByIdForPayment(int id);

        Task<IDataResult<List<ExpenseDto>>> GetExpensesWithRelations();
        Task<IResult> AddDebtMultiple(CreateExpenseDto createExpenseDto);
    }
}