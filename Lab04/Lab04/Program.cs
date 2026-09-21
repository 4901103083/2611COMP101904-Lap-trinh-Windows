using System;
using System.Linq;

namespace Lab04_ProductManager
{
    class Program
    {
        static ProductService service = new ProductService();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            service.OnProductAdded += (product) =>
                Console.WriteLine($"\n[SỰ KIỆN] -> Đã thêm thành công sản phẩm: {product.Name}");

            service.OnProductRemoved += (id) =>
                Console.WriteLine($"\n[SỰ KIỆN] -> Đã xóa thành công sản phẩm mã: {id}");

            int choice = -1;
            do
            {
                PrintMenu();
                try
                {
                    Console.Write("Chọn chức năng: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddProductUI(); break;
                        case 2: ShowAllUI(); break;
                        case 3: SearchByIdUI(); break;
                        case 4: SearchByNameUI(); break;
                        case 5: FilterByPriceUI(); break;
                        case 6: RemoveProductUI(); break;
                        case 7: TotalValueUI(); break;
                        case 0: Console.WriteLine("Đã thoát chương trình."); break;
                        default: Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại!"); break;
                    }
                }
                catch (DuplicateProductException ex) { Console.WriteLine($"\n[LỖI NGHIỆP VỤ] {ex.Message}"); }
                catch (ProductNotFoundException ex) { Console.WriteLine($"\n[LỖI NGHIỆP VỤ] {ex.Message}"); }
                catch (ArgumentException ex) { Console.WriteLine($"\n[LỖI DỮ LIỆU] {ex.Message}"); }
                catch (FormatException) { Console.WriteLine("\n[LỖI NHẬP LIỆU] Vui lòng nhập số hợp lệ."); }
                catch (Exception ex) { Console.WriteLine($"\n[LỖI HỆ THỐNG] {ex.Message}"); }

                Console.WriteLine("\nNhấn Enter để tiếp tục...");
                Console.ReadLine();

            } while (choice != 0);
        }

        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("===== PRODUCT MANAGER =====");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Xuất danh sách");
            Console.WriteLine("3. Tìm theo mã");
            Console.WriteLine("4. Tìm theo tên");
            Console.WriteLine("5. Lọc theo khoảng giá");
            Console.WriteLine("6. Xóa sản phẩm");
            Console.WriteLine("7. Tính tổng giá trị kho");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("===========================");
        }

        static void AddProductUI()
        {
            Console.Write("Nhập mã SP: ");
            string id = Console.ReadLine();
            Console.Write("Nhập tên SP: ");
            string name = Console.ReadLine();
            Console.Write("Nhập đơn giá: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Nhập số lượng: ");
            int quantity = int.Parse(Console.ReadLine());

            Product p = new Product(id, name, price, quantity);
            service.AddProduct(p);
        }

        static void ShowAllUI()
        {
            var list = service.GetAll().ToList();
            if (!list.Any())
            {
                Console.WriteLine("Danh sách sản phẩm đang trống.");
                return;
            }
            Console.WriteLine("\n--- DANH SÁCH SẢN PHẨM ---");
            foreach (var p in list) Console.WriteLine(p.ToString());
        }

        static void SearchByIdUI()
        {
            Console.Write("Nhập mã sản phẩm cần tìm: ");
            string id = Console.ReadLine();
            var p = service.SearchById(id);
            if (p != null) Console.WriteLine(p.ToString());
            else Console.WriteLine("Không tìm thấy sản phẩm!");
        }

        static void SearchByNameUI()
        {
            Console.Write("Nhập từ khóa tên sản phẩm: ");
            string keyword = Console.ReadLine();

            var results = service.Filter(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!results.Any()) Console.WriteLine("Không tìm thấy sản phẩm nào phù hợp.");
            else
            {
                Console.WriteLine("\n--- KẾT QUẢ TÌM KIẾM ---");
                foreach (var p in results) Console.WriteLine(p.ToString());
            }
        }

        static void FilterByPriceUI()
        {
            Console.Write("Nhập giá thấp nhất: ");
            decimal min = decimal.Parse(Console.ReadLine());
            Console.Write("Nhập giá cao nhất: ");
            decimal max = decimal.Parse(Console.ReadLine());

            var results = service.Filter(p => p.Price >= min && p.Price <= max).ToList();

            if (!results.Any()) Console.WriteLine("Không có sản phẩm nào trong khoảng giá này.");
            else
            {
                Console.WriteLine($"\n--- SẢN PHẨM TỪ {min} ĐẾN {max} ---");
                foreach (var p in results) Console.WriteLine(p.ToString());
            }
        }

        static void RemoveProductUI()
        {
            Console.Write("Nhập mã sản phẩm cần xóa: ");
            string id = Console.ReadLine();
            service.RemoveProduct(id);
        }

        static void TotalValueUI()
        {
            decimal total = service.CalculateTotalInventoryValue();
            Console.WriteLine($"\nTổng giá trị toàn bộ sản phẩm trong kho: {total:N0}");
        }
    }
}