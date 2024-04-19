using App.Models;

namespace App.Services
{
    public interface IUserServices
    {
        User CreateUser(User user);
        IEnumerable<User> GetAllUsers();
        public IEnumerable<User> GetUsersByUsername(string username);
        public User? GetUserByID(int id);
    }
}