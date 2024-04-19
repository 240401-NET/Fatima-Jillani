using System.ComponentModel.DataAnnotations;



namespace App.Models;

public class Recipe
{
    public int RecipeId { get; set; }

    
    
    public string Title { get; set; }

    
    public string  Directions { get; set; }

    
    public string Ingredients { get; set; }

    public int PostedBy { get; set; }

    // public User? User { get; set; } 

    public DateTime CreatedAt { get; set; }

    public virtual User? User { get; set; }

    // public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

}


