namespace Lab12
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.btnTaiDanhSach = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.btnLuuTatCa = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Lớp:";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(110, 22);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(200, 31);
            this.cboLop.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.label2.Location = new System.Drawing.Point(330, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn Môn:";
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(430, 22);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(200, 31);
            this.cboMonHoc.TabIndex = 3;
            // 
            // btnTaiDanhSach
            // 
            this.btnTaiDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.btnTaiDanhSach.FlatAppearance.BorderSize = 0;
            this.btnTaiDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiDanhSach.ForeColor = System.Drawing.Color.White;
            this.btnTaiDanhSach.Location = new System.Drawing.Point(650, 20);
            this.btnTaiDanhSach.Name = "btnTaiDanhSach";
            this.btnTaiDanhSach.Size = new System.Drawing.Size(140, 35);
            this.btnTaiDanhSach.TabIndex = 4;
            this.btnTaiDanhSach.Text = "Tải danh sách";
            this.btnTaiDanhSach.UseVisualStyleBackColor = false;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.BackgroundColor = System.Drawing.Color.White;
            this.dgvKetQua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKetQua.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKetQua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKetQua.ColumnHeadersHeight = 35;
            this.dgvKetQua.EnableHeadersVisualStyles = false;
            this.dgvKetQua.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.dgvKetQua.Location = new System.Drawing.Point(20, 75);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.dgvKetQua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKetQua.RowTemplate.Height = 30;
            this.dgvKetQua.Size = new System.Drawing.Size(770, 340);
            this.dgvKetQua.TabIndex = 5;
            // 
            // btnLuuTatCa
            // 
            this.btnLuuTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.btnLuuTatCa.FlatAppearance.BorderSize = 0;
            this.btnLuuTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuTatCa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuTatCa.ForeColor = System.Drawing.Color.White;
            this.btnLuuTatCa.Location = new System.Drawing.Point(650, 430);
            this.btnLuuTatCa.Name = "btnLuuTatCa";
            this.btnLuuTatCa.Size = new System.Drawing.Size(140, 40);
            this.btnLuuTatCa.TabIndex = 6;
            this.btnLuuTatCa.Text = "Lưu tất cả";
            this.btnLuuTatCa.UseVisualStyleBackColor = false;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(115)))));
            this.lblTrangThai.Location = new System.Drawing.Point(20, 440);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(76, 21);
            this.lblTrangThai.TabIndex = 7;
            this.lblTrangThai.Text = "Sẵn sàng.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(810, 490);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.btnLuuTatCa);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnTaiDanhSach);
            this.Controls.Add(this.cboMonHoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Điểm - Lab 12";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Button btnLuuTatCa;
        private System.Windows.Forms.Label lblTrangThai;
    }
}