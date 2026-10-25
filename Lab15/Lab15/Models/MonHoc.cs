using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab15.Models
{
    [Table("MONHOC")]
    public class MonHoc
    {
        [Key]
        [Column("MaMonHoc")]
        public string MaMonHoc { get; set; }

        [Column("TenMonHoc")]
        public string TenMonHoc { get; set; }

        [Column("SoTinChi")]
        public int SoTinChi { get; set; }

        [Column("TrangThai")]
        public bool TrangThai { get; set; }
    }
}