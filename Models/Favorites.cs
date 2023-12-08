// Favorites.cs
using MyNewProject.Models;

public class Favorites
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

}
