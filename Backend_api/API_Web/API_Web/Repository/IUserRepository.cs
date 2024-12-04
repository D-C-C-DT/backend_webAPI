using API_Web.Models;

namespace API_Web.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<object>> GetAllUsersAsync();
        Task<bool> RegisterUserAsync(UserModels model);
        Task<bool> DeleteUserAsync(string userId);
        Task<bool> AssignRoleToUserAsync(string id, UpdateUserModels model);
    }
}
