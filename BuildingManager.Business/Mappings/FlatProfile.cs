using AutoMapper;
using BuildingManager.Business.Dtos;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Mappings
{
    public class FlatProfile:Profile
    {
        public FlatProfile()
        {
            CreateMap<FlatDto,Flat>().ReverseMap();
            CreateMap<FlatCreateDto,Flat>().ReverseMap();
            CreateMap<FlatUpdateDto,Flat>().ReverseMap();
        }
    }
}