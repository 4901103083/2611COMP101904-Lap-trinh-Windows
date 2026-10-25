using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab14.Models
{
    [Table("MONHOC")] // Trỏ đúng tên bảng trong SQL
    public class MonHoc
    {
        [Key]
        [StringLength(10)]
        public string MaMonHoc { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string TenMonHoc { get; set; } = null!;

        public int SoTinChi { get; set; }

        public bool? TrangThai { get; set; } = true;
    }
}