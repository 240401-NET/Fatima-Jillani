using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using App.Models;
using App.Data;
using App.Services;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeServices _recipeServices;

        public RecipeController(IRecipeServices recipeServices, IRecipeRepository recipeRepository)
        {
            this._recipeServices = recipeServices;
            this._recipeRepository = recipeRepository;
        }


        //public RecipeController(IRecipeRepository recipeRepository, IRecipeServices recipeServices)
        //{
        //    _recipeRepository = recipeRepository;
        //    this._recipeServices = recipeServices;
        //}

        [HttpGet]
        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _recipeServices.GetAllRecipes();
        }


        [HttpGet("recipes/{userId}")]
        public ActionResult<IEnumerable<Recipe>> GetRecipesByUserId(int postedBy)
        {
            var recipes = _recipeServices.GetRecipesByUserId(postedBy);
            if (recipes == null || !recipes.Any())
            {
                return NotFound();
            }
            return Ok(recipes);
        }
        //create new recipe

        [HttpPost]

        public ActionResult<Recipe> CreateRecipe(Recipe recipe)
        {
            var newRecipe = _recipeServices.CreateRecipe(recipe);
            return newRecipe;
           
        }

        // edit recipe by id
        [HttpPut("/recipe/{id}")]
        public async Task<ActionResult<Recipe>> UpdateRecipeById(int id, [FromBody] Recipe recipe)
        {
            if (recipe == null)
            {
                return BadRequest("Provided recipe is null");
            }

            Recipe? updatedRecipe = await _recipeRepository.UpdateRecipeById(id, recipe);

            if (updatedRecipe == null)
            {
                return NotFound();
            }
            return Ok(updatedRecipe);
        }


        

        // delete recipe by id
        [HttpDelete("/recipe/{id}")]
        public ActionResult<Recipe?> DeleteRecipeById(int id)
        {

        try {
                Recipe deletedRecipe = _recipeRepository.DeleteRecipeById(id);
                return deletedRecipe;
            }

            catch(Exception e)
            {
              return Problem(e.Message);
            }
        }
    }
}

