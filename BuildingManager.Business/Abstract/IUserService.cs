using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingManager.Business.Dtos;
using BuildingManager.Core.Utilities.Results;
using BuildingManager.Entities.Concrete;

namespace BuildingManager.Business.Abstract
{
    public interface IUserService
    { 
        Task<IDataResult<List<UserDto>>> GetAllAsync();
        Task<IResult> CreateUserAsync(RegisterDto registerDto);
        Task<IResult> UpdateUserAsync(UserDto userDto);
        Task<IResult> AddToRole(RegisterDto registerDto, string role);
        Task<IDataResult<UserDto>> FindById(string id);
        Task<IDataResult<UserDto>> FindByName(string name);
        Task<IDataResult<UserDto>> FindByEmail(string email);
        User GetUserFromSession();
        IResult Remove(string id);
    }
}