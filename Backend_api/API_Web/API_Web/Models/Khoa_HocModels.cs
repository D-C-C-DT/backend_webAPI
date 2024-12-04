using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Web.Models
{
    public class Khoa_HocModels
    {
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



    }
}
