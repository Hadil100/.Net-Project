namespace MyNewProject.Models.Repositories
{
    public class ShoppingRepository : IShoppingRepository
    {
        private readonly AppDbContext context;

        public ShoppingRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddItem(string productPath, int productId, string productName, float price, int quantity)
        {
            var existingItem = context.ShoppingCardItems.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                // Vous devez ajouter l'élément au contexte, puis le sauvegarder dans la base de données
                var newItem = new CartItem
                {   ProductPath = productPath,
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                };
                context.ShoppingCardItems.Add(newItem);
            }

            // Sauvegardez les modifications dans la base de données
            context.SaveChanges();
        }

        public void RemoveItem(int productId)
        {
            var itemToRemove = context.ShoppingCardItems.FirstOrDefault(item => item.ProductId == productId);

            if (itemToRemove != null)
            {
                // Vous devez retirer l'élément du contexte, puis le sauvegarder dans la base de données
                context.ShoppingCardItems.Remove(itemToRemove);

                // Sauvegardez les modifications dans la base de données
                context.SaveChanges();
            }
        }

        public void ClearCart()
        {
            // Vous devez effacer tous les éléments du panier dans le contexte, puis sauvegarder dans la base de données
            context.ShoppingCardItems.RemoveRange(context.ShoppingCardItems);
            context.SaveChanges();
        }
        public List<CartItem> GetCartItems()
        {
            return context.ShoppingCardItems.ToList();
        }
    }
}
