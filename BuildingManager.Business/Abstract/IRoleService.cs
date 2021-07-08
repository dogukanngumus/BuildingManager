using System.Threading.Tasks;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Abstract
{
    public interface IRoleService
    {
        Task<Role> AddRole();
        Task<Role> DeleteRole();
        Task<Role> UpdateRole();
    }
}