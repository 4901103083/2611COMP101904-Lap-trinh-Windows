using System;
using System.Windows.Forms;
using Lab07.Models; // Gọi namespace chứa class User

namespace Lab07
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Khởi tạo Form đăng nhập (Form1)
            Form1 frmLogin = new Form1();

            // 2. Hiển thị Form đăng nhập. Nếu kết quả trả về là OK (đăng nhập thành công)
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                // Lấy thông tin user đã đăng nhập từ Form1
                User loggedInUser = frmLogin.LoggedInUser!;

                // Mở Form chính (FrmMain) và truyền thông tin user sang
                Application.Run(new FrmMain(loggedInUser));
            }
            else
            {
                // Nếu người dùng bấm dấu X tắt form đăng nhập thì thoát luôn chương trình
                Application.Exit();
            }
        }
    }
}