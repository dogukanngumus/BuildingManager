using AutoMapper;
using BuildingManager.Business.Dtos;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Mappings
{
    public class ExpenseTypeProfile:Profile 
    {
        public ExpenseTypeProfile()
        {
            CreateMap<ExpenseTypeDto,ExpenseType>().ReverseMap();
        }
    }
}