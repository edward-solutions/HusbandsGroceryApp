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
            List<Recipe> ulams = new List<Recipe>();

            if (File.Exists(UlamsFilePath))
            {
                string existingJson = File.ReadAllText(UlamsFilePath);

                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    ulams = JsonSerializer.Deserialize<List<Recipe>>(existingJson) ?? new List<Recipe>();
                }
            }

            ulams.Add(recipe);

            RecipeCollection collection = new RecipeCollection() { Recipes = ulams };

            string updatedJson = JsonSerializer.Serialize(collection, new JsonSerializerOptions { WriteIndented = true });
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
