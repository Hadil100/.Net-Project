namespace MyNewProject.Models.Repositories
{
    public interface IShoppingRepository
    {
        public void AddItem(int productId, string productName, float price, int quantity);
        public void RemoveItem(int productId);
        public void ClearCart();
        public List<CartItem> GetCartItems();
    }
}
