using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lab07.Models;

namespace Lab07
{
    public partial class FrmCustomer : Form
    {
        private BindingList<Customer> _customerList = new BindingList<Customer>();

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            // Dữ liệu mẫu
            _customerList.Add(new Customer { CustomerId = "KH01", FullName = "Nguyễn Văn A", Phone = "0901234567", Address = "Quận 5, TP.HCM" });
            _customerList.Add(new Customer { CustomerId = "KH02", FullName = "Trần Thị B", Phone = "0987654321", Address = "Quận 1, TP.HCM" });

            HienThiDanhSach(_customerList);
        }

        private void HienThiDanhSach(object dataSource)
        {
            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = dataSource;

            if (dgvKhachHang.Columns.Count > 0)
            {
                dgvKhachHang.Columns["CustomerId"].HeaderText = "Mã KH";
                dgvKhachHang.Columns["FullName"].HeaderText = "Tên khách hàng";
                dgvKhachHang.Columns["Phone"].HeaderText = "Số điện thoại";
                dgvKhachHang.Columns["Address"].HeaderText = "Địa chỉ";
            }
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra SĐT chỉ chứa chữ số
            if (!txtSDT.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string maKH = txtMaKH.Text.Trim();
            if (_customerList.Any(c => c.CustomerId.Equals(maKH, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại!", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer newCustomer = new Customer
            {
                CustomerId = maKH,
                FullName = txtTenKH.Text.Trim(),
                Phone = txtSDT.Text.Trim(),
                Address = txtDiaChi.Text.Trim()
            };

            _customerList.Add(newCustomer);
            HienThiDanhSach(_customerList);
            LamMoiO_Nhap();
            MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            var existingCustomer = _customerList.FirstOrDefault(c => c.CustomerId.Equals(maKH, StringComparison.OrdinalIgnoreCase));

            if (existingCustomer == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!KiemTraDuLieu()) return;

            existingCustomer.FullName = txtTenKH.Text.Trim();
            existingCustomer.Phone = txtSDT.Text.Trim();
            existingCustomer.Address = txtDiaChi.Text.Trim();

            HienThiDanhSach(_customerList);
            LamMoiO_Nhap();
            MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            var existingCustomer = _customerList.FirstOrDefault(c => c.CustomerId.Equals(maKH, StringComparison.OrdinalIgnoreCase));

            if (existingCustomer == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{existingCustomer.FullName}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _customerList.Remove(existingCustomer);
                HienThiDanhSach(_customerList);
                LamMoiO_Nhap();
                MessageBox.Show("Đã xóa khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiO_Nhap();
            HienThiDanhSach(_customerList);
        }

        private void LamMoiO_Nhap()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();
            txtMaKH.Enabled = true;
            txtMaKH.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                HienThiDanhSach(_customerList);
                return;
            }

            var ketQua = _customerList.Where(c =>
                c.CustomerId.ToLower().Contains(keyword) ||
                c.FullName.ToLower().Contains(keyword) ||
                c.Phone.Contains(keyword)).ToList();

            HienThiDanhSach(ketQua);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["CustomerId"].Value?.ToString();
                txtTenKH.Text = row.Cells["FullName"].Value?.ToString();
                txtSDT.Text = row.Cells["Phone"].Value?.ToString();
                txtDiaChi.Text = row.Cells["Address"].Value?.ToString();

                txtMaKH.Enabled = false;
            }
        }
    }
}