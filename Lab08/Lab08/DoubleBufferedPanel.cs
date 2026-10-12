using System.Windows.Forms;

namespace Lab08
{
    // Kế thừa từ Panel mặc định của WinForms
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            // Bật bộ đệm kép để không bị nhấp nháy khi vẽ GDI+
            this.DoubleBuffered = true;

            // Tự động vẽ lại khi Panel bị thay đổi kích thước (Resize)
            this.ResizeRedraw = true;

            // Tối ưu hóa thêm cho việc tự vẽ bằng sự kiện Paint
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }
    }
}