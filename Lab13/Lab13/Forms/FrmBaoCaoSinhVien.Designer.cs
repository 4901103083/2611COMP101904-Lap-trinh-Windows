namespace Lab13.Forms
{
    partial class FrmBaoCaoSinhVien
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cboKetQua = new System.Windows.Forms.ComboBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTongSo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSoDat = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSoKhongDat = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiemTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.btnLamMoi);
            this.panelTop.Controls.Add(this.btnXuatFile);
            this.panelTop.Controls.Add(this.btnThongKe);
            this.panelTop.Controls.Add(this.btnXemBaoCao);
            this.panelTop.Controls.Add(this.txtTuKhoa);
            this.panelTop.Controls.Add(this.lblTimKiem);
            this.panelTop.Controls.Add(this.cboKetQua);
            this.panelTop.Controls.Add(this.lblKetQua);
            this.panelTop.Controls.Add(this.cboLop);
            this.panelTop.Controls.Add(this.lblLop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1084, 80);
            this.panelTop.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(610, 21);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 36);
            this.btnLamMoi.TabIndex = 9;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXuatFile.FlatAppearance.BorderSize = 0;
            this.btnXuatFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatFile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXuatFile.ForeColor = System.Drawing.Color.White;
            this.btnXuatFile.Location = new System.Drawing.Point(960, 21);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(100, 36);
            this.btnXuatFile.TabIndex = 8;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.UseVisualStyleBackColor = false;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(850, 21);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(100, 36);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnXemBaoCao.FlatAppearance.BorderSize = 0;
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(710, 21);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(130, 36);
            this.btnXemBaoCao.TabIndex = 6;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(455, 26);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.PlaceholderText = "Nhập mã, tên...";
            this.txtTuKhoa.Size = new System.Drawing.Size(140, 30);
            this.txtTuKhoa.TabIndex = 5;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(375, 29);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(83, 23);
            this.lblTimKiem.TabIndex = 4;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // cboKetQua
            // 
            this.cboKetQua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKetQua.FormattingEnabled = true;
            this.cboKetQua.Location = new System.Drawing.Point(240, 25);
            this.cboKetQua.Name = "cboKetQua";
            this.cboKetQua.Size = new System.Drawing.Size(120, 31);
            this.cboKetQua.TabIndex = 3;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(168, 29);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(73, 23);
            this.lblKetQua.TabIndex = 2;
            this.lblKetQua.Text = "Kết quả:";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(52, 25);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(100, 31);
            this.cboLop.TabIndex = 1;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(12, 29);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(42, 23);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lớp:";
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaoCao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaoCao.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCao.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.EnableHeadersVisualStyles = false;
            this.dgvBaoCao.Location = new System.Drawing.Point(0, 80);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersVisible = false;
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 35;
            this.dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.Size = new System.Drawing.Size(1084, 455);
            this.dgvBaoCao.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTongSo,
            this.lblSoDat,
            this.lblSoKhongDat,
            this.lblDiemTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1084, 29);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTongSo
            // 
            this.lblTongSo.Margin = new System.Windows.Forms.Padding(0, 4, 20, 2);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(126, 23);
            this.lblTongSo.Text = "Tổng số SV: 0";
            // 
            // lblSoDat
            // 
            this.lblSoDat.ForeColor = System.Drawing.Color.Green;
            this.lblSoDat.Margin = new System.Windows.Forms.Padding(0, 4, 20, 2);
            this.lblSoDat.Name = "lblSoDat";
            this.lblSoDat.Size = new System.Drawing.Size(69, 23);
            this.lblSoDat.Text = "Đạt: 0";
            // 
            // lblSoKhongDat
            // 
            this.lblSoKhongDat.ForeColor = System.Drawing.Color.Red;
            this.lblSoKhongDat.Margin = new System.Windows.Forms.Padding(0, 4, 20, 2);
            this.lblSoKhongDat.Name = "lblSoKhongDat";
            this.lblSoKhongDat.Size = new System.Drawing.Size(120, 23);
            this.lblSoKhongDat.Text = "Không đạt: 0";
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.ForeColor = System.Drawing.Color.Blue;
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(95, 23);
            this.lblDiemTB.Text = "Điểm TB: 0";
            // 
            // FrmBaoCaoSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 564);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FrmBaoCaoSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Sinh Viên";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.ComboBox cboKetQua;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTongSo;
        private System.Windows.Forms.ToolStripStatusLabel lblSoDat;
        private System.Windows.Forms.ToolStripStatusLabel lblSoKhongDat;
        private System.Windows.Forms.ToolStripStatusLabel lblDiemTB;
    }
}