using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class BuildingRepository: Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(BuildingManagerDbContext context) : base(context)
        {
        }
    }
}