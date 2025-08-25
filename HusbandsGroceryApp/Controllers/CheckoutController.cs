using HusbandsGroceryApp.DataAccess;
using HusbandsGroceryApp.Models;
using HusbandsGroceryApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        [HttpPost]
        public IActionResult UpdateRecipes([FromBody] RecipeCollection updatedRecipes)
        {
            _checkoutRepository.UpdateCheckoutList(updatedRecipes);
            return Ok(new { success = true });
        }
    }
}
