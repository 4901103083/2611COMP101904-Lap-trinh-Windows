using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanVien
{
    public class NhanVien
    {
        private string maNV;
        private string hoTen;
        private double luongCoBan;
        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public double LuongCoBan
        {
            get => luongCoBan;
            set
            {
                if (value > 0) luongCoBan = value;
                else luongCoBan = 1;
            }
        }
        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }
        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.Write($"Mã NV: {MaNV,-5} | Họ tên: {HoTen,-15} | Lương CB: {LuongCoBan,10:#,##0} | ");
        }
    }
    public class NhanVienVanPhong : NhanVien
    {
        private int soNgayLamViec;
        public int SoNgayLamViec
        {
            get => soNgayLamViec;
            set
            {
                if (value >= 0 && value <= 31) soNgayLamViec = value;
                else soNgayLamViec = 0;
            }
        }
        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }
        public override double TinhLuong()
        {
            return LuongCoBan + (SoNgayLamViec * 200000);
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin(); 
            Console.WriteLine($"Loại: Văn phòng  | Ngày làm: {SoNgayLamViec,2} | Thực lãnh: {TinhLuong(),12:#,##0} VND");
        }
    }
    public class NhanVienKinhDoanh : NhanVien
    {
        private double doanhSo;
        public double DoanhSo
        {
            get => doanhSo;
            set => doanhSo = value >= 0 ? value : 0;
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (0.05 * DoanhSo);
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Loại: Kinh doanh | Doanh số: {DoanhSo,10:#,##0} | Thực lãnh: {TinhLuong(),12:#,##0} VND");
        }
    }
    public class NhanVienThoiVu : NhanVien
    {
        public double SoGioLam { get; set; }
        public double LuongTheoGio { get; set; }
        public NhanVienThoiVu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, 1)
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Loại: Thời vụ    | Giờ làm: {SoGioLam,3}  | Thực lãnh: {TinhLuong(),12:#,##0} VND");
        }
    }
    class Program
    {
        static List<NhanVien> danhSach = new List<NhanVien>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            KhoiTaoDuLieuMau();

            int chon;
            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuất danh sách nhân viên");
                Console.WriteLine("2. Tìm nhân viên theo mã");
                Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
                Console.WriteLine("4. Tính tổng lương công ty phải trả");
                Console.WriteLine("0. Thoát");
                Console.Write("Mời bạn chọn chức năng: ");

                if (!int.TryParse(Console.ReadLine(), out chon)) chon = -1;

                switch (chon)
                {
                    case 1: XuatDanhSach(); break;
                    case 2: TimNhanVienTheoMa(); break;
                    case 3: TimNhanVienLuongCaoNhat(); break;
                    case 4: TinhTongLuong(); break;
                    case 0: Console.WriteLine("Tạm biệt!"); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            } while (chon != 0);
        }

        static void KhoiTaoDuLieuMau()
        {
            danhSach.Add(new NhanVienVanPhong("NV01", "Nguyễn Văn A", 5000000, 22));
            danhSach.Add(new NhanVienVanPhong("NV02", "Lê Thị B", 4500000, 20));
            danhSach.Add(new NhanVienKinhDoanh("KD01", "Trần Văn C", 4000000, 150000000));
            danhSach.Add(new NhanVienKinhDoanh("KD02", "Phạm Thị D", 4200000, 200000000));
            danhSach.Add(new NhanVienThoiVu("TV01", "Hoàng Văn E", 120, 25000));
        }

        static void XuatDanhSach()
        {
            Console.WriteLine("\n--- DANH SÁCH NHÂN VIÊN ---");
            foreach (var nv in danhSach)
            {
                nv.HienThiThongTin();
            }
        }

        static void TimNhanVienTheoMa()
        {
            Console.Write("\nNhập mã nhân viên cần tìm: ");
            string ma = Console.ReadLine();
            var nv = danhSach.FirstOrDefault(x => x.MaNV.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (nv != null)
            {
                Console.WriteLine("-> Đã tìm thấy nhân viên:");
                nv.HienThiThongTin();
            }
            else
            {
                Console.WriteLine("-> Không tìm thấy nhân viên có mã này.");
            }
        }

        static void TimNhanVienLuongCaoNhat()
        {
            if (danhSach.Count == 0) return;
            double maxLuong = danhSach.Max(x => x.TinhLuong());

            Console.WriteLine("\n--- NHÂN VIÊN CÓ LƯƠNG CAO NHẤT ---");
            foreach (var nv in danhSach.Where(x => x.TinhLuong() == maxLuong))
            {
                nv.HienThiThongTin();
            }
        }

        static void TinhTongLuong()
        {
            double tong = danhSach.Sum(x => x.TinhLuong());
            Console.WriteLine($"\n-> Tổng lương công ty phải trả là: {tong:#,##0} VND");
        }
    }
}