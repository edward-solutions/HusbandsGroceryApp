using HusbandsGroceryApp.Models;

namespace HusbandsGroceryApp.DataAccess
{
    public interface ICheckoutRepository
    {
        RecipeCollection GetRecipeCollection();
    }
}
