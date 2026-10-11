using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lab07.Models;

namespace Lab07
{
    public partial class FrmProduct : Form
    {
        // Danh sách lưu trữ sản phẩm trong bộ nhớ
        private BindingList<Product> _productList = new BindingList<Product>();

        public FrmProduct()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form vừa mở lên
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            // Tạo sẵn vài dữ liệu mẫu để dễ test
            _productList.Add(new Product { ProductId = "SP01", ProductName = "Bàn phím cơ", Category = "Phụ kiện", Price = 550000, Quantity = 15 });
            _productList.Add(new Product { ProductId = "SP02", ProductName = "Chuột không dây", Category = "Phụ kiện", Price = 250000, Quantity = 30 });

            // Gắn danh sách vào bảng DataGridView
            HienThiDanhSach(_productList);
        }

        // Hàm hỗ trợ hiển thị dữ liệu lên DataGridView và đặt lại tên cột tiếng Việt
        private void HienThiDanhSach(object dataSource)
        {
            dgvSanPham.DataSource = null;
            dgvSanPham.DataSource = dataSource;

            if (dgvSanPham.Columns.Count > 0)
            {
                dgvSanPham.Columns["ProductId"].HeaderText = "Mã SP";
                dgvSanPham.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dgvSanPham.Columns["Category"].HeaderText = "Loại SP";
                dgvSanPham.Columns["Price"].HeaderText = "Đơn giá";
                dgvSanPham.Columns["Quantity"].HeaderText = "Số lượng";
            }
        }

        // Hàm kiểm tra dữ liệu nhập vào (Validation)
        private bool KiemTraDuLieu(out decimal price, out int quantity)
        {
            price = 0;
            quantity = 0;

            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtLoaiSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã, Tên và Loại sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out price) || price < 0)
            {
                MessageBox.Show("Đơn giá phải là số và không được âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out quantity) || quantity < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên và không được âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // 1. Nút THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu(out decimal price, out int quantity)) return;

            string maSP = txtMaSP.Text.Trim();

            // Kiểm tra trùng mã sản phẩm
            if (_productList.Any(p => p.ProductId.Equals(maSP, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại! Vui lòng nhập mã khác.", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thêm mới vào danh sách
            Product newProduct = new Product
            {
                ProductId = maSP,
                ProductName = txtTenSP.Text.Trim(),
                Category = txtLoaiSP.Text.Trim(),
                Price = price,
                Quantity = quantity
            };

            _productList.Add(newProduct);
            HienThiDanhSach(_productList);
            LamMoiO_Nhap();
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 2. Nút SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            var existingProduct = _productList.FirstOrDefault(p => p.ProductId.Equals(maSP, StringComparison.OrdinalIgnoreCase));

            if (existingProduct == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm có mã này để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!KiemTraDuLieu(out decimal price, out int quantity)) return;

            // Cập nhật thông tin
            existingProduct.ProductName = txtTenSP.Text.Trim();
            existingProduct.Category = txtLoaiSP.Text.Trim();
            existingProduct.Price = price;
            existingProduct.Quantity = quantity;

            HienThiDanhSach(_productList);
            LamMoiO_Nhap();
            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. Nút XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            var existingProduct = _productList.FirstOrDefault(p => p.ProductId.Equals(maSP, StringComparison.OrdinalIgnoreCase));

            if (existingProduct == null)
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập đúng Mã sản phẩm cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận trước khi xóa
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{existingProduct.ProductName}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _productList.Remove(existingProduct);
                HienThiDanhSach(_productList);
                LamMoiO_Nhap();
                MessageBox.Show("Đã xóa sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 4. Nút LÀM MỚI
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiO_Nhap();
            HienThiDanhSach(_productList); // Hiển thị lại toàn bộ danh sách (hữu ích sau khi tìm kiếm)
        }

        private void LamMoiO_Nhap()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtLoaiSP.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtTimKiem.Clear();
            txtMaSP.Enabled = true; // Cho phép nhập lại Mã SP
            txtMaSP.Focus();
        }

        // 5. Nút TÌM KIẾM
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                HienThiDanhSach(_productList);
                return;
            }

            // Tìm theo mã hoặc theo tên sản phẩm
            var ketQua = _productList.Where(p =>
                p.ProductId.ToLower().Contains(keyword) ||
                p.ProductName.ToLower().Contains(keyword)).ToList();

            HienThiDanhSach(ketQua);
        }

        // Sự kiện khi click vào 1 dòng trên bảng DataGridView -> Đổ dữ liệu ngược lên các ô TextBox
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSanPham.Rows.Count)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["ProductId"].Value?.ToString();
                txtTenSP.Text = row.Cells["ProductName"].Value?.ToString();
                txtLoaiSP.Text = row.Cells["Category"].Value?.ToString();
                txtDonGia.Text = row.Cells["Price"].Value?.ToString();
                txtSoLuong.Text = row.Cells["Quantity"].Value?.ToString();

                // Khóa ô Mã SP lại khi đang chọn để tránh sửa nhầm khóa chính
                txtMaSP.Enabled = false;
            }
        }
    }
}