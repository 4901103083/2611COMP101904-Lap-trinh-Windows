namespace Lab15.Views
{
    public interface IMonHocView
    {
        // Nhận xuất dữ liệu
        string MaMonHoc { get; set; }
        string TenMonHoc { get; set; }
        int SoTinChi { get; set; }
        bool TrangThai { get; set; }

        // Các hành động yêu cầu Form chạy
        void HienThiDanhSach(object data);
        void HienThiThongBao(string message);
        void XoaTrangForm();
    }
}