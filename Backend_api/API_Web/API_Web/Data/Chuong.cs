using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Web.Models
{

    [Table("Chuong")]
    public class Chuong
    {
        [Key]
        public int Id_Chuong { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        public Guid Id_KH { get; set; }
        public Khoa_Hoc Khoa_hocs { get; set; }
        public ICollection<Bai_Hoc> Bai_Hocs { get; set; }
    }
}
