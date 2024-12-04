using API_Web.Data;
using API_Web.Helpers;
using API_Web.Models;
using API_Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private readonly IDanhMucRepository _danhMucRepository;

        public DanhMucController(IDanhMucRepository DanhMucRepository)
        {
            _danhMucRepository = DanhMucRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _danhMucRepository.GetAll());
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _danhMucRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);

                }
                return BadRequest();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Authorize(Roles = $"{AppRole.Admin}")]
        public async Task<IActionResult> Add(DanhMucModels DanhmucModels)
        {
            try
            {
                return Ok(await _danhMucRepository.Add(DanhmucModels));
            } catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Lecturer}")]
        public async Task<IActionResult>Update(DanhMucVN danhMuc,int id)
        {
            if ( id != danhMuc.Id_DM )
            {
                return BadRequest();
            }
            try
            {
                await _danhMucRepository.Update(danhMuc);
                return NoContent();
            }catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        [Authorize]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Lecturer}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _danhMucRepository.Delete(id);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
