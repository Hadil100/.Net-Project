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

    public IActionResult AddToCart(string productPath, int productId, string productName, float price, int quantity)
    {
        shoppingRepository.AddItem(productPath, productId, productName , price, quantity);
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
	public IActionResult Payment()
	{
		var cartItems = shoppingRepository.GetCartItems();
		var totalPrice = cartItems.Sum(item => item.Price * item.Quantity);

		var paymentViewModel = new PaymentViewModel
		{
			CartItems = cartItems,
			TotalPrice = totalPrice
		};

		return View(paymentViewModel);
	}

    public IActionResult ProcessPayment(string cardNumber)
    {
        shoppingRepository.ClearCart();
        var success = true; 
        return Json(new { success });
    }
    public IActionResult PaymentConfirmation()
    {
        return View();
    }
}
