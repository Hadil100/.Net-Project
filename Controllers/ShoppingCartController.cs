using Microsoft.AspNetCore.Mvc;
using MyNewProject.Models;
using MyNewProject.Models.Repositories;
using MyNewProject.ViewModels;
using System.Security.Claims;

public class ShoppingCartController : Controller
{
    private readonly IShoppingRepository shoppingRepository;
    private readonly ICommandRepository commandRepository;
    public ShoppingCartController(IShoppingRepository shoppingRepository, ICommandRepository commandRepository)
    {
        this.shoppingRepository = shoppingRepository;
        this.commandRepository = commandRepository;
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

    [HttpPost]
    public IActionResult ProcessPayment(List<CartItem>  CartItems, string UserName, float Total)
    {
        try
        {
            // Récupérez le nom d'utilisateur de l'utilisateur connecté
           

            // Créez une nouvelle commande avec les informations nécessaires
            Command newCommand = new Command
            {
                CartItems = CartItems.Select(item => new CartItem
                {
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                }).ToList(),

                UserName = UserName,
                Total = Total,  // Assurez-vous que TotalPrice est correctement défini dans votre PaymentViewModel
               
            };

            // Ajoutez la nouvelle commande au contexte
            commandRepository.Add(newCommand);

            // Enregistrez les modifications dans la base de données
           

            // Effacez le panier
            shoppingRepository.ClearCart();

            var success = true;
            return Json(new { success });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, errorMessage = ex.Message });
        }
    }

  /*
public IActionResult ProcessPayment(string cardNumber)
    {
        shoppingRepository.ClearCart();
        var success = true;
        return Json(new { success });
    }*/

    public IActionResult PaymentConfirmation()
    {
        return View();
    }
}
