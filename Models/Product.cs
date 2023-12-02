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

       /// <summary>
       public int CategoryId { get; set; }
       /// </summary>
        public Category Category { get; set; }

        [Display(Name = "Image :")]
        public string? Image { get; set; }





    }
}
