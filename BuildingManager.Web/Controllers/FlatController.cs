using System.Threading.Tasks;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Dtos;
using Microsoft.AspNetCore.Mvc;
using BuildingManager.Web.Extensions;

namespace BuildingManager.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class FlatController : Controller
    {
        private IFlatService _flatService;
        private IBuildingService _buildingService;
        private IUserService _userService;

        public FlatController(IFlatService flatService, IBuildingService buildingService, IUserService userService)
        {
            _flatService = flatService;
            _buildingService = buildingService;
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var flats = await _flatService.GetAllFlatsByRelations();
            return View(flats.Data);
        }

        [HttpGet]
        public IActionResult DeleteFlat(int id)
        {
            _flatService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddFlat()
        {
            var buildingDto = await _buildingService.GetAllAsync();
            var userDto = await _userService.GetAllAsync();
            var flatCreateDto = new FlatCreateDto()
            {
                Buildings = buildingDto.Data,
                Users =  userDto.Data
            };
            return View(flatCreateDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlat(FlatCreateDto flatCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(flatCreateDto);
            }
            await _flatService.AddAsync(flatCreateDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFlat(int id)
        {
            var flat = await _flatService.GetByIdAsync(id);
            var buildingDto = await _buildingService.GetAllAsync();
            var userDto = await _userService.GetAllAsync();
            var flatUpdateDto = new FlatUpdateDto()
            {
                Id = flat.Data.Id,
                FlatNumber = flat.Data.FlatNumber,
                IsEmpty = flat.Data.IsEmpty,
                TypeOfFlat = flat.Data.TypeOfFlat,
                Building = buildingDto.Data,
                Users = userDto.Data
            };
            return View(flatUpdateDto);
        }

        [HttpPost]
        public IActionResult UpdateFlat(FlatUpdateDto flatUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(flatUpdateDto);
            }
            _flatService.Update(flatUpdateDto);
            return RedirectToAction("Index");
        }
        
    }
}