/*namespace MyNewProject.Models.Repositories
{
   
    public class FavoritesRepository : IFavoritesRepository
    {
        private readonly AppDbContext _context; // Your database context

        public FavoritesRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool IsProductInFavorites(string userId, int productId)
        {
            return _context.Favorites.Any(f => f.UserId == userId && f.ProductId == productId);
        }

        public void AddToFavorites(string userId, int productId)
        {
            var favorite = new Favorites
            {
                UserId = userId,
                ProductId = productId
            };

            _context.Favorites.Add(favorite);
            _context.SaveChanges();
        }
    }

}
*/