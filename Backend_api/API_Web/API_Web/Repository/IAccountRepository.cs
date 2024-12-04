using API_Web.Models;
using Microsoft.AspNetCore.Identity;

namespace API_Web.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModels model);
        public Task<string> SignInAsync(SignInModels model);
    }
}
