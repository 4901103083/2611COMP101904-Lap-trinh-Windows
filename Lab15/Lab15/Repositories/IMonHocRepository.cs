using System.Collections.Generic;
using Lab15.Models;

namespace Lab15.Repositories
{
    public interface IMonHocRepository
    {
        List<MonHoc> GetAll();
        bool Add(MonHoc monHoc);
        bool Delete(string maMonHoc);
        List<MonHoc> Search(string keyword);
        MonHoc GetById(string maMonHoc);
    }
}