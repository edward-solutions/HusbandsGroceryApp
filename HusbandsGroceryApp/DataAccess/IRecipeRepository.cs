using HusbandsGroceryApp.Models;

namespace HusbandsGroceryApp.DataAccess
{
    public interface IRecipeRepository
    {
        RecipeCollection GetAllDishes();
        void AddtoUlam(Recipe recipe);
    }
}
