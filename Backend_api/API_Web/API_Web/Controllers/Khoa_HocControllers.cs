using API_Web.Models;
using API_Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Khoa_Hocr : ControllerBase
    {
        
        
        private readonly IKhoaHocRepository _KhoaHocRepository;
        public Khoa_Hocr(IKhoaHocRepository KhoaHocRepository) 
        {
            _KhoaHocRepository = KhoaHocRepository;
        }

        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            try
            {
                return Ok(await _KhoaHocRepository.GetAll());
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var data = _KhoaHocRepository.GetById(id);
                if(data != null)
                {
                    return Ok(data);
                }
                else 
                { 
                    return NotFound(); 
                }                            
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Khoa_HocModels KhoaHocs)
        {
            try
            { 
            return Ok(await _KhoaHocRepository.Add(KhoaHocs));

            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(string id, Khoa_HocVN khoaHocEdit)
        {
            if (Guid.Parse(id) != khoaHocEdit.Id_KH)
            {
                return BadRequest();
            }
            try
            {
                 await _KhoaHocRepository.Update(khoaHocEdit);
              
                    return NoContent();
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
              _KhoaHocRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
