using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Web.Models
{
    public class Khoa_HocVN
    {
       
        public Guid Id_KH { get; set; }

        public string Ten_Khoa_Hoc { get; set; }

   
        public string Mieu_ta { get; set; }

        public double Gia { get; set; }

        public byte GiamGia { get; set; }
        public string? Url_Img { get; set; }
        public int Id_DM{ get; set; }
  

    }
}
