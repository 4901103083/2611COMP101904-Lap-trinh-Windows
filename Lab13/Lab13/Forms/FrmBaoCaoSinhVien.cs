using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lab13.Models;

namespace Lab13.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        private List<SinhVien> danhSachSV = new List<SinhVien>();

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();

            // Đăng ký các sự kiện nút bấm và form load
            this.Load += FrmBaoCaoSinhVien_Load;
            this.btnXemBaoCao.Click += BtnXemBaoCao_Click;
            this.btnThongKe.Click += BtnThongKe_Click;
            this.btnXuatFile.Click += BtnXuatFile_Click;
            this.btnLamMoi.Click += BtnLamMoi_Click;
        }

        private void FrmBaoCaoSinhVien_Load(object? sender, EventArgs e)
        {
            TaoDuLieuMau();
            LoadComboBox();

            dgvBaoCao.DataSource = danhSachSV;
            CapNhatThongKeChung(danhSachSV);
        }

        private void TaoDuLieuMau()
        {
            danhSachSV = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV01", HoTen = "Nguyễn Văn An", MaLop = "L01", TenLop = "CNTT", Diem = 8.5 },
                new SinhVien { MaSV = "SV02", HoTen = "Trần Thị Bình", MaLop = "L01", TenLop = "CNTT", Diem = 4.0 },
                new SinhVien { MaSV = "SV03", HoTen = "Lê Văn Cường", MaLop = "L01", TenLop = "CNTT", Diem = 6.5 },
                new SinhVien { MaSV = "SV04", HoTen = "Phạm Thị Dung", MaLop = "L01", TenLop = "CNTT", Diem = 9.0 },

                new SinhVien { MaSV = "SV05", HoTen = "Hoàng Văn Em", MaLop = "L02", TenLop = "Toán", Diem = 3.5 },
                new SinhVien { MaSV = "SV06", HoTen = "Ngô Thị Phương", MaLop = "L02", TenLop = "Toán", Diem = 7.0 },
                new SinhVien { MaSV = "SV07", HoTen = "Đinh Văn Giàu", MaLop = "L02", TenLop = "Toán", Diem = 5.0 },
                new SinhVien { MaSV = "SV08", HoTen = "Vũ Thị Hoa", MaLop = "L02", TenLop = "Toán", Diem = 8.0 },

                new SinhVien { MaSV = "SV09", HoTen = "Đặng Văn Inh", MaLop = "L03", TenLop = "Anh", Diem = 4.5 },
                new SinhVien { MaSV = "SV10", HoTen = "Bùi Thị Kim", MaLop = "L03", TenLop = "Anh", Diem = 6.0 },
                new SinhVien { MaSV = "SV11", HoTen = "Lý Văn Long", MaLop = "L03", TenLop = "Anh", Diem = 9.5 },
                new SinhVien { MaSV = "SV12", HoTen = "Trương Thị Mai", MaLop = "L03", TenLop = "Anh", Diem = 2.0 }
            };
        }

        private void LoadComboBox()
        {
            var danhSachLop = danhSachSV.Select(s => s.TenLop).Distinct().ToList();
            danhSachLop.Insert(0, "Tất cả");
            cboLop.DataSource = danhSachLop;
            cboLop.SelectedIndex = 0;

            cboKetQua.Items.Add("Tất cả");
            cboKetQua.Items.Add("Đạt");
            cboKetQua.Items.Add("Không đạt");
            cboKetQua.SelectedIndex = 0;
        }

        private void CapNhatThongKeChung(List<SinhVien> danhSachHienThi)
        {
            if (danhSachHienThi == null || danhSachHienThi.Count == 0)
            {
                lblTongSo.Text = "Tổng số SV: 0";
                lblSoDat.Text = "Đạt: 0";
                lblSoKhongDat.Text = "Không đạt: 0";
                lblDiemTB.Text = "Điểm TB: 0";
                return;
            }

            int tongSo = danhSachHienThi.Count;
            int soDat = danhSachHienThi.Count(s => s.KetQua == "Đạt");
            int soKhongDat = danhSachHienThi.Count(s => s.KetQua == "Không đạt");
            double diemTB = danhSachHienThi.Average(s => s.Diem);

            lblTongSo.Text = $"Tổng số SV: {tongSo}";
            lblSoDat.Text = $"Đạt: {soDat}";
            lblSoKhongDat.Text = $"Không đạt: {soKhongDat}";
            lblDiemTB.Text = $"Điểm TB: {Math.Round(diemTB, 2)}";
        }

        // CHỨC NĂNG 1: Xem báo cáo
        private void BtnXemBaoCao_Click(object? sender, EventArgs e)
        {
            var query = danhSachSV.AsQueryable();

            if (cboLop.SelectedIndex > 0)
            {
                query = query.Where(s => s.TenLop == cboLop.Text);
            }

            if (cboKetQua.Text == "Đạt")
            {
                query = query.Where(s => s.KetQua == "Đạt");
            }
            else if (cboKetQua.Text == "Không đạt")
            {
                query = query.Where(s => s.KetQua == "Không đạt");
            }

            string tuKhoa = txtTuKhoa.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(s => (s.MaSV != null && s.MaSV.ToLower().Contains(tuKhoa)) ||
                                         (s.HoTen != null && s.HoTen.ToLower().Contains(tuKhoa)));
            }

            var ketQuaLoc = query.OrderByDescending(s => s.Diem).ToList();

            if (ketQuaLoc.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvBaoCao.DataSource = ketQuaLoc;
            CapNhatThongKeChung(ketQuaLoc);
        }

        // CHỨC NĂNG 2: Thống kê
        private void BtnThongKe_Click(object? sender, EventArgs e)
        {
            var thongKeLop = danhSachSV.GroupBy(s => s.TenLop)
                                       .Select(g => new {
                                           Lop = g.Key,
                                           SoLuong = g.Count(),
                                           DiemTB = g.Average(s => s.Diem)
                                       }).ToList();

            string thongBao = "THỐNG KÊ THEO LỚP:\n\n";
            foreach (var item in thongKeLop)
            {
                thongBao += $"- Lớp {item.Lop}: {item.SoLuong} sinh viên, Điểm TB: {Math.Round(item.DiemTB, 2)}\n";
            }

            MessageBox.Show(thongBao, "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // CHỨC NĂNG 3: Xuất file
        private void BtnXuatFile_Click(object? sender, EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv|Text File|*.txt";
            sfd.Title = "Lưu báo cáo sinh viên";
            sfd.FileName = "BaoCaoSinhVien.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine("Mã SV,Họ Tên,Mã Lớp,Tên Lớp,Điểm,Kết Quả");

                        foreach (DataGridViewRow row in dgvBaoCao.Rows)
                        {
                            string maSV = row.Cells["MaSV"].Value?.ToString() ?? "";
                            string hoTen = row.Cells["HoTen"].Value?.ToString() ?? "";
                            string maLop = row.Cells["MaLop"].Value?.ToString() ?? "";
                            string tenLop = row.Cells["TenLop"].Value?.ToString() ?? "";
                            string diem = row.Cells["Diem"].Value?.ToString() ?? "0";
                            string ketQua = row.Cells["KetQua"].Value?.ToString() ?? "";

                            sw.WriteLine($"{maSV},{hoTen},{maLop},{tenLop},{diem},{ketQua}");
                        }
                    }
                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // CHỨC NĂNG 4: Làm mới
        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            if (cboKetQua.Items.Count > 0) cboKetQua.SelectedIndex = 0;
            txtTuKhoa.Clear();

            dgvBaoCao.DataSource = null;
            dgvBaoCao.DataSource = danhSachSV;
            CapNhatThongKeChung(danhSachSV);

            txtTuKhoa.Focus();
        }
    }
}