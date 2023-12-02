using System.ComponentModel.DataAnnotations;

namespace MyNewProject.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Designation { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Image :")]
        public string? Image { get; set; }





    }
}
