using System;
using System.Data;
using System.Windows.Forms;
using Lab12.DAL; // Bổ sung thư viện để gọi class từ thư mục DAL

namespace Lab12
{
    public partial class Form1 : Form
    {
        // Khai báo đối tượng DAL và DataTable để lưu dữ liệu
        private KetQuaDAL dal = new KetQuaDAL();
        private DataTable dtKetQua;

        public Form1()
        {
            InitializeComponent();
            // Gắn các sự kiện (Events) để không cần nhấp đúp thủ công bên giao diện Design
            this.Load += Form1_Load;
            btnTaiDanhSach.Click += btnTaiDanhSach_Click;
            btnLuuTatCa.Click += btnLuuTatCa_Click;
            dgvKetQua.CellValidating += dgvKetQua_CellValidating;
        }

        // 1. Khi mở Form: Binding dữ liệu vào ComboBox[cite: 8]
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Tải danh sách Lớp
                cboLop.DataSource = dal.GetLop();
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";

                // Tải danh sách Môn học
                cboMonHoc.DataSource = dal.GetMonHoc();
                cboMonHoc.DisplayMember = "TenMon";
                cboMonHoc.ValueMember = "MaMon";

                lblTrangThai.Text = "Kết nối CSDL thành công. Sẵn sàng.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Nút Tải danh sách: Hiển thị sinh viên lên DataGridView[cite: 9]
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null || cboMonHoc.SelectedValue == null) return;

            string maLop = cboLop.SelectedValue.ToString();
            string maMon = cboMonHoc.SelectedValue.ToString();

            try
            {
                dtKetQua = dal.GetKetQua(maLop, maMon);
                dgvKetQua.DataSource = dtKetQua;

                // Khóa 2 cột MaSV và HoTen (Không cho phép người dùng sửa)
                dgvKetQua.Columns["MaSV"].HeaderText = "Mã SV";
                dgvKetQua.Columns["MaSV"].ReadOnly = true;

                dgvKetQua.Columns["HoTen"].HeaderText = "Họ Tên";
                dgvKetQua.Columns["HoTen"].ReadOnly = true;
                dgvKetQua.Columns["HoTen"].Width = 150;

                // Cho phép nhập Điểm và Ghi chú[cite: 9]
                dgvKetQua.Columns["Diem"].HeaderText = "Điểm";
                dgvKetQua.Columns["GhiChu"].HeaderText = "Ghi Chú";
                dgvKetQua.Columns["GhiChu"].Width = 200;

                lblTrangThai.Text = $"Đã tải {dtKetQua.Rows.Count} sinh viên.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Nút Lưu tất cả: Gọi Transaction xử lý lưu nhiều dòng[cite: 9]
        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            if (dtKetQua == null || dtKetQua.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lệnh này bắt buộc phải có để xác nhận các ô đang gõ dở trên lưới được đẩy xuống DataTable
            dgvKetQua.EndEdit();

            string maMon = cboMonHoc.SelectedValue.ToString();

            try
            {
                lblTrangThai.Text = "Đang xử lý lưu dữ liệu...";
                int soDong = 0;

                // Gọi DAL để lưu bằng Transaction
                bool ketQua = dal.LuuDiemTransaction(dtKetQua, maMon, out soDong);

                if (ketQua)
                {
                    // Thông báo số dòng đã lưu và Commit[cite: 9]
                    MessageBox.Show($"Đã lưu thành công điểm cho {soDong} sinh viên!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblTrangThai.Text = $"Lưu thành công {soDong} dòng.";

                    // Tải lại danh sách để làm mới giao diện
                    btnTaiDanhSach.PerformClick();
                }
            }
            catch (Exception ex)
            {
                // Nếu 1 dòng lỗi, bắt sự kiện Rollback từ DAL và thông báo[cite: 9]
                MessageBox.Show(ex.Message, "Lỗi khi lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTrangThai.Text = "Lưu thất bại, đã Rollback toàn bộ.";
            }
        }

        // 4. Kiểm tra Validation trực tiếp trên DataGridView (Phải là số, từ 0 đến 10)[cite: 9]
        private void dgvKetQua_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Chỉ kiểm tra khi người dùng nhập vào cột Điểm
            if (dgvKetQua.Columns[e.ColumnIndex].Name == "Diem")
            {
                string giaTri = e.FormattedValue.ToString();

                // Nếu người dùng xóa trống ô (chưa có điểm), bỏ qua kiểm tra
                if (string.IsNullOrWhiteSpace(giaTri)) return;

                // Nếu dữ liệu nhập vào không phải là số (double) hoặc nằm ngoài khoảng 0-10
                if (!double.TryParse(giaTri, out double diem) || diem < 0 || diem > 10)
                {
                    MessageBox.Show("Điểm phải là số và nằm trong khoảng từ 0 đến 10!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true; // Hủy thao tác, ép người dùng sửa lại cho đúng
                }
            }
        }
    }
}