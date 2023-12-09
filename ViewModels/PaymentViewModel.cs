using MyNewProject.Models;

namespace MyNewProject.ViewModels
{
	public class PaymentViewModel
	{
		public List<CartItem> CartItems { get; set; }
		public string ClientName { get; set; }
		public float TotalPrice { get; set; }
	
	}
}
