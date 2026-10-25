using System;
using System.Windows.Forms;
using Lab14.BLL;
using Lab14.Models;

namespace Lab14
{
    public partial class FrmMonHoc : Form
    {
        private MonHocBLL bll = new MonHocBLL();

        public FrmMonHoc()
        {
            InitializeComponent();
        }

        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            dgvMonHoc.DataSource = null;
            dgvMonHoc.DataSource = bll.GetAll();

            // Đổi tên cột cho đẹp
            if (dgvMonHoc.Columns.Count > 0)
            {
                dgvMonHoc.Columns["MaMonHoc"].HeaderText = "Mã Môn Học";
                dgvMonHoc.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";
                dgvMonHoc.Columns["SoTinChi"].HeaderText = "Số Tín Chỉ";
                dgvMonHoc.Columns["TrangThai"].HeaderText = "Trạng Thái (1=Còn, 0=Hủy)";
            }
        }

        // Bấm vào danh sách hiện dữ liệu lên textbox
        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMonHoc.Rows[e.RowIndex];
                txtMaMonHoc.Text = row.Cells["MaMonHoc"].Value?.ToString();
                txtTenMonHoc.Text = row.Cells["TenMonHoc"].Value?.ToString();
                nudSoTinChi.Value = Convert.ToDecimal(row.Cells["SoTinChi"].Value);

                var trangThai = row.Cells["TrangThai"].Value;
                chkTrangThai.Checked = trangThai != null && (bool)trangThai;

                // Khóa mã môn học lại không cho sửa khi đang chọn để update/delete
                txtMaMonHoc.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc
            {
                MaMonHoc = txtMaMonHoc.Text.Trim(),
                TenMonHoc = txtTenMonHoc.Text.Trim(),
                SoTinChi = (int)nudSoTinChi.Value,
                TrangThai = chkTrangThai.Checked
            };

            string errorMsg = bll.Add(mh);
            if (errorMsg == "") // Thành công
            {
                MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSach();
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show(errorMsg, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc
            {
                MaMonHoc = txtMaMonHoc.Text.Trim(),
                TenMonHoc = txtTenMonHoc.Text.Trim(),
                SoTinChi = (int)nudSoTinChi.Value,
                TrangThai = chkTrangThai.Checked
            };

            string errorMsg = bll.Update(mh);
            if (errorMsg == "")
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSach();
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maMonHoc = txtMaMonHoc.Text.Trim();
            if (string.IsNullOrEmpty(maMonHoc))
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hộp thoại xác nhận xóa theo đúng yêu cầu đề bài
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa môn học mã '{maMonHoc}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string errorMsg = bll.Delete(maMonHoc);
                if (errorMsg == "")
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach();
                    btnLamMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaMonHoc.Enabled = true; // Mở khóa lại ô mã môn học
            txtMaMonHoc.Clear();
            txtTenMonHoc.Clear();
            nudSoTinChi.Value = 1;
            chkTrangThai.Checked = true;
            txtTimKiem.Clear();
            LoadDanhSach();
            txtMaMonHoc.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvMonHoc.DataSource = bll.Search(keyword);
        }
    }
}