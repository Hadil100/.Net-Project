using MyNewProject.Models;

namespace MyNewProject.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public float TotalPrice { get; set; }
    }
}
