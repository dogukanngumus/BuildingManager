using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Dtos;
using BuildingManager.Core.Utilities.Results;
using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.UnitOfWorks;
using BuildingManager.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BuildingManager.Business.Concrete
{
    public class UserService:IUserService
    {
        private IMapper _mapper;
        private IUserRepository _userRepository;
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;
        private IUnitOfWork _unitOfWork;
        private IHttpContextAccessor _httpContextAccessor;

        public UserService(IMapper mapper, UserManager<User> userManager, IUserRepository userRepository,
            IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, RoleManager<Role> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _roleManager = roleManager;
        }

        public async Task<IDataResult<List<UserDto>>> GetAllAsync()
        {
            var userList = _mapper.Map<List<UserDto>>(await _userRepository.GetAllAsync());
            if (userList != null) return new SuccessDataResult<List<UserDto>>(userList);
            return new ErrorDataResult<List<UserDto>>();
        }

        public async Task<IResult> CreateUserAsync(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            var result = await _userManager.CreateAsync(user,registerDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user,"User");
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IResult> UpdateUserAsync(UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.UserName = userDto.UserName;
            user.IdentificationNumber = userDto.IdentificationNumber;
            user.CarLicensePlate = userDto.CarLicensePlate;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return new SuccessResult();
            return new ErrorResult();
        }

        public async Task<IResult> AddToRole(RegisterDto registerDto, string role)
        {
            var user = _mapper.Map<User>(registerDto);
            var result = await _userManager.AddToRoleAsync(user,role);
            if (result.Succeeded) return new SuccessResult();
            return new ErrorResult();
        }

        public async Task<IDataResult<UserDto>> FindById(string id)
        {
          var user = await _userManager.FindByIdAsync(id); 
          if (user != null)  return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(user));
          return new ErrorDataResult<UserDto>();
        }

        public async Task<IDataResult<UserDto>> FindByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user != null) return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(user));
            return new ErrorDataResult<UserDto>();
        }

        public async Task<IDataResult<UserDto>> FindByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null) return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(user));
            return new ErrorDataResult<UserDto>();
        }

        public User GetUserFromSession()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user =  _userManager.FindByNameAsync(userName).Result;
            return user;
        }

        public IResult Remove(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            _userRepository.Remove(user);
            _unitOfWork.Commit();
            return new SuccessResult();
        }
    }
}