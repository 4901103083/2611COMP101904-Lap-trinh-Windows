using Lab08;

namespace Lab08
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblMode = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.chkFill = new System.Windows.Forms.CheckBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnBgColor = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.canvas = new Lab08.DoubleBufferedPanel();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar (Thanh công cụ phía trên)
            // 
            this.pnlToolbar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlToolbar.Controls.Add(this.btnSave);
            this.pnlToolbar.Controls.Add(this.btnOpenImage);
            this.pnlToolbar.Controls.Add(this.btnClear);
            this.pnlToolbar.Controls.Add(this.btnUndo);
            this.pnlToolbar.Controls.Add(this.btnBgColor);
            this.pnlToolbar.Controls.Add(this.btnColor);
            this.pnlToolbar.Controls.Add(this.chkFill);
            this.pnlToolbar.Controls.Add(this.nudWidth);
            this.pnlToolbar.Controls.Add(this.lblWidth);
            this.pnlToolbar.Controls.Add(this.cboMode);
            this.pnlToolbar.Controls.Add(this.lblMode);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(920, 48);
            this.pnlToolbar.TabIndex = 0;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(12, 16);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(47, 15);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Chế độ:";
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Location = new System.Drawing.Point(65, 12);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(105, 23);
            this.cboMode.TabIndex = 1;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(182, 16);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(47, 15);
            this.lblWidth.TabIndex = 2;
            this.lblWidth.Text = "Độ dày:";
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(235, 12);
            this.nudWidth.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.nudWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(55, 23);
            this.nudWidth.TabIndex = 3;
            this.nudWidth.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // chkFill (Chức năng nâng cao: Tô màu)
            // 
            this.chkFill.AutoSize = true;
            this.chkFill.Location = new System.Drawing.Point(302, 14);
            this.chkFill.Name = "chkFill";
            this.chkFill.Size = new System.Drawing.Size(66, 19);
            this.chkFill.TabIndex = 4;
            this.chkFill.Text = "Tô màu";
            this.chkFill.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(378, 10);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(80, 28);
            this.btnColor.TabIndex = 5;
            this.btnColor.Text = "Màu vẽ";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnBgColor (Chức năng nâng cao: Đổi màu nền)
            // 
            this.btnBgColor.Location = new System.Drawing.Point(466, 10);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(80, 28);
            this.btnBgColor.TabIndex = 6;
            this.btnBgColor.Text = "Màu nền";
            this.btnBgColor.UseVisualStyleBackColor = true;
            this.btnBgColor.Click += new System.EventHandler(this.btnBgColor_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(554, 10);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 28);
            this.btnUndo.TabIndex = 7;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(637, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOpenImage (Chức năng nâng cao: Mở ảnh nền)
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(720, 10);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(85, 28);
            this.btnOpenImage.TabIndex = 9;
            this.btnOpenImage.Text = "Mở ảnh";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // btnSave (Chức năng nâng cao: Lưu PNG)
            // 
            this.btnSave.Location = new System.Drawing.Point(813, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 28);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu PNG";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlStatus (Thanh trạng thái phía dưới)
            // 
            this.pnlStatus.BackColor = System.Drawing.SystemColors.Control;
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 534);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(920, 26);
            this.pnlStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(62, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "X: 0, Y: 0";
            // 
            // canvas (Vùng vẽ chính - Custom Panel)
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 48);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(920, 486);
            this.canvas.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlToolbar);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(936, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMP1019 - Lab 08 - Simple Paint (WinForms & GDI+)";
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.CheckBox chkFill;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnBgColor;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatus;
        private DoubleBufferedPanel canvas;
    }
}