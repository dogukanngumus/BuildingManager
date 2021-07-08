using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.DataAccess.Abstract
{
    public interface IFlatRepository: IRepository<Flat>
    {
        Task<List<Flat>> GetAllFlatsByRelations();
    }
}