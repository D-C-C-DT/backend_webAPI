using API_Web.Helpers;
using API_Web.Models;
using API_Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Web.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = AppRole.Admin)] // Chỉ Admin mới truy cập được
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        /// <summary>
        /// lấy danh sách tất cả
        /// </summary>
        /// <returns></returns>
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }


        /// <summary>
        /// đang ký người dùng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("admin-register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserModels model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Gọi repository để đăng ký người dùng
                bool result = await _userRepository.RegisterUserAsync(model);

                if (!result)
                {
                    return BadRequest("Không thể tạo người dùng. Vui lòng kiểm tra lại thông tin.");
                }

                return Ok("Đăng ký người dùng thành công.");
            }
            catch (ArgumentException ex)
            {
                // Lỗi do thiếu dữ liệu hoặc dữ liệu không hợp lệ
                return BadRequest(new { Message = ex.Message });
            }
            catch (System.Exception ex)
            {
                // Xử lý lỗi không mong muốn
                return StatusCode(500, new { Message = "Đã xảy ra lỗi trong hệ thống.", Details = ex.Message });
            }
        }
        

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userRepository.DeleteUserAsync(id);
            if (!result) return NotFound("User not found");

            return Ok("User deleted successfully");
        }


        /// <summary>
        /// cấp quyền
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("admin-assign-role/{id}")]
        public async Task<IActionResult> AssignRoleToUser(string id, [FromBody] UpdateUserModels model)
        {
            // Kiểm tra dữ liệu đầu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Gọi repository để cập nhật thông tin người dùng
                bool result = await _userRepository.AssignRoleToUserAsync(id, model);

                if (!result)
                {
                    return NotFound(new { Message = "Không tìm thấy người dùng với Id này." });
                }

                return Ok(new { Message = "Cập nhật thông tin người dùng thành công." });
            }
            catch (ArgumentException ex)
            {
                // Lỗi do thiếu dữ liệu hoặc dữ liệu không hợp lệ
                return BadRequest(new { Message = ex.Message });
            }
            catch (System.Exception ex)
            {
                // Xử lý lỗi không mong muốn
                return StatusCode(500, new { Message = "Đã xảy ra lỗi trong hệ thống.", Details = ex.Message });
            }
        }
    }
    


}

