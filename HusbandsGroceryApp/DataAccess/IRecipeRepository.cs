using HusbandsGroceryApp.Models;

namespace HusbandsGroceryApp.DataAccess
{
    public interface IRecipeRepository
    {
        Recipe GetDishByName(string name);
        List<Recipe> GetAllDishes();
        void AddDish(Recipe recipe);
        void UpdateDish(Recipe dish);
        void DeleteDish(string name);
        void AddtoUlam(Recipe recipe);
    }
}
