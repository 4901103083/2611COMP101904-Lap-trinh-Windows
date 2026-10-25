using System.Collections.Generic;
using System.Linq;
using Lab14.Data;
using Lab14.Models;

namespace Lab14.DAL
{
    public class MonHocDAL
    {
        // 1. Lấy toàn bộ danh sách môn học
        public List<MonHoc> GetAll()
        {
            using (var context = new EduManagerContext())
            {
                return context.MonHocs.ToList();
            }
        }

        // 2. Lấy 1 môn học theo mã (để kiểm tra tồn tại)
        public MonHoc? GetById(string maMonHoc)
        {
            using (var context = new EduManagerContext())
            {
                return context.MonHocs.FirstOrDefault(m => m.MaMonHoc == maMonHoc);
            }
        }

        // 3. Thêm môn học mới
        public bool Add(MonHoc monHoc)
        {
            using (var context = new EduManagerContext())
            {
                context.MonHocs.Add(monHoc);
                return context.SaveChanges() > 0;
            }
        }

        // 4. Sửa thông tin môn học
        public bool Update(MonHoc monHoc)
        {
            using (var context = new EduManagerContext())
            {
                var existing = context.MonHocs.FirstOrDefault(m => m.MaMonHoc == monHoc.MaMonHoc);
                if (existing != null)
                {
                    existing.TenMonHoc = monHoc.TenMonHoc;
                    existing.SoTinChi = monHoc.SoTinChi;
                    existing.TrangThai = monHoc.TrangThai;

                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        // 5. Xóa môn học
        public bool Delete(string maMonHoc)
        {
            using (var context = new EduManagerContext())
            {
                var monHoc = context.MonHocs.FirstOrDefault(m => m.MaMonHoc == maMonHoc);
                if (monHoc != null)
                {
                    context.MonHocs.Remove(monHoc);
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        // 6. Tìm kiếm theo mã hoặc tên
        public List<MonHoc> Search(string keyword)
        {
            using (var context = new EduManagerContext())
            {
                return context.MonHocs
                    .Where(m => m.MaMonHoc.Contains(keyword) || m.TenMonHoc.Contains(keyword))
                    .ToList();
            }
        }
    }
}