using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNewProject.Models;
using MyNewProject.Models.Repositories;
using MyNewProject.ViewModels;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

public class ShoppingCartController : Controller
{
    private readonly IShoppingRepository shoppingRepository;
    private readonly ICommandRepository commandRepository;
    private readonly IDetailsRepository detailsRepository;
    private readonly UserManager<IdentityUser> usermanager;
    public ShoppingCartController(IShoppingRepository shoppingRepository, ICommandRepository commandRepository, UserManager<IdentityUser> usermanager, IDetailsRepository detailsRepository)
    {
        this.shoppingRepository = shoppingRepository;
        this.commandRepository = commandRepository;
        this.usermanager = usermanager;
        this.detailsRepository = detailsRepository;
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
    
public IActionResult ProcessPayment(IFormCollection collection)
    {
        // Deserialize CartItems
        var ProductId = collection["ProductId[]"];
        var Quantity = collection["Quantity[]"];
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        float TotalPrice = float.Parse(collection["TotalPrice"], NumberStyles.Any, ci);

        string userid= usermanager.GetUserId(User);
        Command command = new Command
        {
            UserId = userid,
            Total = TotalPrice,

        };
        commandRepository.Add(command);
        for (var i= 0;i< ProductId.Count();i++)
        {
            var Detail = new DetailsCommand
            {
                CommandId = command.CommandId,
                Quantity = int.Parse(Quantity[i]),
                ProductId = int.Parse(ProductId[i]),

            };
            detailsRepository.Add(Detail);  
        }
        shoppingRepository.ClearCart();
        return RedirectToAction("Index");
    }

    public IActionResult PaymentConfirmation()
    {
        return View();
    }
}
