using System.Threading.Tasks;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Dtos;
using BuildingManager.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class BuildingController : Controller
    {
        private IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var buildings = await _buildingService.GetAllAsync();
            return View(buildings.Data);
        }

        [HttpGet]
        public IActionResult AddBuilding()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding(BuildingDto buildingDto)
        {
            if (!ModelState.IsValid)
            {
                return View(buildingDto);
            }
            await _buildingService.AddAsync(buildingDto);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult DeleteBuilding(int id)
        {
            _buildingService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBuilding(int id)
        {
            var building = await _buildingService.GetByIdAsync(id);
            if (building.Data == null)
            {
                return RedirectToAction("Index");
            }
            return View(building.Data);
        }
        
        [HttpPost]
        public IActionResult UpdateBuilding(BuildingDto buildingDto)
        {
            if (!ModelState.IsValid)
            {
                return View(buildingDto);
            }
            _buildingService.Update(buildingDto);
            return RedirectToAction("Index");
        }
        
    }
}