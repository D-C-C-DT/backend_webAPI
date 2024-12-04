using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Web.Models
{
    public class Bai_Hoc
    {
        [Key]
        public int Id_Lesson { get; set; }

        [Required, StringLength(150)]
        public string Title_Lesson { get; set; } 

        [Required]
        public string? UrlVideo { get; set; } 

        public int Duration { get; set; } // Thời lượng bài học (phút)

        public int OrderIndex { get; set; } // Thứ tự bài học trong chương

        [ForeignKey("Chuong")]
        public int Id_Chuong { get; set; }
        public Chuong Chuong { get; set; } 
    }
}
