using HusbandsGroceryApp.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace HusbandsGroceryApp.Controllers
{
    public class GroceryListController : Controller
    {
        private readonly IGroceryListRepository _groceryListRepository;
        public GroceryListController(IGroceryListRepository groceryListRepository)
        {
            _groceryListRepository = groceryListRepository;
        }
        public IActionResult Index()
        {
            var result = _groceryListRepository.GetAllIngredients();
            return View(result);
        }
    }
}
