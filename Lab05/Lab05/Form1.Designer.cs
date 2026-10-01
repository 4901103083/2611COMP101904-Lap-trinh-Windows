namespace Lab05
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtHoTen = new TextBox();
            txtSoDienThoai = new TextBox();
            cboKhoaHoc = new ComboBox();
            groupBox1 = new GroupBox();
            chkNhanEmail = new CheckBox();
            dtpNgaySinh = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblTongTien = new Label();
            label7 = new Label();
            numSoThang = new NumericUpDown();
            label6 = new Label();
            radOffline = new RadioButton();
            radOnline = new RadioButton();
            label5 = new Label();
            btnDangKy = new Button();
            btnLamMoi = new Button();
            btnThoat = new Button();
            panel1 = new Panel();
            label8 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(103, 26);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(186, 27);
            txtHoTen.TabIndex = 0;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(103, 71);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(186, 27);
            txtSoDienThoai.TabIndex = 1;
            // 
            // cboKhoaHoc
            // 
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(115, 30);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(151, 28);
            cboKhoaHoc.TabIndex = 5;
            cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.GradientInactiveCaption;
            groupBox1.Controls.Add(chkNhanEmail);
            groupBox1.Controls.Add(dtpNgaySinh);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(txtSoDienThoai);
            groupBox1.Location = new Point(12, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(351, 227);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin học viên";
            // 
            // chkNhanEmail
            // 
            chkNhanEmail.AutoSize = true;
            chkNhanEmail.Location = new Point(6, 184);
            chkNhanEmail.Name = "chkNhanEmail";
            chkNhanEmail.Size = new Size(180, 24);
            chkNhanEmail.TabIndex = 7;
            chkNhanEmail.Text = "Nhận email thông báo";
            chkNhanEmail.UseVisualStyleBackColor = true;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(103, 131);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(240, 27);
            dtpNgaySinh.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 29);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 10;
            label4.Text = "Họ và tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 136);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 9;
            label3.Text = "Ngày sinh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 78);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 8;
            label2.Text = "SĐT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(-78, 86);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.GradientInactiveCaption;
            groupBox2.Controls.Add(lblTongTien);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(numSoThang);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(radOffline);
            groupBox2.Controls.Add(radOnline);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cboKhoaHoc);
            groupBox2.Location = new Point(406, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(382, 227);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin khóa học";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(112, 179);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(72, 20);
            lblTongTien.TabIndex = 17;
            lblTongTien.Text = "Tổng tiền";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 179);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 16;
            label7.Text = "Tổng tiền";
            // 
            // numSoThang
            // 
            numSoThang.Location = new Point(115, 111);
            numSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(150, 27);
            numSoThang.TabIndex = 15;
            numSoThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 118);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 14;
            label6.Text = "Số tháng";
            // 
            // radOffline
            // 
            radOffline.AutoSize = true;
            radOffline.Location = new Point(191, 69);
            radOffline.Name = "radOffline";
            radOffline.Size = new Size(75, 24);
            radOffline.TabIndex = 13;
            radOffline.TabStop = true;
            radOffline.Text = "Offline";
            radOffline.UseVisualStyleBackColor = true;
            // 
            // radOnline
            // 
            radOnline.AutoSize = true;
            radOnline.Checked = true;
            radOnline.Location = new Point(112, 69);
            radOnline.Name = "radOnline";
            radOnline.Size = new Size(73, 24);
            radOnline.TabIndex = 12;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 38);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 11;
            label5.Text = "Khóa học";
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Color.Lime;
            btnDangKy.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDangKy.Location = new Point(103, 318);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(147, 29);
            btnDangKy.TabIndex = 8;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Orange;
            btnLamMoi.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(316, 318);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(147, 29);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Red;
            btnThoat.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(525, 318);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(147, 29);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(label8);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 50);
            panel1.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Elephant", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonFace;
            label8.Location = new Point(223, 9);
            label8.Name = "label8";
            label8.Size = new Size(337, 35);
            label8.TabIndex = 18;
            label8.Text = "ĐĂNG KÝ KHÓA HỌC";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(btnThoat);
            Controls.Add(btnLamMoi);
            Controls.Add(btnDangKy);
            Name = "Form1";
            Text = "ĐĂNG KÝ KHÓA HỌC";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtHoTen;
        private TextBox txtSoDienThoai;
        private ComboBox cboKhoaHoc;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpNgaySinh;
        private CheckBox chkNhanEmail;
        private GroupBox groupBox2;
        private Label label5;
        private Label label7;
        private NumericUpDown numSoThang;
        private Label label6;
        private RadioButton radOffline;
        private RadioButton radOnline;
        private Label lblTongTien;
        private Button btnDangKy;
        private Button btnLamMoi;
        private Button btnThoat;
        private Panel panel1;
        private Label label8;
    }
}
