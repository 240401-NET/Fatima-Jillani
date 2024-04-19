using App.Models;
namespace App.Data;

    public interface IUserRepository
    {
    IEnumerable<User> GetAllUsers();
    public IEnumerable<User> GetUsersByUsername(string username);

    User CreateUser(User recipe);

    //get user by id
    User? GetUserByID(int user_id);
}
