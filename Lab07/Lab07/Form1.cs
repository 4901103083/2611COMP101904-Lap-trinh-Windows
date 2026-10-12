using System;
using System.Windows.Forms;
using Lab07.Models;

namespace Lab07
{
    public partial class Form1 : Form
    {
        public User? LoggedInUser { get; private set; }

        public Form1()
        {
            InitializeComponent();

            // Gán phím tắt: Nhấn Enter sẽ tự động kích hoạt nút Đăng nhập
            this.AcceptButton = btnLogin;
        }

        // Sự kiện nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (username == "admin" && password == "123")
            {
                LoggedInUser = new User()
                {
                    Username = username,
                    Password = password,
                    FullName = "Quản trị viên",
                    Role = "Admin"
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (username == "user" && password == "123")
            {
                LoggedInUser = new User()
                {
                    Username = username,
                    Password = password,
                    FullName = "Nhân viên bán hàng",
                    Role = "User"
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // Sự kiện nút Thoát (Đã cập nhật đóng hộp thoại ShowDialog chuẩn xác)
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel; // Báo cho Program.cs biết người dùng đã hủy đăng nhập
                this.Close(); // Đóng form đăng nhập ngay lập tức
            }
        }
    }
}