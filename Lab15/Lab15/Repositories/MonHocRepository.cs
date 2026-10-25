using System.Collections.Generic;
using System.Linq;
using Lab15.Models;

namespace Lab15.Repositories
{
    public class MonHocRepository : IMonHocRepository
    {
        public List<MonHoc> GetAll()
        {
            using (var context = new EduManagerContext())
            {
                return context.MonHocs.ToList();
            }
        }

        public MonHoc GetById(string maMonHoc)
        {
            using (var context = new EduManagerContext())
            {
                return context.MonHocs.FirstOrDefault(m => m.MaMonHoc == maMonHoc);
            }
        }

        public bool Add(MonHoc monHoc)
        {
            using (var context = new EduManagerContext())
            {
                context.MonHocs.Add(monHoc);
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maMonHoc)
        {
            using (var context = new EduManagerContext())
            {
                var mh = context.MonHocs.FirstOrDefault(m => m.MaMonHoc == maMonHoc);
                if (mh != null)
                {
                    context.MonHocs.Remove(mh);
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

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