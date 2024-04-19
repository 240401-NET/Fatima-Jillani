using App.Models;
// Add this using directive

namespace App.Data;

    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);

        Recipe CreateRecipe(Recipe recipe);
        //get recipe by user id
        IEnumerable<Recipe> GetRecipesByUserId(int postedBy);
        //  public User GetUserByRecipeId(int recipeId);
        Task<Recipe>? UpdateRecipeById(int id, Recipe recipe);

        //delete recipe by id
        Recipe? DeleteRecipeById(int id);

    }
