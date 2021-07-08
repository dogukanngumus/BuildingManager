using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;

using BuildingManager.Entities.Concrete;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(BuildingManagerDbContext context) : base(context)
        {
        }
    }
}