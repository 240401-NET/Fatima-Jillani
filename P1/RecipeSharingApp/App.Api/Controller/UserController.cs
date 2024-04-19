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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserServices _userServices;
        public UserController(IUserRepository userRepository, IUserServices userServices)
        {
            _userRepository = userRepository;
            _userServices = userServices;
        }
        

        //public RecipeController(IRecipeRepository recipeRepository, IRecipeServices recipeServices)
        //{
        //    _recipeRepository = recipeRepository;
        //    this._recipeServices = recipeServices;
        //}

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userServices.GetAllUsers();
        }

        [HttpGet]
        [Route("{id}")]

        public ActionResult<User> GetUserByID(int id)
        {
            var user = _userServices.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }
            
            return user;
        }

        [HttpGet("search/{username}")]
        public ActionResult<IEnumerable<User>> GetUserByUsername(string username)
        {
            try 
            {
                IEnumerable<User> users = _userServices.GetUsersByUsername(username);
                if(!users.Any())
                {
                    return NoContent();
                }
                return Ok(users); 
            }
            catch(FormatException e) 
            {
                return BadRequest(e.Message);
            }
            
        }
       

        [HttpPost]
        public User CreateUser(User user)
        {
            return _userServices.CreateUser(user);
        }

        
        


    }

}