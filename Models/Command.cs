using System.ComponentModel.DataAnnotations;

namespace MyNewProject.Models
{
    public class Command
    {
        public int CommandId { get; set; }
        [Required]
        public float Total { get; set; }

        public ICollection<Product> ProductList { get; set;}
    }
}
