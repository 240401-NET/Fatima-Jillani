using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Data;

public class UserRepository : IUserRepository
{
    private readonly _240401netFjContext _context;


    public UserRepository(_240401netFjContext context)
    {
        _context = context;
    }
    


    // create
    public User CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    } 


    // get all users 
    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    // get user by username
    public IEnumerable<User> GetUsersByUsername(string username)
    {   
        return _context.Users
                        .Where(u => u.Username.ToLower().Contains(username.ToLower()))
                        .ToList();
    }
    
    public User? GetUserByID(int user_id)
    {
        return _context.Users.Find(user_id);
    }
}