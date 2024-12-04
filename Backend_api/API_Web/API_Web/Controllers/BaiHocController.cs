using API_Web.Models;
using API_Web.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiHocController : ControllerBase
    {

        private readonly IBaiHocRepository _baihocRepository;

        public BaiHocController(IBaiHocRepository baihocRepository)
        {
            _baihocRepository = baihocRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _baihocRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBaiHocById(int id)
        {
            try
            {
                var data = await _baihocRepository.GetBaiHocById(id);
                if (data != null)
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
        public async Task<IActionResult> Add(BaiHocModels Baihoc)
        {
            try
            {
                return Ok(await _baihocRepository.Add(Baihoc));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
