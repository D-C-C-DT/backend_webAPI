using API_Web.Data;

namespace API_Web.Models
{
    public class User_KhoaHoc
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid ID_KH { get; set; }
        public Khoa_Hoc Khoa_Hocs { get; set; }

    }
}
