using HusbandsGroceryApp.DataAccess;
using HusbandsGroceryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HusbandsGroceryApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICheckoutRepository _checkoutRepository;
        public RecipeController(IRecipeRepository recipeRepository, ICheckoutRepository checkoutRepository)
        {
            _recipeRepository = recipeRepository;
            _checkoutRepository = checkoutRepository;
        }
        public IActionResult Index()
        {
            RecipeCollection result = _recipeRepository.GetAllDishes();
            return View(result);
        }

        public IActionResult AddToUlam(Recipe recipe)
        {
            RecipeCollection recipeCollection = _checkoutRepository.GetRecipeCollection();

            var list = recipeCollection ??= new RecipeCollection();
            if (list.Recipes.All(r => r.Name != recipe.Name))
            {
                list.Recipes.Add(recipe);
                _checkoutRepository.UpdateCheckoutList(list);
            }
            return View("Index", _recipeRepository.GetAllDishes());
        }
    }
}
