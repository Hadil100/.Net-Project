
using MyNewProject.Models;

public interface IFavoriteRepository
{
    public IEnumerable<Favorite> getAll();
    void AddToFavorites(Product product);
   
}
