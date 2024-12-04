using API_Web.Models;

namespace API_Web.Repository
{
    public interface IKhoaHocRepository
    {
        Task<List<Khoa_HocVN>> GetAll();
        Khoa_HocVN GetById(string id);
        Task<Khoa_HocVN> Add(Khoa_HocModels KhoaHoc);
        Task Update(Khoa_HocVN KhoaHoc);
        Task Delete(string id);
    }
}
