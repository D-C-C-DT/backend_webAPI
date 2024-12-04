using API_Web.Models;

namespace API_Web.Repository
{
    public interface IChuongRepository
    {
        Task<List<ChuongVN>> GetChuongByKhoaHoc();
        ChuongVN GetById(int id);
        Task<ChuongVN> Add(ChuongModels chuong);
        Task Update(ChuongVN chuong);
        Task Delete(int id);
    }
}
