using System;
using System.Windows.Forms;

namespace Lab06
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Khởi chạy form chính FrmProduct
            Application.Run(new FrmProduct());
        }
    }
}