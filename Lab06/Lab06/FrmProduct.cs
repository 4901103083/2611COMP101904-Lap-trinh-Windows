using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Lab06
{
    public partial class FrmProduct : Form
    {
        private BindingList<Product> productList;
        private BindingSource bindingSource;
        private ErrorProvider errorProvider;
        private string currentImagePath = "";

        public FrmProduct()
        {
            InitializeComponent();
            productList = new BindingList<Product>();
            bindingSource = new BindingSource();
            errorProvider = new ErrorProvider();
        }

        // Sự kiện Form Load
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cboLoaiSP.Items.AddRange(new string[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });
            if (cboLoaiSP.Items.Count > 0) cboLoaiSP.SelectedIndex = 0;

            // Dữ liệu mẫu
            productList.Add(new Product { MaSP = "SP01", TenSP = "Laptop Dell", LoaiSP = "Điện tử", DonGia = 15000000, SoLuong = 10, NgayNhap = DateTime.Now.AddDays(-5), ConKinhDoanh = true, DuongDanAnh = "" });
            productList.Add(new Product { MaSP = "SP02", TenSP = "Bút bi Thiên Long", LoaiSP = "Văn phòng", DonGia = 5000, SoLuong = 100, NgayNhap = DateTime.Now.AddDays(-2), ConKinhDoanh = true, DuongDanAnh = "" });
            productList.Add(new Product { MaSP = "SP03", TenSP = "Nồi cơm điện Supor", LoaiSP = "Gia dụng", DonGia = 500000, SoLuong = 20, NgayNhap = DateTime.Now, ConKinhDoanh = true, DuongDanAnh = "" });

            bindingSource.DataSource = productList;
            dgvProducts.DataSource = bindingSource;

            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;

            UpdateStatus("Đã tải dữ liệu thành công.");
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = $"Trạng thái: {message} | Tổng số SP: {productList.Count}";
        }

        private void ClearInput()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            if (cboLoaiSP.Items.Count > 0) cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 0;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Now;
            chkConKinhDoanh.Checked = true;
            currentImagePath = "";
            picProduct.Image = null;

            txtMaSP.Focus();
            errorProvider.Clear();
            bindingSource.DataSource = productList;
            UpdateStatus("Đã làm mới form.");
        }

        private bool ValidateInput(bool isUpdating = false)
        {
            errorProvider.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                errorProvider.SetError(txtMaSP, "Mã SP không được rỗng.");
                isValid = false;
            }
            else if (!isUpdating && productList.Any(p => p.MaSP.Equals(txtMaSP.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(txtMaSP, "Mã SP đã tồn tại.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errorProvider.SetError(txtTenSP, "Tên SP không được rỗng.");
                isValid = false;
            }

            if (numDonGia.Value <= 0)
            {
                errorProvider.SetError(numDonGia, "Đơn giá phải > 0.");
                isValid = false;
            }

            if (numSoLuong.Value < 0)
            {
                errorProvider.SetError(numSoLuong, "Số lượng phải >= 0.");
                isValid = false;
            }

            if (dtpNgayNhap.Value.Date > DateTime.Now.Date)
            {
                errorProvider.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn hôm nay.");
                isValid = false;
            }

            return isValid;
        }

        private void LoadProductToForm()
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product selectedProduct)
            {
                txtMaSP.Text = selectedProduct.MaSP;
                txtTenSP.Text = selectedProduct.TenSP;
                cboLoaiSP.SelectedItem = selectedProduct.LoaiSP;
                numDonGia.Value = selectedProduct.DonGia;
                numSoLuong.Value = selectedProduct.SoLuong;
                dtpNgayNhap.Value = selectedProduct.NgayNhap;
                chkConKinhDoanh.Checked = selectedProduct.ConKinhDoanh;
                currentImagePath = selectedProduct.DuongDanAnh;

                if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                    picProduct.Image = Image.FromFile(currentImagePath);
                else
                    picProduct.Image = null;
            }
        }

        // Click vào dòng trên DataGridView
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            LoadProductToForm();
        }

        // Nút Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput(isUpdating: false))
            {
                Product newProduct = new Product
                {
                    MaSP = txtMaSP.Text.Trim(),
                    TenSP = txtTenSP.Text.Trim(),
                    LoaiSP = cboLoaiSP.SelectedItem.ToString(),
                    DonGia = numDonGia.Value,
                    SoLuong = (int)numSoLuong.Value,
                    NgayNhap = dtpNgayNhap.Value,
                    ConKinhDoanh = chkConKinhDoanh.Checked,
                    DuongDanAnh = currentImagePath
                };

                productList.Add(newProduct);
                ClearInput();
                UpdateStatus($"Đã thêm: {newProduct.TenSP}");
            }
        }

        // Nút Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Chọn một sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateInput(isUpdating: true))
            {
                Product selectedProduct = dgvProducts.CurrentRow.DataBoundItem as Product;

                if (selectedProduct.MaSP != txtMaSP.Text.Trim() && productList.Any(p => p.MaSP.Equals(txtMaSP.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    errorProvider.SetError(txtMaSP, "Mã SP đã tồn tại.");
                    return;
                }

                selectedProduct.MaSP = txtMaSP.Text.Trim();
                selectedProduct.TenSP = txtTenSP.Text.Trim();
                selectedProduct.LoaiSP = cboLoaiSP.SelectedItem.ToString();
                selectedProduct.DonGia = numDonGia.Value;
                selectedProduct.SoLuong = (int)numSoLuong.Value;
                selectedProduct.NgayNhap = dtpNgayNhap.Value;
                selectedProduct.ConKinhDoanh = chkConKinhDoanh.Checked;
                selectedProduct.DuongDanAnh = currentImagePath;

                dgvProducts.Refresh();
                UpdateStatus($"Đã cập nhật: {selectedProduct.TenSP}");
            }
        }

        // Nút Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product selectedProduct = dgvProducts.CurrentRow.DataBoundItem as Product;

            if (MessageBox.Show($"Xóa sản phẩm '{selectedProduct.TenSP}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                productList.Remove(selectedProduct);
                ClearInput();
                UpdateStatus("Đã xóa sản phẩm.");
            }
        }

        // Nút Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã hoặc tên sản phẩm:", "Tìm kiếm", "").Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                var filteredList = productList.Where(p =>
                    p.MaSP.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.TenSP.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                bindingSource.DataSource = filteredList;
                UpdateStatus($"Tìm thấy {filteredList.Count} kết quả.");
            }
            else
            {
                bindingSource.DataSource = productList;
            }
        }

        // Nút Làm mới
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        // Nút Chọn ảnh
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    picProduct.Image = Image.FromFile(currentImagePath);
                    picProduct.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}