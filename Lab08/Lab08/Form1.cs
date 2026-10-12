using Lab08;
using System;
#nullable disable
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using DrawMode = Lab08.DrawMode;

namespace Lab08
{
    public partial class Form1 : Form
    {
        // Danh sách lưu các nét đã vẽ
        private List<DrawItem> drawItems = new List<DrawItem>();

        // Nét vẽ hiện tại đang được kéo chuột
        private DrawItem currentItem = null;
        private bool isDrawing = false;

        // Cấu hình nét vẽ hiện tại
        private Color currentColor = Color.Black;
        private Image backgroundImage = null;

        public Form1()
        {
            InitializeComponent();
            SetupApplication();
        }

        private void SetupApplication()
        {
            // Bật DoubleBuffered cho Panel canvas để chống nhấp nháy (Flicker) khi vẽ
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, canvas, new object[] { true });

            // Khởi tạo ComboBox chế độ vẽ
            cboMode.Items.AddRange(new object[] { "Pen", "Line", "Rectangle", "Ellipse" });
            cboMode.SelectedIndex = 0;

            // Cấu hình NumericUpDown
            nudWidth.Minimum = 1;
            nudWidth.Maximum = 20;
            nudWidth.Value = 3;

            // Bật KeyPreview để nhận phím tắt Ctrl + Z
            this.KeyPreview = true;

            // Gán sự kiện cho vùng vẽ (nếu chưa gán trong Designer)
            canvas.Paint += Canvas_Paint;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseUp;
        }

        // ==========================================================
        // 1. SỰ KIỆN CHUỘT TRÊN VÙNG VẼ (CANVAS)
        // ==========================================================
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            isDrawing = true;
            DrawMode selectedMode = (DrawMode)Enum.Parse(typeof(DrawMode), cboMode.SelectedItem.ToString());

            currentItem = new DrawItem
            {
                Mode = selectedMode,
                StrokeColor = currentColor,
                Width = (float)nudWidth.Value,
                StartPoint = e.Location,
                EndPoint = e.Location,
                IsFilled = chkFill != null && chkFill.Checked // Nâng cao: Tô màu
            };

            if (selectedMode == DrawMode.Pen)
            {
                currentItem.Points.Add(e.Location);
            }

            // Đưa ngay vào danh sách để vẽ trực tiếp theo thời gian thực
            drawItems.Add(currentItem);
            canvas.Invalidate();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Hiển thị tọa độ chuột trên Status Label
            lblStatus.Text = $"X: {e.X}, Y: {e.Y}";

            if (!isDrawing || currentItem == null) return;

            if (currentItem.Mode == DrawMode.Pen)
            {
                currentItem.Points.Add(e.Location);
            }
            else
            {
                currentItem.EndPoint = e.Location;
            }

            // Yêu cầu vùng canvas vẽ lại
            canvas.Invalidate();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;
            currentItem = null;
            canvas.Invalidate();
        }

        // ==========================================================
        // 2. SỰ KIỆN PAINT & LOGIC VẼ GDI+
        // ==========================================================
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            RenderGraphics(e.Graphics);
        }

        // Tách hàm vẽ riêng để tái sử dụng khi xuất ra file ảnh PNG
        private void RenderGraphics(Graphics g)
        {
            // Khử răng cưa giúp nét vẽ mượt hơn
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Vẽ ảnh nền nếu có (Chức năng nâng cao)
            if (backgroundImage != null)
            {
                g.DrawImage(backgroundImage, 0, 0, canvas.Width, canvas.Height);
            }

            // Duyệt qua danh sách đối tượng đã lưu và vẽ lại
            foreach (var item in drawItems)
            {
                // Sử dụng khối lệnh using để tự động giải phóng Pen và Brush (Đúng yêu cầu kỹ thuật)
                using (Pen pen = new Pen(item.StrokeColor, item.Width))
                using (SolidBrush brush = new SolidBrush(item.StrokeColor))
                {
                    // Làm tròn đầu nét vẽ cho đẹp hơn
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    switch (item.Mode)
                    {
                        case DrawMode.Pen:
                            if (item.Points.Count > 1)
                            {
                                g.DrawLines(pen, item.Points.ToArray());
                            }
                            else if (item.Points.Count == 1)
                            {
                                // Xử lý khi người dùng chỉ click 1 điểm
                                g.FillEllipse(brush, item.Points[0].X - item.Width / 2, item.Points[0].Y - item.Width / 2, item.Width, item.Width);
                            }
                            break;

                        case DrawMode.Line:
                            g.DrawLine(pen, item.StartPoint, item.EndPoint);
                            break;

                        case DrawMode.Rectangle:
                            Rectangle rect = GetNormalizedRectangle(item.StartPoint, item.EndPoint);
                            if (item.IsFilled)
                                g.FillRectangle(brush, rect);
                            else
                                g.DrawRectangle(pen, rect);
                            break;

                        case DrawMode.Ellipse:
                            Rectangle ellipseRect = GetNormalizedRectangle(item.StartPoint, item.EndPoint);
                            if (item.IsFilled)
                                g.FillEllipse(brush, ellipseRect);
                            else
                                g.DrawEllipse(pen, ellipseRect);
                            break;
                    }
                }
            }
        }

        // Hàm chuẩn hóa hình chữ nhật: Giúp kéo chuột theo mọi hướng (ngược lên trên/sang trái) đều vẽ đúng
        private Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);
            int width = Math.Abs(p1.X - p2.X);
            int height = Math.Abs(p1.Y - p2.Y);
            return new Rectangle(x, y, width, height);
        }

        // ==========================================================
        // 3. CÁC NÚT CHỨC NĂNG CƠ BẢN (MÀU, UNDO, CLEAR)
        // ==========================================================
        private void btnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = currentColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    currentColor = colorDialog.Color;
                    btnColor.BackColor = currentColor; // Hiển thị màu đang chọn lên nút
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            UndoLastAction();
        }

        private void UndoLastAction()
        {
            if (drawItems.Count > 0)
            {
                drawItems.RemoveAt(drawItems.Count - 1);
                canvas.Invalidate();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (drawItems.Count == 0 && backgroundImage == null) return;

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa toàn bộ vùng vẽ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                drawItems.Clear();
                backgroundImage?.Dispose();
                backgroundImage = null;
                canvas.Invalidate();
            }
        }

        // ==========================================================
        // 4. CÁC CHỨC NĂNG NÂNG CAO
        // ==========================================================

        // Nâng cao 1: Phím tắt Ctrl + Z để Undo
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                UndoLastAction();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Nâng cao 2: Đổi màu nền vùng vẽ (Canvas)
        private void btnBgColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = canvas.BackColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    canvas.BackColor = colorDialog.Color;
                    canvas.Invalidate();
                }
            }
        }

        // Nâng cao 3: Mở ảnh nền để vẽ đè lên ảnh
        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        backgroundImage?.Dispose();
                        backgroundImage = Image.FromFile(openDialog.FileName);
                        canvas.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi mở ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Nâng cao 4: Lưu vùng vẽ ra file PNG
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PNG Image|*.png";
                saveDialog.FileName = "SimplePaint_Output.png";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Bitmap bmp = new Bitmap(canvas.Width, canvas.Height))
                        {
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.Clear(canvas.BackColor);
                                RenderGraphics(g);
                            }
                            bmp.Save(saveDialog.FileName, ImageFormat.Png);
                        }
                        MessageBox.Show("Lưu ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}