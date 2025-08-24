using HusbandsGroceryApp.Models;
using System.Text.Json;

namespace HusbandsGroceryApp.DataAccess
{
    public class RecipeRepository : IRecipeRepository
    {
        public string RecipeFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "recipes.json");    
        public string UlamsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ulams.json");    

        public void AddDish(Recipe dish)
        {
            throw new NotImplementedException();
        }

        public void AddtoUlam(Recipe recipe)
        {
            List<Recipe> ulams;

            if (File.Exists(UlamsFilePath))
            {
                string existingJson = File.ReadAllText(UlamsFilePath);

                ulams = !string.IsNullOrWhiteSpace(existingJson)
                    ? JsonSerializer.Deserialize<List<Recipe>>(existingJson) ?? new List<Recipe>()
                    : new List<Recipe>();
            }
            else
            {
                ulams = new List<Recipe>();
            }

            ulams.Add(recipe);

            string updatedJson = JsonSerializer.Serialize(ulams, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(UlamsFilePath, updatedJson);
        }


        public void DeleteDish(string name)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetAllDishes()
        {
            string json = File.ReadAllText(RecipeFileName);
            RecipeCollection? data = JsonSerializer.Deserialize<RecipeCollection>(json);
            return data.Recipes;
        }

        public Recipe GetDishByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateDish(Recipe dish)
        {
            throw new NotImplementedException();
        }
    }
}
