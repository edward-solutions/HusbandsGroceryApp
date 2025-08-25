using HusbandsGroceryApp.Models;
using HusbandsGroceryApp.Utilities;
using System.Text.Json;

namespace HusbandsGroceryApp.DataAccess
{
    public class CheckoutRepository : ICheckoutRepository
    {
        public RecipeCollection GetRecipeCollection()
        {
            string json = File.ReadAllText(ProgramConstants.UlamsFilePath);
            return JsonSerializer.Deserialize<RecipeCollection>(json);
        }
    }
}
