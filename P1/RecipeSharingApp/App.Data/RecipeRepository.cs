using Microsoft.EntityFrameworkCore;
// See https://aka.ms/new-console-template for more information
using App.Models;

namespace App.Data;

public class RecipeRepository : IRecipeRepository
{
    private readonly _240401netFjContext _context;

    public RecipeRepository(_240401netFjContext context)
    {
        _context = context;
    }

    // post new recipe

      public void SaveChanges()
         
        {
            _context.SaveChanges();
        }
    public Recipe CreateRecipe(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        _context.SaveChanges();

        return recipe;
    }

    // get all recipes  
    public IEnumerable<Recipe> GetAllRecipes()
    {
        return _context.Recipes.ToList();
    }

    // get recipe by id
    public Recipe GetRecipeById(int id)
    {
        return _context.Recipes.Find(id);
    }

    //get recipe by user id
    public IEnumerable<Recipe> GetRecipesByUserId(int postedBy)
    {
        return _context.Recipes.Where(r => r.PostedBy == postedBy).ToList();
    }

    public async Task<Recipe?> UpdateRecipeById(int id, Recipe recipe)
    {

        Recipe oldRecipe = GetRecipeById(id);

        if (oldRecipe != null)
        {
            oldRecipe.Title = recipe.Title ?? oldRecipe.Title;
            oldRecipe.Ingredients = recipe.Ingredients ?? oldRecipe.Ingredients;
            oldRecipe.Directions = recipe.Directions ?? oldRecipe.Directions;
            oldRecipe.PostedBy = recipe.PostedBy;
            await _context.SaveChangesAsync();
            return oldRecipe;
        }

        return null;
    }

    //delete recipe by id
    public Recipe DeleteRecipeById(int id){

        Recipe recipe = GetRecipeById(id);

        try
        {

            if(recipe != null)
            {
                _context.Recipes.Remove(recipe);
                _context.SaveChangesAsync();
                return recipe;
            }
        
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

        return recipe;

    }

}