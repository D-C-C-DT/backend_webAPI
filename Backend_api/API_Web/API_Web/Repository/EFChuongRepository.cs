using API_Web.DbContext;
using API_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Web.Repository
{
    public class EFChuongRepository : IChuongRepository
    {
        private readonly MyDbContext _context;

        public EFChuongRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<ChuongVN> Add(ChuongModels chuong)
        {
            var khoaHoc = await _context.Khoa_Hocs.SingleOrDefaultAsync(kh => kh.Id_KH == chuong.Id_KH);
            if (khoaHoc == null)
            {
                throw new InvalidOperationException("Khóa học không tồn tại.");
            }

            var newChuong = new Chuong
            {
                Name = chuong.Name,
                Id_KH = chuong.Id_KH,
                
            };

            _context.Chuongs.Add(newChuong);
            await _context.SaveChangesAsync();


            return new ChuongVN
            {
                Id_Chuong = newChuong.Id_Chuong,
                Name = newChuong.Name,
                Ten_Khoa_Hoc = khoaHoc.Ten_Khoa_Hoc,
            };
        }

        public async Task Delete(int id)
        {
            var chuong = _context.Chuongs
                .SingleOrDefault(c => c.Id_Chuong == id);

            if (chuong != null)
            {
                _context.Chuongs.Remove(chuong);
                await _context.SaveChangesAsync();
            }
        }


        // Lấy chi tiết chương theo Id_Chuong
        public  ChuongVN GetById(int id)
        {
            var chuong = _context.Chuongs
               .FirstOrDefault(c => c.Id_Chuong == id);

            if (chuong != null)
            {
                return new ChuongVN
                {
                    Id_Chuong = chuong.Id_Chuong,
                    Name = chuong.Name
                };
            }

            return null;
        }

        /// <summary>
        /// Lấy danh sách chương theo Id_KH (mã khóa học)
        /// </summary>
        /// <param name="khoaHocId"></param>
        /// <returns></returns>
        public async Task<List<ChuongVN>> GetChuongByKhoaHoc()
        {
            var chuongs = await _context.Chuongs.ToListAsync();
            return chuongs.Select(c => new ChuongVN
            {
                Id_Chuong = c.Id_Chuong,
                Name = c.Name
            }).ToList();
        }

        public async Task Update(ChuongVN chuong)
        {
            var existingChuong = _context.Chuongs
               .SingleOrDefault(c => c.Id_Chuong == chuong.Id_Chuong);

            if (existingChuong != null)
            {
                existingChuong.Name = chuong.Name;
                await _context.SaveChangesAsync();
            }
        }
    }

    
}
