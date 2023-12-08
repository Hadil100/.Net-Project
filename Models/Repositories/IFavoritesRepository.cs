
public interface IFavoritesRepository
{
    bool IsProductInFavorites(string userId, int productId);
    void AddToFavorites(string userId, int productId);
   
}
