using System.ComponentModel.DataAnnotations;

namespace API_Web.Models
{
    public class UpdateUserModels
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
    }
}
