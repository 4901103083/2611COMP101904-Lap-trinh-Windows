using System;
using System.Windows.Forms;
using Lab15.Presenters;
using Lab15.Repositories;
using Lab15.Views;

namespace Lab15
{
    public partial class FrmMonHoc : Form, IMonHocView
    {
        private MonHocPresenter _presenter;

        public FrmMonHoc()
        {
            InitializeComponent();
            _presenter = new MonHocPresenter(this, new MonHocRepository());
        }

        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            _presenter.LoadData();
        }

        // --- CÁC HÀM TỪ INTERFACE IMONHOCVIEW ---
        public string MaMonHoc
        {
            get { return txtMaMonHoc.Text.Trim(); }
            set { txtMaMonHoc.Text = value; }
        }

        public string TenMonHoc
        {
            get { return txtTenMonHoc.Text.Trim(); }
            set { txtTenMonHoc.Text = value; }
        }

        public int SoTinChi
        {
            get { return (int)nudSoTinChi.Value; }
            set { nudSoTinChi.Value = value; }
        }

        public bool TrangThai
        {
            get { return chkTrangThai.Checked; }
            set { chkTrangThai.Checked = value; }
        }

        public void HienThiDanhSach(object data)
        {
            dgvMonHoc.DataSource = null;
            dgvMonHoc.DataSource = data;
        }

        public void HienThiThongBao(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void XoaTrangForm()
        {
            MaMonHoc = "";
            TenMonHoc = "";
            SoTinChi = 1;
            TrangThai = true;
            txtMaMonHoc.Enabled = true;
            txtTimKiem.Clear();
            txtMaMonHoc.Focus();
        }

        // --- CÁC SỰ KIỆN NÚT BẤM (CHỈ GỌI PRESENTER) ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            _presenter.Add();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Bổ sung để sửa lỗi Designer
            MessageBox.Show("Chức năng sửa đang được nâng cấp theo mô hình MVP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _presenter.Delete();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            _presenter.Search(keyword);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaTrangForm();
            _presenter.LoadData();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMonHoc.Rows[e.RowIndex];
                MaMonHoc = row.Cells["MaMonHoc"].Value?.ToString();
                TenMonHoc = row.Cells["TenMonHoc"].Value?.ToString();
                SoTinChi = Convert.ToInt32(row.Cells["SoTinChi"].Value);

                var trangThai = row.Cells["TrangThai"].Value;
                TrangThai = trangThai != null && (bool)trangThai;

                txtMaMonHoc.Enabled = false;
            }
        }
    }
}