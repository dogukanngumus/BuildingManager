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
    public class MessageService:IMessageService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IMessageRepository _messageRepository;

        public MessageService(IMapper mapper, IUnitOfWork unitOfWork, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
        }
        
        public async Task<IDataResult<MessageDto>> GetByIdAsync(int id)
        {
            var messageDto = _mapper.Map<MessageDto>(await _unitOfWork.Messages.GetByIdAsync(id));
            if (messageDto != null)  return new SuccessDataResult<MessageDto>(messageDto);
            return new ErrorDataResult<MessageDto>();
        }

        public async Task<IDataResult<List<MessageDto>>> GetAllAsync()
        {
            var messageDtos = _mapper.Map<List<MessageDto>>(await _unitOfWork.Messages.GetAllAsync());
            if (messageDtos != null) return new SuccessDataResult<List<MessageDto>>(messageDtos);
            return new ErrorDataResult<List<MessageDto>>();
        }

        public async Task<IDataResult<MessageDto>> AddAsync(MessageDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            await _messageRepository.AddAsync(message);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<MessageDto>(messageDto);
        }

        public async Task<IDataResult<List<MessageDto>>> AddRangeAsync(List<MessageDto> messageDtos)
        {
            var message = _mapper.Map<List<Message>>(messageDtos);
            await _messageRepository.AddRangeAsync(message);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<List<MessageDto>>(messageDtos);
        }

        public IResult Remove(int id)
        {
            var message = _messageRepository.GetByIdAsync(id).Result;
            _messageRepository.Remove(message);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IResult RemoveRange(List<MessageDto> messageDtos)
        {
            var messages = _mapper.Map<List<Message>>(messageDtos);
            _messageRepository.RemoveRange(messages);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IDataResult<MessageDto> Update(MessageDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            _messageRepository.Update(message);
            _unitOfWork.Commit();
            return new SuccessDataResult<MessageDto>(messageDto);
        }
    }
}