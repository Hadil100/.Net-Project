using System.ComponentModel.DataAnnotations.Schema;

namespace MyNewProject.Models
{
	public class DetailsCommand
	{
		public int Id { get; set; }

		[ForeignKey("Command")]
		public int CommandId { get; set; }

		[ForeignKey("Product")]
		public int ProductId { get; set; }

        public int Quantity { get; set; }
	
	}
}
