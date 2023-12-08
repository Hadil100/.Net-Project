using MyNewProject.Models;

namespace MyNewProject.ViewModels
{
	public class PaymentViewModel
	{
		public List<CartItem> CartItems { get; set; }
		public string CustomerName { get; set; }
		public float TotalPrice { get; set; }
	
	}
}
