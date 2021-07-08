using System.Linq;
using System.Threading.Tasks;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Dtos;
using BuildingManager.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class MessageController : Controller
    {
        private IMessageService _messageService;
        private IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
           var user = _userService.GetUserFromSession();
           var allMessages = await _messageService.GetAllAsync();
           if (allMessages.Data != null)
           {
               var messageList = allMessages.Data.Where(m=>m.ReceiverEmail == user.Email).ToList(); 
               return View(messageList);
           }
           return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Outbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages.Data != null)
            {
                var messageList = allMessages.Data.Where(m=>m.SenderEmail == user.Email).ToList(); 
                return View(messageList);
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDto message)
        {
            var user = _userService.GetUserFromSession();
            message.SenderEmail = user.Email;
            await _messageService.AddAsync(message);
            return RedirectToAction("OutBox");
        }
        
        [HttpGet]
        public IActionResult DeleteMessageFromInbox(int id)
        {
            _messageService.Remove(id);
            return RedirectToAction("Inbox");
        }
        
        [HttpGet]
        public IActionResult DeleteMessageFromOutbox(int id)
        {
            _messageService.Remove(id);
            return RedirectToAction("Outbox");
        }
    }
}