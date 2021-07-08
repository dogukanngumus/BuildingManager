using System.Threading.Tasks;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Dtos;
using BuildingManager.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class ExpenseTypeController : Controller
    {
        private IExpenseTypeService _expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService expenseTypeService)
        {
            _expenseTypeService = expenseTypeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var expenseTypes = await _expenseTypeService.GetAllAsync();
            return View(expenseTypes.Data);
        }
        
        [HttpGet]
        public IActionResult AddExpenseType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExpenseType(ExpenseTypeDto expenseTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(expenseTypeDto);
            }
            await _expenseTypeService.AddAsync(expenseTypeDto);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult DeleteExpenseType(int id)
        {
            _expenseTypeService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateExpenseType(int id)
        {
            var expenseType = await _expenseTypeService.GetByIdAsync(id);
            if (expenseType.Data == null)
            {
                return RedirectToAction("Index");
            }
            return View(expenseType.Data);
        }

        [HttpPost]
        public IActionResult UpdateExpenseType(ExpenseTypeDto expenseTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(expenseTypeDto);
            }
            _expenseTypeService.Update(expenseTypeDto);
            return RedirectToAction("Index");
        }
        
    }
}