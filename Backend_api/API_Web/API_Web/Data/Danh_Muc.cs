using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Web.Models
{
    [Table("Danh_Muc")]
    public class Danh_Muc
    {
        [Key]
        public int Id_DM { get; set; }
        [Required, StringLength(50)]
        public string Ten_DM { get; set; }

        public List<Khoa_Hoc>? Khoa_Hocs { get; set; }
    }
}
