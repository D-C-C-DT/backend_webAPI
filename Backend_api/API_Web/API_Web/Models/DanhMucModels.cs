using System.ComponentModel.DataAnnotations;
namespace API_Web.Models
{
    public class DanhMucModels
    {
 /*       public int Id_DM { get; set; }*/
        [Required, StringLength(50)]
        public string Ten_DM { get; set; }

    }
    public class DanhMuc : DanhMucVN
    {
        public int Id_DM { get; set; }
    }
    public class DanhMucVN
    {
        public int Id_DM { get; set; }
        public string Ten_DM { get; set; }
    }
}
