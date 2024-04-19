using App.Models;

namespace App.Services
{
    public interface IRecipeServices
    {
        Recipe CreateRecipe(Recipe recipe);
        IEnumerable<Recipe> GetAllRecipes();
        // Recipe GetRecipeById(int id);
        // public User GetUserByRecipeId(int recipeId);
        IEnumerable<Recipe> GetRecipesByUserId(int postedBy);

    }
}