using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;
using BuildingManager.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class FlatRepository: Repository<Flat>, IFlatRepository
    {
        public FlatRepository(BuildingManagerDbContext context) : base(context)
        {
        }

        public async Task<List<Flat>> GetAllFlatsByRelations()
        {
            return  await _context.Flats
                .Include(x=>x.User)
                .Include(x=>x.Building)
                .OrderBy(x=>x.FlatNumber)
                .ToListAsync();
        }
    }
}