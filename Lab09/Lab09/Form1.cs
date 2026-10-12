#nullable disable
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Lab09
{
    public partial class Form1 : Form
    {
        private Image avatarImage = null;
        private Color cardBgColor = Color.FromArgb(245, 250, 255); // Màu nền thẻ nhẹ nhàng mặc định
        private PrintDocument printDocument = new PrintDocument();

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Bật DoubleBuffered cho Panel preview để vẽ GDI+ mượt mà không nhấp nháy
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, pnlCardPreview, new object[] { true });

            // Khởi tạo danh sách dữ liệu mẫu cho các ComboBox
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGender.SelectedIndex = 0;

            cboFaculty.Items.AddRange(new object[] {
                "Công nghệ Thông tin",
                "Toán - Tin học",
                "Vật lý",
                "Sư phạm Tiếng Anh",
                "Giáo dục Tiểu học"
            });
            cboFaculty.SelectedIndex = 0;

            cboClass.Items.AddRange(new object[] {
                "COMP101904",
                "SP.TIN.A",
                "SP.TIN.B",
                "CNTT.A",
                "CNTT.B"
            });
            cboClass.SelectedIndex = 0;

            cboCohort.Items.AddRange(new object[] { "K48", "K49", "K50", "K51", "K52" });
            cboCohort.SelectedIndex = 1; // Mặc định K49

            // Gắn sự kiện thay đổi dữ liệu để cập nhật bản xem trước thẻ ngay lập tức (F2)
            txtStudentId.TextChanged += InputData_Changed;
            txtFullName.TextChanged += InputData_Changed;
            dtpDob.ValueChanged += InputData_Changed;
            cboGender.SelectedIndexChanged += InputData_Changed;
            cboFaculty.SelectedIndexChanged += InputData_Changed;
            cboClass.TextChanged += InputData_Changed;
            cboCohort.SelectedIndexChanged += InputData_Changed;

            // Gắn sự kiện Paint cho Panel Preview và PrintPage cho PrintDocument
            pnlCardPreview.Paint += PnlCardPreview_Paint;
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void InputData_Changed(object sender, EventArgs e)
        {
            // Yêu cầu Panel vẽ lại bằng GDI+ mỗi khi thông tin thay đổi
            pnlCardPreview.Invalidate();
        }

        // =====================================================================
        // F1: CHỌN ẢNH ĐẠI DIỆN (KHÔNG KHÓA FILE CŨ & GIỮ ĐÚNG TỈ LỆ)
        // =====================================================================
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Title = "Chọn ảnh thẻ sinh viên";
                openDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Đọc qua FileStream và tạo bản sao Bitmap để KHÔNG khóa file ảnh trên ổ cứng
                        using (FileStream fs = new FileStream(openDialog.FileName, FileMode.Open, FileAccess.Read))
                        using (Image tempImg = Image.FromStream(fs))
                        {
                            // Giải phóng ảnh cũ trước khi gán ảnh mới
                            picAvatar.Image = null;
                            avatarImage?.Dispose();

                            avatarImage = new Bitmap(tempImg);
                            picAvatar.Image = avatarImage;
                        }

                        pnlCardPreview.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể đọc file ảnh. Chi tiết: " + ex.Message,
                            "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =====================================================================
        // F2: VẼ PREVIEW THẺ SINH VIÊN BẰNG GDI+
        // =====================================================================
        private void PnlCardPreview_Paint(object sender, PaintEventArgs e)
        {
            Rectangle cardRect = new Rectangle(10, 10, pnlCardPreview.Width - 20, pnlCardPreview.Height - 20);
            DrawStudentCard(e.Graphics, cardRect);
        }

        /// <summary>
        /// Hàm dùng chung để vẽ Thẻ Sinh Viên lên cả Panel Preview và trang in PrintDocument
        /// </summary>
        private void DrawStudentCard(Graphics g, Rectangle bounds)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 1. Vẽ nền thẻ và khung viền ngoài
            using (SolidBrush bgBrush = new SolidBrush(cardBgColor))
            using (Pen borderPen = new Pen(Color.FromArgb(18, 72, 136), 3))
            {
                g.FillRectangle(bgBrush, bounds);
                g.DrawRectangle(borderPen, bounds);
            }

            // 2. Vẽ phần Header (Tên Trường & Khoa)
            int headerHeight = 68;
            Rectangle headerRect = new Rectangle(bounds.X, bounds.Y, bounds.Width, headerHeight);
            using (SolidBrush headerBrush = new SolidBrush(Color.FromArgb(18, 72, 136)))
            using (Font schoolFont = new Font("Segoe UI", 11F, FontStyle.Bold))
            using (Font subHeaderFont = new Font("Segoe UI", 9.5F, FontStyle.Regular))
            using (StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.FillRectangle(headerBrush, headerRect);

                Rectangle line1 = new Rectangle(bounds.X, bounds.Y + 8, bounds.Width, 26);
                Rectangle line2 = new Rectangle(bounds.X, bounds.Y + 34, bounds.Width, 24);
                g.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH", schoolFont, Brushes.White, line1, centerFormat);
                g.DrawString("KHOA " + cboFaculty.Text.ToUpper(), subHeaderFont, Brushes.Gold, line2, centerFormat);
            }

            // 3. Vẽ dòng tiêu đề "THẺ SINH VIÊN"
            using (Font titleFont = new Font("Segoe UI", 15F, FontStyle.Bold))
            using (SolidBrush titleBrush = new SolidBrush(Color.FromArgb(192, 0, 0)))
            using (StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center })
            {
                g.DrawString("THẺ SINH VIÊN", titleFont, titleBrush,
                    new RectangleF(bounds.X, bounds.Y + headerHeight + 8, bounds.Width, 32), centerFormat);
            }

            // 4. Vẽ khung ảnh sinh viên ở bên trái (Giữ đúng tỉ lệ không bị méo)
            Rectangle photoBox = new Rectangle(bounds.X + 22, bounds.Y + headerHeight + 45, 115, 150);
            using (SolidBrush photoBg = new SolidBrush(Color.White))
            using (Pen photoBorder = new Pen(Color.FromArgb(120, 140, 160), 1.5f))
            {
                g.FillRectangle(photoBg, photoBox);
                if (avatarImage != null)
                {
                    Rectangle zoomRect = GetAspectFitRectangle(photoBox, avatarImage.Size);
                    g.DrawImage(avatarImage, zoomRect);
                }
                else
                {
                    using (Font emptyFont = new Font("Segoe UI", 8.5F, FontStyle.Italic))
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        g.DrawString("Chưa có\nảnh 3x4", emptyFont, Brushes.Gray, photoBox, sf);
                    }
                }
                g.DrawRectangle(photoBorder, photoBox);
            }

            // 5. Vẽ thông tin sinh viên ở bên phải
            int infoX = photoBox.Right + 20;
            int infoY = photoBox.Top + 2;
            int lineSpacing = 25;

            string studentId = string.IsNullOrWhiteSpace(txtStudentId.Text) ? "<Chưa nhập mã>" : txtStudentId.Text.Trim();
            string fullName = string.IsNullOrWhiteSpace(txtFullName.Text) ? "<Chưa nhập họ tên>" : txtFullName.Text.Trim().ToUpper();

            using (Font labelFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (Font valueFont = new Font("Segoe UI", 9.5F, FontStyle.Regular))
            using (Font nameValueFont = new Font("Segoe UI", 10F, FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(30, 30, 30)))
            using (SolidBrush idBrush = new SolidBrush(Color.FromArgb(18, 72, 136)))
            {
                DrawInfoRow(g, "Họ và tên:", fullName, labelFont, nameValueFont, textBrush, idBrush, infoX, infoY);
                DrawInfoRow(g, "MSSV:", studentId, labelFont, nameValueFont, textBrush, Brushes.DarkRed, infoX, infoY + lineSpacing);
                DrawInfoRow(g, "Ngày sinh:", dtpDob.Value.ToString("dd/MM/yyyy"), labelFont, valueFont, textBrush, textBrush, infoX, infoY + lineSpacing * 2);
                DrawInfoRow(g, "Giới tính:", cboGender.Text, labelFont, valueFont, textBrush, textBrush, infoX, infoY + lineSpacing * 3);
                DrawInfoRow(g, "Lớp:", cboClass.Text, labelFont, valueFont, textBrush, textBrush, infoX, infoY + lineSpacing * 4);
                DrawInfoRow(g, "Khóa học:", cboCohort.Text, labelFont, valueFont, textBrush, textBrush, infoX, infoY + lineSpacing * 5);
            }

            // 6. Chức năng mở rộng: Vẽ mã QR giả lập ở góc dưới bên phải thẻ
            Rectangle qrRect = new Rectangle(bounds.Right - 68, bounds.Bottom - 68, 52, 52);
            DrawSimulatedQrCode(g, qrRect, studentId);
        }

        private void DrawInfoRow(Graphics g, string label, string value, Font lblFont, Font valFont, Brush lblBrush, Brush valBrush, int x, int y)
        {
            g.DrawString(label, lblFont, lblBrush, x, y);
            g.DrawString(value, valFont, valBrush, x + 82, y);
        }

        /// <summary>
        /// Tính toán khung hiển thị ảnh giữ nguyên tỉ lệ gốc (Zoom/Aspect-Fit) để ảnh không bị méo
        /// </summary>
        private Rectangle GetAspectFitRectangle(Rectangle container, Size imageSize)
        {
            if (imageSize.Width <= 0 || imageSize.Height <= 0) return container;

            float ratioX = (float)container.Width / imageSize.Width;
            float ratioY = (float)container.Height / imageSize.Height;
            float ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(imageSize.Width * ratio);
            int newHeight = (int)(imageSize.Height * ratio);
            int posX = container.X + (container.Width - newWidth) / 2;
            int posY = container.Y + (container.Height - newHeight) / 2;

            return new Rectangle(posX, posY, newWidth, newHeight);
        }

        /// <summary>
        /// Gợi ý mở rộng: Vẽ mã QR giả lập bằng các ô vuông đơn giản dựa theo mã sinh viên
        /// </summary>
        private void DrawSimulatedQrCode(Graphics g, Rectangle rect, string seedText)
        {
            g.FillRectangle(Brushes.White, rect);
            int gridSize = 7;
            int cellSize = rect.Width / gridSize;
            int hash = seedText.GetHashCode();

            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    bool isCorner = (r < 2 && c < 2) || (r < 2 && c >= gridSize - 2) || (r >= gridSize - 2 && c < 2);
                    bool fillBit = isCorner || (((hash >> ((r * gridSize + c) % 30)) & 1) == 1);
                    if (fillBit)
                    {
                        g.FillRectangle(Brushes.Black, rect.X + c * cellSize + 2, rect.Y + r * cellSize + 2, cellSize - 1, cellSize - 1);
                    }
                }
            }
            g.DrawRectangle(Pens.Gray, rect);
        }

        // =====================================================================
        // F3: KIỂM TRA DỮ LIỆU ĐẦU VÀO (VALIDATION)
        // =====================================================================
        private bool ValidateStudentInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên sinh viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (avatarImage == null)
            {
                MessageBox.Show("Vui lòng chọn Ảnh đại diện cho sinh viên!", "Thiếu ảnh đại diện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnChooseImage.Focus();
                return false;
            }

            return true;
        }

        // =====================================================================
        // F4 & F5: XEM TRƯỚC KHI IN (PRINT PREVIEW) VÀ IN THẺ (PRINT)
        // =====================================================================
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Định vị kích thước thẻ chuẩn trên trang giấy in (Canh giữa chiều ngang trang in)
            int cardWidth = 480;
            int cardHeight = 315;
            int startX = e.MarginBounds.Left + (e.MarginBounds.Width - cardWidth) / 2;
            int startY = e.MarginBounds.Top + 40;

            Rectangle printCardBounds = new Rectangle(startX, startY, cardWidth, cardHeight);
            DrawStudentCard(e.Graphics, printCardBounds);

            e.HasMorePages = false;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInput()) return;

            using (PrintPreviewDialog previewDialog = new PrintPreviewDialog())
            {
                previewDialog.Document = printDocument;
                previewDialog.Width = 900;
                previewDialog.Height = 700;
                previewDialog.StartPosition = FormStartPosition.CenterScreen;
                previewDialog.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInput()) return;

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        printDocument.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi trong quá trình in: " + ex.Message, "Lỗi in ấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =====================================================================
        // F6: LÀM MỚI (RESET FORM) & CÁC CHỨC NĂNG MỞ RỘNG
        // =====================================================================
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            dtpDob.Value = new DateTime(2005, 1, 1);
            cboGender.SelectedIndex = 0;
            cboFaculty.SelectedIndex = 0;
            cboClass.SelectedIndex = 0;
            cboCohort.SelectedIndex = 1;

            picAvatar.Image = null;
            avatarImage?.Dispose();
            avatarImage = null;

            cardBgColor = Color.FromArgb(245, 250, 255);
            pnlCardPreview.Invalidate();
            txtStudentId.Focus();
        }

        private void btnCardColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = cardBgColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    cardBgColor = colorDialog.Color;
                    pnlCardPreview.Invalidate();
                }
            }
        }

        private void btnSavePng_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInput()) return;

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PNG Image (*.png)|*.png";
                saveDialog.FileName = $"TheSV_{txtStudentId.Text.Trim()}.png";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(480, 315))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.Clear(Color.White);
                            DrawStudentCard(g, new Rectangle(0, 0, bmp.Width - 1, bmp.Height - 1));
                        }
                        bmp.Save(saveDialog.FileName, ImageFormat.Png);
                    }
                    MessageBox.Show("Đã lưu ảnh thẻ sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}