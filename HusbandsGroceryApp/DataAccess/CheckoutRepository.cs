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

        public void UpdateCheckoutList(RecipeCollection updatedRecipes)
        {
            if (updatedRecipes?.Recipes != null && updatedRecipes.Recipes.Any())
            {
                var json = JsonSerializer.Serialize(updatedRecipes, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(ProgramConstants.UlamsFilePath, json);
            }
            else
            {
                // If no recipes left, clear the file completely
                System.IO.File.WriteAllText(ProgramConstants.UlamsFilePath, string.Empty);
            }
        }
    }
}
