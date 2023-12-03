using System.ComponentModel.DataAnnotations;

namespace MyNewProject.ViewModels
{

        public class CreateRoleViewModel
        {
            [Required]
            [Display(Name = "Role")]
            public string RoleName { get; set; }
        }
}
