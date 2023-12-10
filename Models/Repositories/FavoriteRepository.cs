namespace MyNewProject.Models.Repositories
{
   
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext context; // Your database context

        public FavoriteRepository(AppDbContext context)
        {
            context = context;
        }

        public IEnumerable<Favorite> getAll()
        {
            return context.Favorites;
        }

		/*    Command command = context.Commands.Find(c.CommandId);
				if (command != null)
				{
					c.status = "Valide";
				}
				else
				{
					c.status = "Invalide";
					context.Commands.Add(c);
				}
		*/
		public void AddToFavorites(Product product)
		{
			// Find the favorite for the given product
			
				Favorite myfavorite = context.Favorites.FirstOrDefault(f => f.Product.Id == product.Id);

			if (myfavorite != null)
			{
				// If the favorite exists, increment the NumberLike
				myfavorite.NumberLike += 1;
			}
			else
			{
				// If the favorite doesn't exist, create a new one
				var newfavorite = new Favorite
				{
					Product = product,  // Assuming ProductId is the foreign key for Product in Favorite
					NumberLike = 1
				};

				context.Favorites.Add(newfavorite);
			}

			context.SaveChanges();
		}


	}

}
