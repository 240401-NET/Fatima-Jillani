

namespace App.Models;

public class User
{
    public int User_id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Recipe>? Recipes { get; set; }

}
