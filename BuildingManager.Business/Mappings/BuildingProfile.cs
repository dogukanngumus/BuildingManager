using AutoMapper;
using BuildingManager.Business.Dtos;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Mappings
{
    public class BuildingProfile:Profile
    {
        public BuildingProfile()
        {
            CreateMap<BuildingDto, Building>().ReverseMap();
        }
    }
}