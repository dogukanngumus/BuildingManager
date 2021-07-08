using AutoMapper;
using BuildingManager.Business.Dtos;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Mappings
{
    public class MessageProfile:Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageDto, Message>().ReverseMap();
        }
    }
}