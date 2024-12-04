using System.ComponentModel.DataAnnotations;

namespace API_Web.Models
{
    public class ChuongModels
    {
   
        [Required, StringLength(150)]
        public string Name { get; set; }
        public Guid Id_KH { get; set; }
        /*public Khoa_Hoc Khoa_hocs { get; set; }*/
    }
    public class Chuongs : ChuongVN
    {
        public int Id_Chuong { get; set; }
    }
    public class ChuongVN
    {
        public int Id_Chuong { get; set; }
        public string Name { get; set; }
        public string Ten_Khoa_Hoc { get; set; }

    }

}
