using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private List<SinhVien> danhSachSV;

        public QuanLySinhVien()
        {
            danhSachSV = new List<SinhVien>();
        }

        public bool KiemTraTonTai(string maSV)
        {
            return danhSachSV.Any(sv => sv.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }

        public void ThemSinhVien(SinhVien sv)
        {
            if (KiemTraTonTai(sv.MaSinhVien))
            {
                Console.WriteLine("Lỗi: Mã sinh viên này đã tồn tại trong hệ thống!");
                return;
            }
            danhSachSV.Add(sv);
            Console.WriteLine("=> Thêm sinh viên thành công!");
        }

        public void XuatDanhSach()
        {
            if (danhSachSV.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }
            foreach (var sv in danhSachSV)
            {
                sv.LayThongTin();
            }
        }

        public void TimTheoMa(string maSV)
        {
            var sv = danhSachSV.FirstOrDefault(s => s.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
            if (sv != null)
                sv.LayThongTin();
            else
                Console.WriteLine("Không tìm thấy sinh viên có mã: " + maSV);
        }

        public void TimTheoTen(string tuKhoa)
        {
            var ketQua = danhSachSV.Where(s => s.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (ketQua.Count > 0)
                foreach (var sv in ketQua) sv.LayThongTin();
            else
                Console.WriteLine("Không tìm thấy sinh viên nào chứa từ khóa: " + tuKhoa);
        }

        public void SuaDiem(string maSV, double diemMoi)
        {
            var sv = danhSachSV.FirstOrDefault(s => s.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
            if (sv != null)
            {
                try
                {
                    sv.DiemTrungBinh = diemMoi;
                    Console.WriteLine("=> Cập nhật điểm thành công!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy mã sinh viên để sửa điểm.");
            }
        }

        public void XoaSinhVien(string maSV)
        {
            var sv = danhSachSV.FirstOrDefault(s => s.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
            if (sv != null)
            {
                danhSachSV.Remove(sv);
                Console.WriteLine("=> Xóa sinh viên thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy mã sinh viên để xóa.");
            }
        }

        public void SapXepTheoDiem()
        {
            var ketQua = danhSachSV.OrderByDescending(s => s.DiemTrungBinh).ToList();
            foreach (var sv in ketQua) sv.LayThongTin();
        }

        public void LocSinhVienDat()
        {
            var ketQua = danhSachSV.Where(s => s.DiemTrungBinh >= 5.0).ToList();
            if (ketQua.Count > 0)
                foreach (var sv in ketQua) sv.LayThongTin();
            else
                Console.WriteLine("Không có sinh viên nào đạt yêu cầu (Điểm >= 5).");
        }
    }
}