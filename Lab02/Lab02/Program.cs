using System;
#nullable disable
using System.Text;

namespace Lab02_QuanLyMang
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int[] arr = null; 
            int choice;

            do
            {
         
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Nhap mang");
                Console.WriteLine("2. Xuat mang");
                Console.WriteLine("3. Tinh tong");
                Console.WriteLine("4. Tim max/min");
                Console.WriteLine("5. Dem chan/le");
                Console.WriteLine("6. Sap xep tang dan");
                Console.WriteLine("7. Tim kiem");
                Console.WriteLine("0. Thoat");

                choice = NhapSoNguyen("Chon chuc nang: ");

                if (choice >= 2 && choice <= 7 && arr == null)
                {
                    Console.WriteLine("Lỗi: Bạn chưa nhập mảng! Vui lòng chọn chức năng 1 trước.");
                    continue; 
                }

                switch (choice)
                {
                    case 1:
                        arr = NhapMang();
                        break;
                    case 2:
                        Console.WriteLine("Các phần tử của mảng:");
                        XuatMang(arr!);
                        break;
                    case 3:
                        Console.WriteLine($"Tổng các phần tử: {TinhTong(arr)}");
                        break;
                    case 4:
                        Console.WriteLine($"Giá trị Max: {TimMax(arr)}");
                        Console.WriteLine($"Giá trị Min: {TimMin(arr)}");
                        break;
                    case 5:
                        Console.WriteLine($"Số lượng phần tử chẵn: {DemChan(arr)}");
                        Console.WriteLine($"Số lượng phần tử lẻ: {DemLe(arr)}");
                        break;
                    case 6:
                        SapXepTangDan(arr);
                        Console.WriteLine("Mảng sau khi sắp xếp tăng dần:");
                        XuatMang(arr);
                        break;
                    case 7:
                        int x = NhapSoNguyen("Nhập giá trị x cần tìm: ");
                        int pos = TimKiem(arr, x);
                        if (pos != -1)
                            Console.WriteLine($"Tìm thấy {x} tại vị trí đầu tiên là {pos} (tính từ 0).");
                        else
                            Console.WriteLine("Không tìm thấy.");
                        break;
                    case 0:
                        Console.WriteLine("Đã thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn từ 0 đến 7.");
                        break;
                }

            } while (choice != 0);
        }
        static int NhapSoNguyen(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ.");
            }
        }
        static int NhapSoNguyenDuong(string message)
        {
            int value;
            while (true)
            {
                value = NhapSoNguyen(message);
                if (value > 0)
                {
                    return value;
                }
                Console.WriteLine("Lỗi: Số lượng phần tử (n) phải là số nguyên dương lớn hơn 0.");
            }
        }

        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhập số lượng phần tử n = ");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhập phần tử thứ {i}: ");
            }
            return a;
        }
        static void XuatMang(int[] a)
        {
            Console.WriteLine(string.Join(" ", a));
        }

        static int TinhTong(int[] a)
        {
            int sum = 0;
            foreach (int item in a)
            {
                sum += item;
            }
            return sum;
        }

        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
            }
            return max;
        }

        // Hàm tìm giá trị nhỏ nhất
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min) min = a[i];
            }
            return min;
        }

        // Hàm đếm số chẵn
        static int DemChan(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 == 0) count++;
            }
            return count;
        }

        // Hàm đếm số lẻ
        static int DemLe(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 != 0) count++;
            }
            return count;
        }
        static void SapXepTangDan(int[] a)
        {
            Array.Sort(a); 
        }
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x) return i;
            }
            return -1; 
        }
    }
}