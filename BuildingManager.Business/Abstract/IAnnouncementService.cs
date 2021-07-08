using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Business.Dtos;
using BuildingManager.Core.Utilities.Results;

namespace BuildingManager.Business.Abstract
{
    public interface IAnnouncementService
    {
        Task<IDataResult<AnnouncementDto>> GetByIdAsync(int id);

        Task<IDataResult<List<AnnouncementDto>>> GetAllAsync();

        Task<IDataResult<AnnouncementDto>> AddAsync(AnnouncementDto announcementDto);

        Task<IDataResult<List<AnnouncementDto>>> AddRangeAsync(List<AnnouncementDto> announcementDtos);

        IResult Remove(int id);

        IResult RemoveRange(List<AnnouncementDto> announcementDto);

        IDataResult<AnnouncementDto> Update(AnnouncementDto announcementDto);
    }
}