using System.ComponentModel.DataAnnotations;

namespace MyNewProject.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        public string ClientFirstName { get; set; }
        [Required]
        public string ClientSecondName { get; set; }
        public string EmailAdress { get; set; }
        [Required]
        public string TelNumber { get; set; }
    }
}
