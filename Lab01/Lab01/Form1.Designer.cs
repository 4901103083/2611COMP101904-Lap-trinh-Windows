namespace Lab01
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
            btnThoat = new Button();
            btnXoa = new Button();
            btnHienThi = new Button();
            lblTitle = new Label();
            txtHoTen = new TextBox();
            txtEmail = new TextBox();
            txtNamSinh = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            radNam = new RadioButton();
            radNu = new RadioButton();
            cboKhoa = new ComboBox();
            label4 = new Label();
            txtKetQua = new TextBox();
            label5 = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(500, 409);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(325, 409);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnHienThi
            // 
            btnHienThi.Location = new Point(132, 409);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(94, 29);
            btnHienThi.TabIndex = 2;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(310, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(161, 20);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "THÔNG TIN SINH VIÊN";
            lblTitle.Click += label1_Click;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(160, 77);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(125, 27);
            txtHoTen.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(430, 73);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 5;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // txtNamSinh
            // 
            txtNamSinh.Location = new Point(160, 139);
            txtNamSinh.Name = "txtNamSinh";
            txtNamSinh.Size = new Size(125, 27);
            txtNamSinh.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 84);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 7;
            label1.Text = "Họ và tên";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(358, 80);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 8;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 147);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 9;
            label3.Text = "Năm sinh ";
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(6, 38);
            radNam.Name = "radNam";
            radNam.Size = new Size(62, 24);
            radNam.TabIndex = 10;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(100, 38);
            radNu.Name = "radNu";
            radNu.Size = new Size(50, 24);
            radNu.TabIndex = 11;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(430, 139);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(151, 28);
            cboKhoa.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(364, 142);
            label4.Name = "label4";
            label4.Size = new Size(40, 25);
            label4.TabIndex = 13;
            label4.Text = "Khoa";
            label4.UseCompatibleTextRendering = true;
            // 
            // txtKetQua
            // 
            txtKetQua.Location = new Point(103, 284);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.Size = new Size(513, 109);
            txtKetQua.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(103, 261);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 15;
            label5.Text = "Kết quả";
            label5.Click += label5_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radNu);
            groupBox1.Controls.Add(radNam);
            groupBox1.Location = new Point(76, 183);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(156, 62);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giới tính";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(txtKetQua);
            Controls.Add(label4);
            Controls.Add(cboKhoa);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNamSinh);
            Controls.Add(txtEmail);
            Controls.Add(txtHoTen);
            Controls.Add(lblTitle);
            Controls.Add(btnHienThi);
            Controls.Add(btnXoa);
            Controls.Add(btnThoat);
            Name = "Form1";
            Text = "Lab01";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThoat;
        private Button btnXoa;
        private Button btnHienThi;
        private Label lblTitle;
        private TextBox txtHoTen;
        private TextBox txtEmail;
        private TextBox txtNamSinh;
        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton radNam;
        private RadioButton radNu;
        private ComboBox cboKhoa;
        private Label label4;
        private TextBox txtKetQua;
        private Label label5;
        private GroupBox groupBox1;
    }
}
