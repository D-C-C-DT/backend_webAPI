using API_Web.Models;

namespace API_Web.Repository
{
    public interface IBaiHocRepository
    {
        Task<List<BaiHocVN>> GetAll();
        Task<BaiHocVN> GetBaiHocById(int id);
        Task<BaiHocVN> Add(BaiHocModels Baihoc);
        Task Update(BaiHocVN Baihoc);
        Task Delete(int id);
    }
}
