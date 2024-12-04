using API_Web.Models;
using Microsoft.AspNetCore.Identity;

namespace API_Web.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? AvatarUrl { get; set; }

        public ICollection<User_KhoaHoc> User_KhoaHocs { get; set; }
    }
}
