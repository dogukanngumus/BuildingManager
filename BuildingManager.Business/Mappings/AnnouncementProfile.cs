using AutoMapper;
using BuildingManager.Business.Dtos;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Mappings
{
    public class AnnouncementProfile:Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<AnnouncementDto, Announcement>().ReverseMap();
        }
    }
}