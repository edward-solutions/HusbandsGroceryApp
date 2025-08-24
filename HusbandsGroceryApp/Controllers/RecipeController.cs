using HusbandsGroceryApp.DataAccess;
using HusbandsGroceryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HusbandsGroceryApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public IActionResult Index()
        {
            List<Recipe> result = _recipeRepository.GetAllDishes().ToList();
            return View(result);
        }

        public IActionResult AddToUlam(Recipe recipe)
        {
            _recipeRepository.AddtoUlam(recipe);
            List<Recipe> result = _recipeRepository.GetAllDishes().ToList();
            return View("Index", result);
        }
    }
}
