using API_Web.Models;
using API_Web.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuongController : ControllerBase
    {
        private readonly IChuongRepository _chuongRepository;

        public ChuongController(IChuongRepository chuongRepository)
        {
            _chuongRepository = chuongRepository;
        }


        // GET: api/Chuong/KhoaHoc/{khoaHocId}
        [HttpGet]
        public async Task<IActionResult> GetChuongByKhoaHoc()
        {
            var chuongs = await _chuongRepository.GetChuongByKhoaHoc();
            if (chuongs == null || !chuongs.Any())
            {
                return NotFound("No chapters found for the specified course.");
            }

            // Chỉ trả về Name và Id_KH
            var result = chuongs.Select(c => new
            {
                c.Id_Chuong,
                c.Name
            });

            return Ok(result);
        }

        // GET: api/Chuong/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var chuong = _chuongRepository.GetById(id);
            if (chuong == null)
            {
                return NotFound("Chapter not found.");
            }
            return Ok(chuong);
        }



        // POST: api/Chuong
        [HttpPost]
        public async Task<IActionResult> Add( ChuongModels chuong)
        {
            try
            {
                var result = await _chuongRepository.Add(chuong);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        } 


        // PUT: api/Chuong/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ChuongVN chuong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chuong.Id_Chuong)
            {
                return BadRequest("Chapter ID mismatch.");
            }

            await _chuongRepository.Update(chuong);
            return NoContent();
        }
    }
}
