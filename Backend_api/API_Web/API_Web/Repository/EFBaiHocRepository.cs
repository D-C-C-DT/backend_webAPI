using API_Web.DbContext;
using API_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Web.Repository
{
    public class EFBaiHocRepository : IBaiHocRepository
    {
        private readonly MyDbContext _context;

        public EFBaiHocRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<BaiHocVN> Add(BaiHocModels Baihoc)
        {
           var baihoc= await _context.Chuongs.FirstOrDefaultAsync(c => c.Id_Chuong == Baihoc.Id_Chuong);
            if(baihoc == null)
            {
                throw new InvalidOperationException("Khóa học không tồn tại.");
            }
            var newBaihoc = new Bai_Hoc
            {
                Title_Lesson = Baihoc.Title_Lesson,
                UrlVideo = Baihoc.UrlVideo,
                Duration = Baihoc.Duration,
                OrderIndex = Baihoc.OrderIndex,
                Id_Chuong = Baihoc.Id_Chuong,

            };
             _context.Bai_Hocs.Add(newBaihoc);
            await _context.SaveChangesAsync();

            return new BaiHocVN()
            {
                Id_Lesson = newBaihoc.Id_Lesson,
                Title_Lesson = newBaihoc.Title_Lesson,
                UrlVideo = newBaihoc.UrlVideo,
                Duration = newBaihoc.Duration,
                OrderIndex = newBaihoc.OrderIndex,
                Name = baihoc.Name,
            };
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Timf baif hocj theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaiHocVN> GetBaiHocById(int id)
        {
            var baihoc = await _context.Bai_Hocs.FirstOrDefaultAsync(c => c.Id_Lesson==id);

            if(baihoc != null)
            {
                return new BaiHocVN
                {
                    Id_Lesson = baihoc.Id_Lesson,
                    Title_Lesson = baihoc.Title_Lesson,
                    UrlVideo = baihoc.UrlVideo,
                    Duration = baihoc.Duration,
                    OrderIndex = baihoc.OrderIndex,
                };
            }
            return null;
        }

        public async Task<List<BaiHocVN>> GetAll()
        {
          var BaiHocs = await _context.Bai_Hocs.ToListAsync();

            return  BaiHocs.Select(x => new BaiHocVN
            {
                Id_Lesson = x.Id_Lesson,
                Title_Lesson = x.Title_Lesson,
                UrlVideo = x.UrlVideo,
                Duration = x.Duration,
                OrderIndex = x.OrderIndex,
            }).ToList();
        }

        public Task Update(BaiHocVN chuong)
        {
            throw new NotImplementedException();
        }
    }
}
