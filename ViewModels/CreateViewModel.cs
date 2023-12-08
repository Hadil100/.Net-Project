
using MyNewProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MyNewProject.ViewModels
{
    public class CreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Designation { get; set; }
        [Required]
        [Display(Name = "Price in dinar :")]
        public float Price { get; set; }
        [Required]
        [Display(Name = "Quantity :")]
        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Image")]
        public IFormFile ImagePath { get; set; }
    }
}
