using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class AnnouncementRepository: Repository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(BuildingManagerDbContext context) : base(context)
        {
        }
    }
}