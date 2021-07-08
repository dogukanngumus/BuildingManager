using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Business.Dtos;
using BuildingManager.Core.Utilities.Results;

namespace BuildingManager.Business.Abstract
{
    public interface IMessageService
    {
        Task<IDataResult<MessageDto>> GetByIdAsync(int id);

        Task<IDataResult<List<MessageDto>>> GetAllAsync();

        Task<IDataResult<MessageDto>> AddAsync(MessageDto messageDto);

        Task<IDataResult<List<MessageDto>>> AddRangeAsync(List<MessageDto> messageDtos);

        IResult Remove(int id);

        IResult RemoveRange(List<MessageDto> messageDto);

        IDataResult<MessageDto> Update(MessageDto messageDto);
    }
}