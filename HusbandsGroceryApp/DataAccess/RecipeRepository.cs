using HusbandsGroceryApp.Models;
using System.Text.Json;

namespace HusbandsGroceryApp.DataAccess
{
    public class RecipeRepository : IRecipeRepository
    {
        public string RecipeFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "recipes.json");    
        public string UlamsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ulams.json");    


        public void AddtoUlam(Recipe recipe)
        {
            try
            {
                RecipeCollection ulams = new RecipeCollection();

                if (File.Exists(UlamsFilePath))
                {
                    string existingJson = File.ReadAllText(UlamsFilePath);

                    if (!string.IsNullOrWhiteSpace(existingJson))
                    {
                        ulams = JsonSerializer.Deserialize<RecipeCollection>(existingJson) ?? new RecipeCollection();
                    }
                }

                // Ensure Recipes is always initialized
                ulams.Recipes ??= new List<Recipe>();
                ulams.Recipes.Add(recipe);

                string updatedJson = JsonSerializer.Serialize(ulams, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(UlamsFilePath, updatedJson);
            }
            catch (Exception ex)
            {
                // Handle JSON errors, file lock issues, etc.
                Console.WriteLine($"Error updating ulams file: {ex.Message}");
            }
        }

        public RecipeCollection GetAllDishes()
        {
            string json = File.ReadAllText(RecipeFileName);
            RecipeCollection? data = JsonSerializer.Deserialize<RecipeCollection>(json);
            return data ?? new RecipeCollection();
        }


    }
}
