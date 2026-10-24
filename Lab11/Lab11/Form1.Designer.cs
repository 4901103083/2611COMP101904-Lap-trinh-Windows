namespace Lab11
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblMaLop = new Label();
            txtMaLop = new TextBox();
            lblTenLop = new Label();
            txtTenLop = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvLop = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();
            // 
            // lblMaLop
            // 
            lblMaLop.AutoSize = true;
            lblMaLop.Location = new Point(30, 38);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Size = new Size(62, 20);
            lblMaLop.TabIndex = 0;
            lblMaLop.Text = "Mã Lớp:";
            // 
            // txtMaLop
            // 
            txtMaLop.Location = new Point(100, 34);
            txtMaLop.Margin = new Padding(3, 4, 3, 4);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(200, 27);
            txtMaLop.TabIndex = 1;
            // 
            // lblTenLop
            // 
            lblTenLop.AutoSize = true;
            lblTenLop.Location = new Point(30, 88);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Size = new Size(64, 20);
            lblTenLop.TabIndex = 2;
            lblTenLop.Text = "Tên Lớp:";
            // 
            // txtTenLop
            // 
            txtTenLop.Location = new Point(100, 84);
            txtTenLop.Margin = new Padding(3, 4, 3, 4);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(200, 27);
            txtTenLop.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.LimeGreen;
            btnThem.Location = new Point(30, 138);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 38);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Orange;
            btnSua.Location = new Point(120, 138);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 38);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Location = new Point(210, 138);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 38);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = SystemColors.AppWorkspace;
            btnLamMoi.Location = new Point(300, 138);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(75, 38);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(450, 34);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(200, 27);
            txtTimKiem.TabIndex = 8;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.MenuHighlight;
            btnTimKiem.Location = new Point(670, 29);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(75, 38);
            btnTimKiem.TabIndex = 9;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvLop
            // 
            dgvLop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLop.Location = new Point(30, 205);
            dgvLop.Margin = new Padding(3, 4, 3, 4);
            dgvLop.Name = "dgvLop";
            dgvLop.RowHeadersWidth = 51;
            dgvLop.RowTemplate.Height = 24;
            dgvLop.Size = new Size(715, 313);
            dgvLop.TabIndex = 10;
            dgvLop.CellClick += dgvLop_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.a_cartoon_student_reading_a_paper_that_says_case_s_xUapz0KdT2SFNPGc4NpffA_zGTNoVosRHSHP_vnoSy7xw;
            ClientSize = new Size(800, 562);
            Controls.Add(dgvLop);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtTenLop);
            Controls.Add(lblTenLop);
            Controls.Add(txtMaLop);
            Controls.Add(lblMaLop);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Quản lý Lớp học";
            Click += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvLop;
    }
}