using System.Threading.Tasks;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Dtos;
using BuildingManager.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class AnnouncementController : Controller
    {
        private IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var announcements = await _announcementService.GetAllAsync();
            return View(announcements.Data);
        }
        
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(AnnouncementDto announcementDto)
        {
            if (!ModelState.IsValid)
            {
                return View(announcementDto);
            }
            await _announcementService.AddAsync(announcementDto);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public  IActionResult DeleteAnnouncement(int id)
        {
            _announcementService.Remove(id);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateAnnouncement(int id)
        {
            var announcement = await _announcementService.GetByIdAsync(id);
            if (announcement.Data == null)
            {
                return RedirectToAction("Index");
            }
            return View(announcement.Data);
        }
        
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementDto announcement)
        {
            if (!ModelState.IsValid)
            {
                return View(announcement);
            }
            _announcementService.Update(announcement);
            return RedirectToAction("Index");
        }
        
        
    }
}