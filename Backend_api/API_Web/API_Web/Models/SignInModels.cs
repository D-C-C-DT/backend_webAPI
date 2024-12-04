using System.ComponentModel.DataAnnotations;

namespace API_Web.Models
{
    public class SignInModels
    {
        [Required, EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;

    }
}
