using HusbandsGroceryApp.Models;
using HusbandsGroceryApp.Utilities;
using System.Text.Json;

namespace HusbandsGroceryApp.DataAccess
{
    public class CheckoutRepository : ICheckoutRepository
    {
        public RecipeCollection GetRecipeCollection()
        {
            if (!File.Exists(ProgramConstants.UlamsFilePath))
            {
                // If file does not exist, return a new empty collection
                return new RecipeCollection();
            }

            string json = File.ReadAllText(ProgramConstants.UlamsFilePath);

            return new RecipeCollection();
        }
    }
}
