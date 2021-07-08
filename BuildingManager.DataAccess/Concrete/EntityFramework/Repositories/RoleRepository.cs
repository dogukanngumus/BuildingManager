using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class RoleRepository:Repository<Role>,IRoleRepository
    {
        public RoleRepository(BuildingManagerDbContext context) : base(context)
        {
        }
    }
}