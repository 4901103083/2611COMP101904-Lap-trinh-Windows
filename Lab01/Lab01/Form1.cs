namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Sư phạm");
            cboKhoa.Items.Add("Ngôn ngữ Anh");
            cboKhoa.Items.Add("Kinh tế");
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus(); 
                return; 
            }
            if (string.IsNullOrWhiteSpace(txtNamSinh.Text) || !int.TryParse(txtNamSinh.Text, out int namSinh))
            {
                MessageBox.Show("Năm sinh không hợp lệ (không được để trống và phải là số)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamSinh.Focus();
                return;
            }

            // Năm sinh phải nằm trong khoảng từ 1900 đến năm hiện tại
            int namHienTai = DateTime.Now.Year;
            if (namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show($"Năm sinh phải nằm trong khoảng từ 1900 đến {namHienTai}!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamSinh.Focus();
                return;
            }

            // Email không được rỗng
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            // Phải chọn giới tính
            if (radNam.Checked == false && radNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Phải chọn khoa hoặc lớp
            if (cboKhoa.SelectedIndex == -1) // -1 nghĩa là chưa có mục nào được chọn
            {
                MessageBox.Show("Vui lòng chọn khoa hoặc lớp!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboKhoa.Focus();
                return;
            }

            // 2. XỬ LÝ DỮ LIỆU SAU KHI ĐÃ NHẬP ĐÚNG
            string hoTen = txtHoTen.Text.Trim();
            int tuoi = namHienTai - namSinh; // Tính tuổi bằng năm hiện tại trừ năm sinh
            string email = txtEmail.Text.Trim();
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ"; // Nếu radNam được check thì lấy chữ "Nam", ngược lại lấy "Nữ"
            string khoa = cboKhoa.SelectedItem.ToString();

            // 3. TẠO CHUỖI KẾT QUẢ VÀ HIỂN THỊ
            // Dùng \r\n để xuống dòng trong TextBox
            string ketQua = "THÔNG TIN SINH VIÊN\r\n" +
                            $"Họ tên: {hoTen}\r\n" +
                            $"Tuổi: {tuoi}\r\n" +
                            $"Email: {email}\r\n" +
                            $"Giới tính: {gioiTinh}\r\n" +
                            $"Khoa/Lớp: {khoa}";

            // Hiển thị ra ô TextBox Kết quả ở dưới cùng
            txtKetQua.Text = ketQua;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();
            txtKetQua.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            cboKhoa.SelectedIndex = -1;
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
