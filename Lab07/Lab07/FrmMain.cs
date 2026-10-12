using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lab07.Models;

namespace Lab07
{
    public partial class FrmMain : Form
    {
        private User _currentUser;

        public FrmMain(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 1. Đổi màu nền vùng xám của MDI Container sang màu xanh nhạt dễ nhìn (giống Form1)
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(215, 228, 242);
                    break;
                }
            }

            // 2. Hiển thị thông tin người dùng và thời gian ở thanh dưới đáy
            lblUserInfo.Text = $"👤 Người dùng: {_currentUser.FullName} | Vai trò: {_currentUser.Role}";
            lblTime.Text = $"🕒 Thời gian đăng nhập: {DateTime.Now:dd/MM/yyyy HH:mm}";
        }

        // Hàm mở Form con không bị trùng lặp
        private void OpenChildForm(Form childForm)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate();
                    return;
                }
            }
            childForm.MdiParent = this;
            childForm.Show();
        }

        // 1. Menu: Quản lý sản phẩm
        private void menuSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmProduct());
        }

        // 2. Menu: Quản lý khách hàng
        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCustomer());
        }

        // 3. Menu: Giới thiệu
        private void menuGioiThieu_Click(object sender, EventArgs e)
        {
            FrmAbout frm = new FrmAbout();
            frm.ShowDialog();
        }

        // 4. Menu: Đăng xuất
        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn đăng xuất khỏi hệ thống?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // 5. Menu: Thoát hệ thống
        private void menuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}