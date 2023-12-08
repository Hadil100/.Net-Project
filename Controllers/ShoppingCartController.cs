using Microsoft.AspNetCore.Mvc;
using MyNewProject.Models.Repositories;
using MyNewProject.ViewModels;

public class ShoppingCartController : Controller
{
    private readonly IShoppingRepository shoppingRepository;

    public ShoppingCartController(IShoppingRepository shoppingRepository)
    {
        this.shoppingRepository = shoppingRepository;
    }

    public IActionResult Index()
    {
        var cartItems = shoppingRepository.GetCartItems();
        var cartViewModel = new CartViewModel
        {
            CartItems = cartItems,
            TotalPrice = cartItems.Sum(item => item.Price * item.Quantity)
        };
        return View(cartViewModel);
    }

    public IActionResult AddToCart(int productId, string productName, float price, int quantity)
    {
        shoppingRepository.AddItem(productId, productName, price, quantity);
        return RedirectToAction("Index");
    }

    public IActionResult RemoveFromCart(int productId)
    {
        shoppingRepository.RemoveItem(productId);
        return RedirectToAction("Index");
    }

    public IActionResult ClearCart()
    {
        shoppingRepository.ClearCart();
        return RedirectToAction("Index");
    }
}
