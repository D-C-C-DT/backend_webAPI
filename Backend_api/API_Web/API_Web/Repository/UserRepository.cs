using API_Web.Data;
using API_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API_Web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        /// <summary>
        /// cấp quyền 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>


        public async Task<bool> AssignRoleToUserAsync(string id, UpdateUserModels model)
        {
            // Tìm người dùng theo Id
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return false; // Không tìm thấy người dùng
            }

            // Cập nhật thông tin người dùng
            user.FirstName = model.FirstName ?? user.FirstName;
            user.LastName = model.LastName ?? user.LastName;
            user.Email = model.Email ?? user.Email;

            // Nếu cần cập nhật vai trò
            if (!string.IsNullOrEmpty(model.Roles))
            {
                // Xóa vai trò cũ và thêm vai trò mới
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, model.Roles);
            }

            // Lưu thay đổi
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }


        /// <summary>
        /// xóa người dùng
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
        /// <summary>
        /// Lấy danh sách tất cả người dùng
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<object>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users.Select(u => new { u.Id, u.LastName,u.FirstName, u.Email });
        }

        /// <summary>
        /// đăng ký người dùng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> RegisterUserAsync(UserModels model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(model.Roles))
            {
                if (!await _roleManager.RoleExistsAsync(model.Roles))
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Roles));
                }
                await _userManager.AddToRoleAsync(user, model.Roles);
            }

            return true;
        }
    }
}
