using System.Threading.Tasks;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Dtos;
using BuildingManager.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }
            await _userService.CreateUserAsync(registerDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _userService.GetAllAsync();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult DeleteUser(string id)
        {
            _userService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await _userService.FindById(id);
            return View(user.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }
            await _userService.UpdateUserAsync(userDto);
            return RedirectToAction("Index");
        }
    }
}