using System;

namespace Lab03_QuanLySinhVienOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLySinhVien qlsv = new QuanLySinhVien();
            int chon;

            do
            {
                Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xuat danh sach");
                Console.WriteLine("3. Tim sinh vien theo ma");
                Console.WriteLine("4. Tim sinh vien theo ten");
                Console.WriteLine("5. Sua diem trung binh");
                Console.WriteLine("6. Xoa sinh vien");
                Console.WriteLine("7. Sap xep theo diem giam dan");
                Console.WriteLine("8. Loc sinh vien dat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Vui lòng nhập số hợp lệ!");
                    continue;
                }

                switch (chon)
                {
                    case 1:
                        try
                        {
                            Console.Write("Nhập mã sinh viên: ");
                            string ma = Console.ReadLine();
                            Console.Write("Nhập họ tên: ");
                            string ten = Console.ReadLine();

                            Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                            DateTime ngaySinh;
                            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
                            {
                                Console.Write("Sai định dạng. Nhập lại ngày sinh (dd/MM/yyyy): ");
                            }

                            Console.Write("Nhập mã lớp: ");
                            string maLop = Console.ReadLine();

                            Console.Write("Nhập điểm trung bình: ");
                            double diem;
                            while (!double.TryParse(Console.ReadLine(), out diem))
                            {
                                Console.Write("Điểm phải là số. Nhập lại: ");
                            }

                            SinhVien sv = new SinhVien(ma, ten, ngaySinh, maLop, diem);
                            qlsv.ThemSinhVien(sv);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi tạo sinh viên: {ex.Message}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ---");
                        qlsv.XuatDanhSach();
                        break;
                    case 3:
                        Console.Write("Nhập mã sinh viên cần tìm: ");
                        qlsv.TimTheoMa(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Nhập từ khóa tên cần tìm: ");
                        qlsv.TimTheoTen(Console.ReadLine());
                        break;
                    case 5:
                        Console.Write("Nhập mã sinh viên cần sửa điểm: ");
                        string maSua = Console.ReadLine();
                        Console.Write("Nhập điểm mới: ");
                        if (double.TryParse(Console.ReadLine(), out double diemMoi))
                        {
                            qlsv.SuaDiem(maSua, diemMoi);
                        }
                        else
                        {
                            Console.WriteLine("Điểm nhập vào không hợp lệ!");
                        }
                        break;
                    case 6:
                        Console.Write("Nhập mã sinh viên cần xóa: ");
                        qlsv.XoaSinhVien(Console.ReadLine());
                        break;
                    case 7:
                        Console.WriteLine("\n--- DANH SÁCH SẮP XẾP ĐIỂM GIẢM DẦN ---");
                        qlsv.SapXepTheoDiem();
                        break;
                    case 8:
                        Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ĐẠT ---");
                        qlsv.LocSinhVienDat();
                        break;
                    case 0:
                        Console.WriteLine("Đã thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Chức năng không tồn tại.");
                        break;
                }
            } while (chon != 0);
        }
    }
}