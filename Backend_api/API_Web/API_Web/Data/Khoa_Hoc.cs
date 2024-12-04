using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Web.Models
{
    [Table("Khoa_Hoc")]
    public class Khoa_Hoc
    {
        [Key]
        public Guid Id_KH { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ten_Khoa_Hoc { get; set; }

        [Required]
        public string Mieu_ta { get; set; }

        [Range(0, double.MaxValue)]
        public double Gia { get; set; }

        public byte GiamGia { get; set; }
        public string? Url_Img { get; set; }
        public int Id_DM { get; set; }

        [ForeignKey("Id_DM")]
        public Danh_Muc DanhMuc { get; set; }
   
        public ICollection<Chuong> Chuongs { get; set; }
        public ICollection<User_KhoaHoc> User_KhoaHocs { get; set; }


    }
}
