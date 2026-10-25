using Lab15.Models;
using Lab15.Repositories;
using Lab15.Views;

namespace Lab15.Presenters
{
    public class MonHocPresenter
    {
        // Presenter giao tiếp với View và Repository qua Interface
        private IMonHocView _view;
        private IMonHocRepository _repository;

        public MonHocPresenter(IMonHocView view, IMonHocRepository repository)
        {
            _view = view;
            _repository = repository;
        }

        // Tải danh sách
        public void LoadData()
        {
            var data = _repository.GetAll();
            _view.HienThiDanhSach(data);
        }

        // Xử lý thêm
        public void Add()
        {
            // Kiểm tra rỗng từ View
            if (string.IsNullOrWhiteSpace(_view.MaMonHoc))
            {
                _view.HienThiThongBao("Mã môn học không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(_view.TenMonHoc))
            {
                _view.HienThiThongBao("Tên môn học không được để trống!");
                return;
            }
            if (_view.SoTinChi < 1 || _view.SoTinChi > 6)
            {
                _view.HienThiThongBao("Số tín chỉ phải từ 1 đến 6!");
                return;
            }

            // Kiểm tra trùng mã
            if (_repository.GetById(_view.MaMonHoc) != null)
            {
                _view.HienThiThongBao("Mã môn học đã tồn tại!");
                return;
            }

            // Tạo đối tượng và lưu
            MonHoc mh = new MonHoc
            {
                MaMonHoc = _view.MaMonHoc,
                TenMonHoc = _view.TenMonHoc,
                SoTinChi = _view.SoTinChi,
                TrangThai = _view.TrangThai
            };

            if (_repository.Add(mh))
            {
                _view.HienThiThongBao("Thêm môn học thành công!");
                _view.XoaTrangForm();
                LoadData();
            }
        }

        // Xử lý xóa
        public void Delete()
        {
            if (string.IsNullOrWhiteSpace(_view.MaMonHoc))
            {
                _view.HienThiThongBao("Vui lòng chọn môn học cần xóa!");
                return;
            }

            if (_repository.Delete(_view.MaMonHoc))
            {
                _view.HienThiThongBao("Xóa thành công!");
                _view.XoaTrangForm();
                LoadData();
            }
            else
            {
                _view.HienThiThongBao("Xóa thất bại. Không tìm thấy mã môn học.");
            }
        }

        // Xử lý tìm kiếm
        public void Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadData();
            }
            else
            {
                var data = _repository.Search(keyword);
                _view.HienThiDanhSach(data);
            }
        }
    }
}