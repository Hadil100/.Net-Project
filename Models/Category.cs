using System.ComponentModel.DataAnnotations;

namespace MyNewProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
