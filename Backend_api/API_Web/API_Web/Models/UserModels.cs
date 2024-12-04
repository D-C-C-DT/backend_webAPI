using System.ComponentModel.DataAnnotations;

namespace API_Web.Models
{
    public class UserModels
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }     
        public string Password { get; set; }  
        public string Roles { get; set; }
    }
}
