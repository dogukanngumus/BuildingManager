using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Business.Dtos;
using BuildingManager.Core.Utilities.Results;

namespace BuildingManager.Business.Abstract
{
    public interface IFlatService
    {
        Task<IDataResult<FlatDto>> GetByIdAsync(int id);

        Task<IDataResult<List<FlatDto>>> GetAllAsync();

        Task<IDataResult<FlatCreateDto>> AddAsync(FlatCreateDto flatCreateDto);

        Task<IDataResult<List<FlatCreateDto>>> AddRangeAsync(List<FlatCreateDto> flatCreateDtos);

        IResult Remove(int id);

        IResult RemoveRange(List<FlatDto> flatDtos);

        IDataResult<FlatUpdateDto> Update(FlatUpdateDto flatUpdateDto);
        
        Task<IDataResult<List<FlatDto>>> GetAllFlatsByRelations();
    }
}