using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNewProject.Models
{
    public class Command
    {
        public int CommandId { get; set; }

        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }
        [Required]
        public float Total { get; set; }

       // [Required]
        public string status { get; set; }

      //  public ICollection<CartItem> CartItems { get; set;}
    }
}
