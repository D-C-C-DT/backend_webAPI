using API_Web.DbContext;
using API_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Web.Repository
{
    public class EFDanhMucRepository : IDanhMucRepository
    {
        private readonly MyDbContext _context;

        public EFDanhMucRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<DanhMucVN>> Add(DanhMucModels DanhMucModels)
        {
            var danhmuc = new Danh_Muc
            {
              
                Ten_DM = DanhMucModels.Ten_DM
            };
            _context.Add(danhmuc);
            await _context.SaveChangesAsync();

            return new List<DanhMucVN>
            {
                new DanhMucVN {
                Id_DM = danhmuc.Id_DM,
                Ten_DM = danhmuc.Ten_DM
            }};
        }

        public async Task Delete(int id)
        {
           var danhmuc =   _context.Danh_Muc.SingleOrDefault(dm => dm.Id_DM == id);
              _context.Remove(danhmuc);
            await _context.SaveChangesAsync();
                
        }

        public async Task<List<DanhMucVN>> GetAll()
        {
            var Danhmuc = await _context.Danh_Muc.ToListAsync();
            var dm = new List<DanhMucVN>();
            dm.AddRange(Danhmuc.Select(dm => new DanhMucVN
            {
                Id_DM = dm.Id_DM,
                Ten_DM = dm.Ten_DM,
            }));
            return dm;
        }

        public DanhMucVN GetById(int id)
        {
           var danhmuc = _context.Danh_Muc.FirstOrDefault(dm => dm.Id_DM == id);
            if(danhmuc != null)
            {
                return new DanhMucVN()
                {
                    Id_DM = danhmuc.Id_DM,
                    Ten_DM = danhmuc.Ten_DM,
                };
            }
            return null;
        }

        public async Task Update(DanhMucVN Danhmuc)
        {
            var dm =  _context.Danh_Muc.SingleOrDefault(pn => pn.Id_DM == Danhmuc.Id_DM);
           
            dm.Ten_DM = Danhmuc.Ten_DM;

            await _context.SaveChangesAsync();
        }
    }
}

