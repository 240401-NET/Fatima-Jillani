using App.Models;
using App.Data;

namespace App.Services;

public class RecipeServices : IRecipeServices
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly ILogger<RecipeServices> _logger;
    public RecipeServices(IRecipeRepository repository)
    {
        _recipeRepository = repository;
        
    }


    public RecipeServices(IRecipeRepository repository, ILogger<RecipeServices> logger)
    {
        _recipeRepository = repository;
         _logger = logger;
    }


    // post new recipe
    public Recipe CreateRecipe(Recipe recipe)
    {
         if (recipe == null)
        {
            throw new ArgumentNullException(nameof(recipe));
        }
        if (string.IsNullOrWhiteSpace(recipe.Title) || string.IsNullOrWhiteSpace(recipe.Directions) || string.IsNullOrWhiteSpace(recipe.Ingredients))
        {
            throw new ArgumentNullException("Title, Directions and Ingredients are required");
        }
        return _recipeRepository.CreateRecipe(recipe);
       
    }

    // get all recipes  
    public IEnumerable<Recipe> GetAllRecipes()
    {
        return _recipeRepository.GetAllRecipes();
    }

    // get recipe by id
   public IEnumerable<Recipe> GetRecipesByUserId(int postedBy)
    {
        try
        {
            _logger.LogInformation($"Getting recipes for user id: {postedBy}");
            return _recipeRepository.GetRecipesByUserId(postedBy);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting recipes for user id: {postedBy}");
            throw;
        }
    }

    // public User GetUserByRecipeId(int recipeId)
    // {
    //     return _RecipeRepository.GetUserByRecipeId(recipeId);
    // }

    
}