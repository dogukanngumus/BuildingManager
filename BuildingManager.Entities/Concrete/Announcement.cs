using BuildingManager.Core.Entities;

namespace BuildingManager.Entities.Concrete
{
    public class Announcement:IEntity
    {
        public int Id { get; set; }
        public string AnnouncementText { get; set; }
    }
}