using AutoMapper;
using BuildingManager.Business.Dtos;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Mappings
{
    public class ExpenseProfile:Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseDto,Expense>().ReverseMap();
            CreateMap<CreateExpenseDto,Expense>().ReverseMap();
            CreateMap<UpdateExpenseDto,Expense>().ReverseMap();
            CreateMap<PaymentExpenseDto, Expense>().ReverseMap();
        }
    }
}