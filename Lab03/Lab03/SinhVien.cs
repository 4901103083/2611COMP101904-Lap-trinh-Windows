using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        private double diemTrungBinh;
        public double DiemTrungBinh
        {
            get { return diemTrungBinh; }
            set
            {
                if (value >= 0 && value <= 10)
                    diemTrungBinh = value;
                else
                    throw new ArgumentException("Điểm trung bình phải nằm trong khoảng từ 0 đến 10.");
            }
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.0) return "Giỏi";
            if (DiemTrungBinh >= 6.5) return "Khá";
            if (DiemTrungBinh >= 5.0) return "Trung bình";
            return "Yếu";
        }

        public override void LayThongTin()
        {
            Console.WriteLine($"Mã SV: {MaSinhVien,-8} | Họ tên: {HoTen,-18} | Lớp: {MaLop,-8} | Điểm: {DiemTrungBinh,-4:F1} | Xếp loại: {XepLoai()}");
        }
    }
}