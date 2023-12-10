using System.ComponentModel.DataAnnotations;

namespace MyNewProject.Models
{
    public class Command
    {
        public int CommandId { get; set; }

        public string UserName { get; set; }
        [Required]
        public float Total { get; set; }

        [Required]
        public string status { get; set; }

      //  public ICollection<CartItem> CartItems { get; set;}
    }
}
