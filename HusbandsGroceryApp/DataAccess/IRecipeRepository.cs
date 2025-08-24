using HusbandsGroceryApp.Models;

namespace HusbandsGroceryApp.DataAccess
{
    public interface IRecipeRepository
    {
        Recipe GetDishByName(string name);
        List<Recipe> GetAllDishes();
        void AddDish(Recipe dish);
        void UpdateDish(Recipe dish);
        void DeleteDish(string name);
    }
}
