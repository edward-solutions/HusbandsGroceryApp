namespace HusbandsGroceryApp.Models
{
    public class Recipe
    {
        public string? Name { get; set; }
        public List<string>? Ingredients { get; set; }
    }

    public class RecipeCollection
    {
        public List<Recipe>? Recipes { get; set; } = new List<Recipe>();
    }
}
