using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Business.Dtos;
using BuildingManager.Core.Utilities.Results;

namespace BuildingManager.Business.Abstract
{
    public interface IBuildingService
    {
        Task<IDataResult<BuildingDto>> GetByIdAsync(int id);

        Task<IDataResult<List<BuildingDto>>> GetAllAsync();

        Task<IDataResult<BuildingDto>> AddAsync(BuildingDto buildingDto);

        Task<IDataResult<List<BuildingDto>>> AddRangeAsync(List<BuildingDto> buildingDtos);

        IResult Remove(int id);

        IResult RemoveRange(List<BuildingDto> buildingDto);

        IDataResult<BuildingDto> Update(BuildingDto buildingDto);
    }
}