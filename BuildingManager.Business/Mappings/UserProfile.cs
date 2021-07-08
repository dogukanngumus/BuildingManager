using AutoMapper;
using BuildingManager.Business.Dtos;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Mappings
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto,User>().ReverseMap();
            CreateMap<RegisterDto,User>().ReverseMap();
            CreateMap<LoginDto,User>().ReverseMap();
        }
    }
}