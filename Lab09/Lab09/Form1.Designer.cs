namespace Lab09
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
            grpInput = new GroupBox();
            btnChooseImage = new Button();
            picAvatar = new PictureBox();
            lblAvatar = new Label();
            cboCohort = new ComboBox();
            lblCohort = new Label();
            cboClass = new ComboBox();
            lblClass = new Label();
            cboFaculty = new ComboBox();
            lblFaculty = new Label();
            cboGender = new ComboBox();
            lblGender = new Label();
            dtpDob = new DateTimePicker();
            lblDob = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtStudentId = new TextBox();
            lblStudentId = new Label();
            grpPreview = new GroupBox();
            pnlCardPreview = new Panel();
            pnlActions = new Panel();
            btnExit = new Button();
            btnPrint = new Button();
            btnPrintPreview = new Button();
            btnReset = new Button();
            btnSavePng = new Button();
            btnCardColor = new Button();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            grpPreview.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Controls.Add(btnChooseImage);
            grpInput.Controls.Add(picAvatar);
            grpInput.Controls.Add(lblAvatar);
            grpInput.Controls.Add(cboCohort);
            grpInput.Controls.Add(lblCohort);
            grpInput.Controls.Add(cboClass);
            grpInput.Controls.Add(lblClass);
            grpInput.Controls.Add(cboFaculty);
            grpInput.Controls.Add(lblFaculty);
            grpInput.Controls.Add(cboGender);
            grpInput.Controls.Add(lblGender);
            grpInput.Controls.Add(dtpDob);
            grpInput.Controls.Add(lblDob);
            grpInput.Controls.Add(txtFullName);
            grpInput.Controls.Add(lblFullName);
            grpInput.Controls.Add(txtStudentId);
            grpInput.Controls.Add(lblStudentId);
            grpInput.Location = new Point(17, 16);
            grpInput.Margin = new Padding(3, 4, 3, 4);
            grpInput.Name = "grpInput";
            grpInput.Padding = new Padding(3, 4, 3, 4);
            grpInput.Size = new Size(423, 667);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin sinh viên";
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(291, 400);
            btnChooseImage.Margin = new Padding(3, 4, 3, 4);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(109, 47);
            btnChooseImage.TabIndex = 16;
            btnChooseImage.Text = "Chọn ảnh...";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.WhiteSmoke;
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(143, 400);
            picAvatar.Margin = new Padding(3, 4, 3, 4);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(137, 199);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 15;
            picAvatar.TabStop = false;
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Location = new Point(21, 407);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(116, 20);
            lblAvatar.TabIndex = 14;
            lblAvatar.Text = "Ảnh đại diện (*):";
            // 
            // cboCohort
            // 
            cboCohort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCohort.FormattingEnabled = true;
            cboCohort.Location = new Point(143, 343);
            cboCohort.Margin = new Padding(3, 4, 3, 4);
            cboCohort.Name = "cboCohort";
            cboCohort.Size = new Size(257, 28);
            cboCohort.TabIndex = 13;
            // 
            // lblCohort
            // 
            lblCohort.AutoSize = true;
            lblCohort.Location = new Point(21, 347);
            lblCohort.Name = "lblCohort";
            lblCohort.Size = new Size(74, 20);
            lblCohort.TabIndex = 12;
            lblCohort.Text = "Khóa học:";
            // 
            // cboClass
            // 
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(143, 292);
            cboClass.Margin = new Padding(3, 4, 3, 4);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(257, 28);
            cboClass.TabIndex = 11;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(21, 296);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(37, 20);
            lblClass.TabIndex = 10;
            lblClass.Text = "Lớp:";
            // 
            // cboFaculty
            // 
            cboFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFaculty.FormattingEnabled = true;
            cboFaculty.Location = new Point(143, 241);
            cboFaculty.Margin = new Padding(3, 4, 3, 4);
            cboFaculty.Name = "cboFaculty";
            cboFaculty.Size = new Size(257, 28);
            cboFaculty.TabIndex = 9;
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.Location = new Point(21, 245);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(46, 20);
            lblFaculty.TabIndex = 8;
            lblFaculty.Text = "Khoa:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(143, 191);
            cboGender.Margin = new Padding(3, 4, 3, 4);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(257, 28);
            cboGender.TabIndex = 7;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(21, 195);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(68, 20);
            lblGender.TabIndex = 6;
            lblGender.Text = "Giới tính:";
            // 
            // dtpDob
            // 
            dtpDob.Format = DateTimePickerFormat.Short;
            dtpDob.Location = new Point(143, 140);
            dtpDob.Margin = new Padding(3, 4, 3, 4);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(257, 27);
            dtpDob.TabIndex = 5;
            dtpDob.Value = new DateTime(2005, 1, 1, 0, 0, 0, 0);
            // 
            // lblDob
            // 
            lblDob.AutoSize = true;
            lblDob.Location = new Point(21, 144);
            lblDob.Name = "lblDob";
            lblDob.Size = new Size(77, 20);
            lblDob.TabIndex = 4;
            lblDob.Text = "Ngày sinh:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(143, 89);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.MaxLength = 40;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(257, 27);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(21, 93);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(77, 20);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ tên (*):";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(143, 39);
            txtStudentId.Margin = new Padding(3, 4, 3, 4);
            txtStudentId.MaxLength = 15;
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(257, 27);
            txtStudentId.TabIndex = 1;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(21, 43);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(114, 20);
            lblStudentId.TabIndex = 0;
            lblStudentId.Text = "Mã sinh viên (*):";
            // 
            // grpPreview
            // 
            grpPreview.Controls.Add(pnlCardPreview);
            grpPreview.Location = new Point(457, 16);
            grpPreview.Margin = new Padding(3, 4, 3, 4);
            grpPreview.Name = "grpPreview";
            grpPreview.Padding = new Padding(3, 4, 3, 4);
            grpPreview.Size = new Size(617, 520);
            grpPreview.TabIndex = 1;
            grpPreview.TabStop = false;
            grpPreview.Text = "Xem trước Thẻ Sinh Viên (GDI+ Preview)";
            // 
            // pnlCardPreview
            // 
            pnlCardPreview.BackColor = Color.White;
            pnlCardPreview.BorderStyle = BorderStyle.FixedSingle;
            pnlCardPreview.Location = new Point(23, 40);
            pnlCardPreview.Margin = new Padding(3, 4, 3, 4);
            pnlCardPreview.Name = "pnlCardPreview";
            pnlCardPreview.Size = new Size(571, 446);
            pnlCardPreview.TabIndex = 0;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnExit);
            pnlActions.Controls.Add(btnPrint);
            pnlActions.Controls.Add(btnPrintPreview);
            pnlActions.Controls.Add(btnReset);
            pnlActions.Controls.Add(btnSavePng);
            pnlActions.Controls.Add(btnCardColor);
            pnlActions.Location = new Point(457, 549);
            pnlActions.Margin = new Padding(3, 4, 3, 4);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(617, 133);
            pnlActions.TabIndex = 2;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(423, 72);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(194, 53);
            btnExit.TabIndex = 5;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(40, 167, 69);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(211, 72);
            btnPrint.Margin = new Padding(3, 4, 3, 4);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(194, 53);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "In thẻ";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnPrintPreview
            // 
            btnPrintPreview.BackColor = Color.FromArgb(0, 102, 204);
            btnPrintPreview.FlatStyle = FlatStyle.Flat;
            btnPrintPreview.ForeColor = Color.White;
            btnPrintPreview.Location = new Point(0, 72);
            btnPrintPreview.Margin = new Padding(3, 4, 3, 4);
            btnPrintPreview.Name = "btnPrintPreview";
            btnPrintPreview.Size = new Size(194, 53);
            btnPrintPreview.TabIndex = 3;
            btnPrintPreview.Text = "Xem trước khi in";
            btnPrintPreview.UseVisualStyleBackColor = false;
            btnPrintPreview.Click += btnPrintPreview_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(423, 11);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(194, 51);
            btnReset.TabIndex = 2;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSavePng
            // 
            btnSavePng.Location = new Point(211, 11);
            btnSavePng.Margin = new Padding(3, 4, 3, 4);
            btnSavePng.Name = "btnSavePng";
            btnSavePng.Size = new Size(194, 51);
            btnSavePng.TabIndex = 1;
            btnSavePng.Text = "Lưu thẻ (PNG)";
            btnSavePng.UseVisualStyleBackColor = true;
            btnSavePng.Click += btnSavePng_Click;
            // 
            // btnCardColor
            // 
            btnCardColor.Location = new Point(0, 11);
            btnCardColor.Margin = new Padding(3, 4, 3, 4);
            btnCardColor.Name = "btnCardColor";
            btnCardColor.Size = new Size(194, 51);
            btnCardColor.TabIndex = 0;
            btnCardColor.Text = "Màu nền thẻ";
            btnCardColor.UseVisualStyleBackColor = true;
            btnCardColor.Click += btnCardColor_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1172, 698);
            Controls.Add(pnlActions);
            Controls.Add(grpPreview);
            Controls.Add(grpInput);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "COMP1019 - Lab 09 - Thiết kế và In Thẻ Sinh Viên (FrmStudentCard)";
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            grpPreview.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.ComboBox cboFaculty;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Label lblCohort;
        private System.Windows.Forms.ComboBox cboCohort;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.Panel pnlCardPreview;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnCardColor;
        private System.Windows.Forms.Button btnSavePng;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
    }
}