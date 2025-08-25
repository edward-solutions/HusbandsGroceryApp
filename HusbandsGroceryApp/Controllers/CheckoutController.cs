using HusbandsGroceryApp.DataAccess;
using HusbandsGroceryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HusbandsGroceryApp.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutRepository _checkoutRepository;

        public CheckoutController(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }

        public IActionResult Index()
        {
            RecipeCollection result = _checkoutRepository.GetRecipeCollection();
            return View(result);
        }
    }
}
