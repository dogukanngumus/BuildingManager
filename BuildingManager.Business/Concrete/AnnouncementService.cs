using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Dtos;
using BuildingManager.Core.Utilities.Results;
using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.UnitOfWorks;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Concrete
{
    public class AnnouncementService:IAnnouncementService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IAnnouncementRepository _announcementRepository;

        public AnnouncementService(IMapper mapper, IUnitOfWork unitOfWork, IAnnouncementRepository announcementRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _announcementRepository = announcementRepository;
        }


        public async Task<IDataResult<AnnouncementDto>> GetByIdAsync(int id)
        {
            var announcementDto = _mapper.Map<AnnouncementDto>(await _unitOfWork.Announcements.GetByIdAsync(id));
            if (announcementDto != null)  return new SuccessDataResult<AnnouncementDto>(announcementDto);
            return new ErrorDataResult<AnnouncementDto>();
        }

        public async Task<IDataResult<List<AnnouncementDto>>> GetAllAsync()
        {
            var announcementDtos = _mapper.Map<List<AnnouncementDto>>(await _unitOfWork.Announcements.GetAllAsync());
            if (announcementDtos != null) return new SuccessDataResult<List<AnnouncementDto>>(announcementDtos);
            return new ErrorDataResult<List<AnnouncementDto>>();
        }

        public async Task<IDataResult<AnnouncementDto>> AddAsync(AnnouncementDto announcementDto)
        {
            var announcement = _mapper.Map<Announcement>(announcementDto);
            await _announcementRepository.AddAsync(announcement);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<AnnouncementDto>(announcementDto);
        }

        public async Task<IDataResult<List<AnnouncementDto>>> AddRangeAsync(List<AnnouncementDto> announcementDtos)
        {
            var announcements = _mapper.Map<List<Announcement>>(announcementDtos);
            await _announcementRepository.AddRangeAsync(announcements);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<List<AnnouncementDto>>(announcementDtos);
        }

        public IResult Remove(int id)
        {
            var announcement = _announcementRepository.GetByIdAsync(id).Result;
            _announcementRepository.Remove(announcement);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IResult RemoveRange(List<AnnouncementDto> announcementDtos)
        {
            var announcements = _mapper.Map<List<Announcement>>(announcementDtos);
            _announcementRepository.RemoveRange(announcements);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IDataResult<AnnouncementDto> Update(AnnouncementDto announcementDto)
        {
            var announcement = _mapper.Map<Announcement>(announcementDto);
            _announcementRepository.Update(announcement);
            _unitOfWork.Commit();
            return new SuccessDataResult<AnnouncementDto>(announcementDto);
        }
    }
}