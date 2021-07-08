using System.Linq;
using System.Threading.Tasks;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Abstract.APIService;
using BuildingManager.Business.Dtos;
using BuildingManager.Business.PaymentApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IAnnouncementService _announcementService;
        private IBuildingService _buildingService;
        private IExpenseService _expenseService;
        private IExpenseTypeService _expenseTypeService;
        private IFlatService _flatService;
        private IUserService _userService;
        private IMessageService _messageService;
        private IPaymentApiService _paymentApiService;
        
        public HomeController(IAnnouncementService announcementService, IBuildingService buildingService, 
            IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService, IUserService userService, IMessageService messageService, IPaymentApiService paymentApiService)
        {
            _announcementService = announcementService;
            _buildingService = buildingService;
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _flatService = flatService;
            _userService = userService;
            _messageService = messageService;
            _paymentApiService = paymentApiService;
        }
        
        public async Task<IActionResult> Index()
        {
            var announcements = await _announcementService.GetAllAsync();
            return View(announcements.Data);
        }
        
        public async Task<IActionResult> GetBuildings()
        {
            var buildings = await _buildingService.GetAllAsync();
            return View(buildings.Data);
        }
        
        public async Task<IActionResult> GetNonPaidExpense()
        {
            var user = _userService.GetUserFromSession();
            var expenses = await _expenseService.GetExpensesWithRelations();
            var expensesOfDebt = expenses.Data.Where(e=>e.IsPaid==false && e.UserName == user.UserName).ToList();
            return View(expensesOfDebt);
        }
        
        public async Task<IActionResult> GetExpenseTypes()
        {
            var expenseTypes = await _expenseTypeService.GetAllAsync();
            return View(expenseTypes.Data);
        }
        
        public async Task<IActionResult> GetFlats()
        {
            var flats = await _flatService.GetAllFlatsByRelations();
            return View(flats.Data);
        }
        
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
        public async Task<IActionResult> CreatePayment(int id)
        {
            var expense = await _expenseService.GetByIdAsync(id);
            var CreatePayment = new CreatePaymentDto
            {
                ExpenseId = expense.Data.Id,
                FlatId = expense.Data.FlatId,
                InvoiceAmount = expense.Data.Price
            };
            return View(CreatePayment);

        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var paidExpense = await _expenseService.GetByIdForPayment(createPaymentDto.ExpenseId);
            createPaymentDto.InvoiceAmount = paidExpense.Data.Price;
            createPaymentDto.FlatId = paidExpense.Data.FlatId;
            createPaymentDto.ExpenseId = paidExpense.Data.Id;
            var response = await _paymentApiService.CreatePayment(createPaymentDto);
            if (response.StatusCode == StatusCodes.Status200OK)
            {
                paidExpense.Data.IsPaid = true;
                _expenseService.UpdateForPayment(paidExpense.Data);
                TempData.Add("message",response.Message);
                return RedirectToAction("GetNonPaidExpense");
            }
            TempData.Add("message",response.Message);
            return RedirectToAction("GetNonPaidExpense");
        }

    }
}