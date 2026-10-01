using System;
using System.Windows.Forms;

namespace Lab05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoaHoc.Items.Add("C# WinForms cơ bản");
            cboKhoaHoc.Items.Add("SQL Server cơ bản");
            cboKhoaHoc.Items.Add("Web Frontend cơ bản");
            cboKhoaHoc.Items.Add("Lập trình Python cơ bản");

            cboKhoaHoc.SelectedIndex = 0; 
            radOnline.Checked = true;

            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1; 
            TinhTongTien();
        }
        private void TinhTongTien()
        {
            int hocPhi = 0;
            switch (cboKhoaHoc.SelectedIndex)
            {
                case 0: hocPhi = 800000; break; // C# WinForms
                case 1: hocPhi = 700000; break; // SQL Server
                case 2: hocPhi = 750000; break; // Web Frontend
                case 3: hocPhi = 650000; break; // Python
            }

            int soThang = (int)numSoThang.Value;
            int tongTien = hocPhi * soThang; 
            lblTongTien.Text = string.Format("{0:N0} VND", tongTien);
        }
        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }
        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (cboKhoaHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return;
            }
            string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
            string nhanEmail = chkNhanEmail.Checked ? "Có" : "Không";
            string phieuDangKy = $"--- PHIẾU ĐĂNG KÝ ---\n" +
                                 $"Họ tên: {txtHoTen.Text}\n" +
                                 $"SĐT: {txtSoDienThoai.Text}\n" +
                                 $"Ngày sinh: {dtpNgaySinh.Value.ToString("dd/MM/yyyy")}\n" +
                                 $"Khóa học: {cboKhoaHoc.SelectedItem}\n" +
                                 $"Hình thức: {hinhThuc}\n" +
                                 $"Số tháng: {numSoThang.Value}\n" +
                                 $"Tổng tiền: {lblTongTien.Text}\n" +
                                 $"Nhận email: {nhanEmail}";
            MessageBox.Show(phieuDangKy, "Thông tin đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Now; 
            chkNhanEmail.Checked = false;

            cboKhoaHoc.SelectedIndex = 0;
            radOnline.Checked = true;
            numSoThang.Value = 1;

            txtHoTen.Focus();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}