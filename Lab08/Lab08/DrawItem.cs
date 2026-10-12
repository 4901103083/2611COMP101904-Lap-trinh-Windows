using System;
using System.Collections.Generic;
using System.Drawing;
#nullable disable
using System;
// ... các dòng code bên dưới giữ nguyên
namespace Lab08
{
    public enum DrawMode
    {
        Pen,
        Line,
        Rectangle,
        Ellipse
    }

    public class DrawItem
    {
        public DrawMode Mode { get; set; }
        public Color StrokeColor { get; set; }
        public float Width { get; set; }

        // Dùng cho Line, Rectangle, Ellipse
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        // Dùng cho chế độ vẽ tự do (Pen)
        public List<Point> Points { get; set; } = new List<Point>();

        // Chức năng nâng cao: Tô màu hình khép kín (Rectangle, Ellipse)
        public bool IsFilled { get; set; }
    }
}