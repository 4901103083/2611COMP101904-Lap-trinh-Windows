using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Lab11
{
    public partial class Form1 : Form
    {
        // Thay đổi chuỗi kết nối khớp với máy của bạn
        string connectionString = @"Server=localhost\MSSQLSERVER03;Database=EduManagerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        // F1: Tự động load dữ liệu
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM LOP";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLop.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // F2: Click chọn dòng
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLop.Rows[e.RowIndex];
                txtMaLop.Text = row.Cells["MaLop"].Value?.ToString();
                txtTenLop.Text = row.Cells["TenLop"].Value?.ToString();
                txtMaLop.Enabled = false;
            }
        }

        // F7: Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTimKiem.Clear();
            txtMaLop.Enabled = true;
            txtMaLop.Focus();
            LoadData();
        }

        // F3 & F8: Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) || string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Mã lớp và Tên lớp không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Kiểm tra trùng mã
                    string checkQuery = "SELECT COUNT(*) FROM LOP WHERE MaLop = @MaLop";
                    using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                        int count = (int)cmdCheck.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã lớp đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Thực hiện thêm
                    string insertQuery = "INSERT INTO LOP (MaLop, TenLop) VALUES (@MaLop, @TenLop)";
                    using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                        cmdInsert.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // F4 & F8: Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Enabled)
            {
                MessageBox.Show("Vui lòng chọn một lớp từ danh sách bên dưới để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Tên lớp không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE LOP SET TenLop = @TenLop WHERE MaLop = @MaLop";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                        cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // F5 & F8: Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Enabled)
            {
                MessageBox.Show("Vui lòng chọn một lớp từ danh sách để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // Kiểm tra lớp có sinh viên không
                        string checkQuery = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @MaLop";
                        using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                            int count = (int)cmdCheck.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show("Không thể xóa lớp đang có sinh viên!", "Lỗi Khóa Ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Thực hiện xóa
                        string deleteQuery = "DELETE FROM LOP WHERE MaLop = @MaLop";
                        using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn))
                        {
                            cmdDelete.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                            cmdDelete.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // F6 & F8: Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string searchQuery = "SELECT * FROM LOP WHERE MaLop LIKE @TuKhoa OR TenLop LIKE @TuKhoa";
                    using (SqlCommand cmd = new SqlCommand(searchQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvLop.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}