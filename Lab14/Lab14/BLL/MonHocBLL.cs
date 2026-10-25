using System.Collections.Generic;
using Lab14.DAL;
using Lab14.Models;

namespace Lab14.BLL
{
    public class MonHocBLL
    {
        // Khởi tạo đối tượng DAL để gọi các hàm thao tác DB
        private MonHocDAL dal = new MonHocDAL();

        // 1. Lấy danh sách
        public List<MonHoc> GetAll()
        {
            return dal.GetAll();
        }

        // 2. Xử lý Thêm môn học
        // Trả về chuỗi rỗng ("") nếu thành công, trả về thông báo lỗi nếu thất bại
        public string Add(MonHoc monHoc)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(monHoc.MaMonHoc))
                return "Mã môn học không được để trống!";
            if (string.IsNullOrWhiteSpace(monHoc.TenMonHoc))
                return "Tên môn học không được để trống!";

            // Kiểm tra số tín chỉ (1 đến 6)
            if (monHoc.SoTinChi < 1 || monHoc.SoTinChi > 6)
                return "Số tín chỉ phải nằm trong khoảng từ 1 đến 6!";

            // Kiểm tra trùng mã môn học
            if (dal.GetById(monHoc.MaMonHoc) != null)
                return "Mã môn học đã tồn tại! Vui lòng nhập mã khác.";

            // Gọi DAL để thêm vào DB
            if (dal.Add(monHoc))
                return ""; // Thành công

            return "Có lỗi hệ thống xảy ra khi thêm dữ liệu.";
        }

        // 3. Xử lý Sửa môn học
        public string Update(MonHoc monHoc)
        {
            if (string.IsNullOrWhiteSpace(monHoc.MaMonHoc))
                return "Vui lòng chọn môn học cần sửa!";
            if (string.IsNullOrWhiteSpace(monHoc.TenMonHoc))
                return "Tên môn học không được để trống!";
            if (monHoc.SoTinChi < 1 || monHoc.SoTinChi > 6)
                return "Số tín chỉ phải nằm trong khoảng từ 1 đến 6!";

            if (dal.Update(monHoc))
                return "";

            return "Cập nhật thất bại. Không tìm thấy mã môn học.";
        }

        // 4. Xử lý Xóa môn học
        public string Delete(string maMonHoc)
        {
            if (string.IsNullOrWhiteSpace(maMonHoc))
                return "Vui lòng chọn một môn học để xóa!";

            if (dal.Delete(maMonHoc))
                return "";

            return "Xóa thất bại. Không tìm thấy mã môn học.";
        }

        // 5. Xử lý Tìm kiếm
        public List<MonHoc> Search(string keyword)
        {
            // Nếu từ khóa rỗng, trả về toàn bộ danh sách
            if (string.IsNullOrWhiteSpace(keyword))
                return dal.GetAll();

            return dal.Search(keyword);
        }
    }
}