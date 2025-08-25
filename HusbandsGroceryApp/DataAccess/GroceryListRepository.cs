using HusbandsGroceryApp.Models;
using HusbandsGroceryApp.Utilities;
using System.Text.Json;

namespace HusbandsGroceryApp.DataAccess
{
    public class GroceryListRepository : IGroceryListRepository
    {
        public RecipeCollection GetAllIngredients()
        {
            if (!File.Exists(ProgramConstants.UlamsFilePath))
            {
                // If file does not exist, return a new empty collection
                return new RecipeCollection();
            }

            string json = File.ReadAllText(ProgramConstants.UlamsFilePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                // If file is empty, return a new empty collection
                return new RecipeCollection();
            }

            try
            {
                var collection = JsonSerializer.Deserialize<RecipeCollection>(json);
                return collection ?? new RecipeCollection();
            }
            catch (JsonException)
            {
                // If JSON is corrupted, recover by returning an empty collection
                return new RecipeCollection();
            }
        }
    }
}
