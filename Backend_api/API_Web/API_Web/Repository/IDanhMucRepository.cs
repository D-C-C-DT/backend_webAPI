using API_Web.Models;

namespace API_Web.Repository
{
    public interface IDanhMucRepository
    {
        Task<List< DanhMucVN>> GetAll();
        DanhMucVN GetById(int id);
        Task<List<DanhMucVN>> Add(DanhMucModels Danhmuc);
        Task Update(DanhMucVN danhmuc);
        Task Delete(int id);
    }
}
