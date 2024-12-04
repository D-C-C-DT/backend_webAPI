using API_Web.DbContext;
using API_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Web.Repository
{
    public class Khoa_HocRepository : IKhoaHocRepository
    {
        private readonly MyDbContext _context;

        public Khoa_HocRepository(MyDbContext context) 
        {
            _context = context;
        }
        public async Task<Khoa_HocVN>  Add(Khoa_HocModels khoaHocModel)
        {
                        var danhMuc = await _context.Danh_Muc
                .Where(dm => dm.Id_DM == khoaHocModel.Id_DM)
                .Select(dm => new { dm.Id_DM })
                .FirstOrDefaultAsync();
            var khoaHoc = new Khoa_Hoc
            {
                Ten_Khoa_Hoc = khoaHocModel.Ten_Khoa_Hoc,
                Mieu_ta = khoaHocModel.Mieu_ta,
                Gia = khoaHocModel.Gia,
                GiamGia = khoaHocModel.GiamGia,
                Url_Img = khoaHocModel.Url_Img,
                Id_DM = khoaHocModel.Id_DM // Gán ID của DanhMuc
            };
           
            _context.Khoa_Hocs.Add(khoaHoc);
            await _context.SaveChangesAsync();


            /*var danhMuc = await _context.Danh_Muc.FirstOrDefaultAsync(dm => dm.Id_DM == khoaHocModel.Id_DM);*/
            return new Khoa_HocVN
            {
                Id_KH = khoaHoc.Id_KH,
                Ten_Khoa_Hoc = khoaHoc.Ten_Khoa_Hoc,
                Mieu_ta = khoaHoc.Mieu_ta,
                Gia = khoaHoc.Gia,
                GiamGia = khoaHoc.GiamGia,
                Url_Img = khoaHoc.Url_Img,
                Id_DM = danhMuc.Id_DM // Truy cập Ten_DM từ DanhMuc
            };
        }

       

        public async Task Delete(string id)
        {
            var KhoaHoc = _context.Khoa_Hocs.SingleOrDefault(KH => KH.Id_KH == Guid.Parse(id)); 
            if (KhoaHoc != null)
            {
                _context.Remove(KhoaHoc);
                _context.SaveChanges();
            }
        }

        public async Task<List<Khoa_HocVN>> GetAll()
        {
            var Khoahocs = await _context.Khoa_Hocs.Include(k => k.DanhMuc).ToListAsync();
            var result = new List<Khoa_HocVN>();
            result.AddRange(Khoahocs.Select(KH => new Khoa_HocVN
            {
                Id_KH = KH.Id_KH,
                Ten_Khoa_Hoc = KH.Ten_Khoa_Hoc,
                Mieu_ta = KH.Mieu_ta,
                Gia = KH.Gia,
                GiamGia = KH.GiamGia,
                Url_Img = KH.Url_Img,
                Id_DM = KH.Id_DM,
            }));
            return result;
        }

        public Khoa_HocVN GetById(string id)
        {
            var KhoaHoc = _context.Khoa_Hocs.SingleOrDefault(KH => KH.Id_KH == Guid.Parse(id));
            if (KhoaHoc != null)
            {
                return new Khoa_HocVN
                {
                    Id_KH = KhoaHoc!.Id_KH,
                    Ten_Khoa_Hoc = KhoaHoc.Ten_Khoa_Hoc,
                    Mieu_ta = KhoaHoc.Mieu_ta,
                    Gia = KhoaHoc.Gia,
                    GiamGia = KhoaHoc.GiamGia,
                    Url_Img = KhoaHoc.Url_Img,
                    Id_DM = KhoaHoc.Id_DM
                };
            }
            return null;

        }

        public async Task Update(Khoa_HocVN KhoaHoc)
        {
            var _KhoaHoc =  _context.Khoa_Hocs.SingleOrDefault(KH => KH.Id_KH == KhoaHoc.Id_KH);
            var Khoahocs = await _context.Khoa_Hocs.Include(k => k.DanhMuc).ToListAsync();
            _KhoaHoc.Ten_Khoa_Hoc = KhoaHoc.Ten_Khoa_Hoc;
            _KhoaHoc.Mieu_ta = KhoaHoc.Mieu_ta;
            _KhoaHoc.Gia = KhoaHoc.Gia;
            _KhoaHoc.GiamGia = KhoaHoc.GiamGia; 
            _KhoaHoc.Url_Img = KhoaHoc.Url_Img;
            _KhoaHoc.Id_DM = KhoaHoc.Id_DM;
            _context.SaveChanges();
        }
    }
}
