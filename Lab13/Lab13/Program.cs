using System;
using System.Windows.Forms;
using Lab13.Forms; // Thêm dòng này để import thư mục Forms chứa FrmBaoCaoSinhVien

namespace Lab13
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Gọi chạy FrmBaoCaoSinhVien
            Application.Run(new FrmBaoCaoSinhVien());
        }
    }
}