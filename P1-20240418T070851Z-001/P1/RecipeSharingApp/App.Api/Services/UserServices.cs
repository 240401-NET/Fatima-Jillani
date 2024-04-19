using App.Models;
using App.Data;
using System.Text.RegularExpressions;

namespace App.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository repository)
    {
        _userRepository = repository;
    }


    // post new user
    public User CreateUser(User recipe)
    {
        return _userRepository.CreateUser(recipe);
       
    }

    // get all user  
    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    // get user by username
   public IEnumerable<User> GetUsersByUsername(string username)
    {

        if(string.IsNullOrWhiteSpace(username))
        {
            throw new FormatException("Invalid username");
        }
        username = username.ToLower().Trim();
        return _userRepository.GetUsersByUsername(username);
    }

    //get user by id
    public User? GetUserByID(int id)
    {
        return _userRepository.GetUserByID(id);
    }


}