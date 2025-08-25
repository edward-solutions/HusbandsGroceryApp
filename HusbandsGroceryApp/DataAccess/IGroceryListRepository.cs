using HusbandsGroceryApp.Models;

namespace HusbandsGroceryApp.DataAccess
{
    public interface IGroceryListRepository
    {
        RecipeCollection GetAllIngredients();
    }
}
