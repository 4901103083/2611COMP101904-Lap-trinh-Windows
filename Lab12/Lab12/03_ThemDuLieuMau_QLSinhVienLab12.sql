USE QLSinhVienLab12;
GO

-- Xóa dữ liệu cũ (nếu có) theo thứ tự để không vi phạm khóa ngoại
DELETE FROM KETQUA;
DELETE FROM SINHVIEN;
DELETE FROM LOP;
DELETE FROM MONHOC;
GO

-- 1. Thêm dữ liệu mẫu cho bảng LOP
INSERT INTO LOP (MaLop, TenLop) VALUES 
('CNTT1', N'Công nghệ thông tin 1'),
('CNTT2', N'Công nghệ thông tin 2');
GO

-- 2. Thêm dữ liệu mẫu cho bảng MONHOC
INSERT INTO MONHOC (MaMon, TenMon, SoTinChi) VALUES 
('LTC', N'Lập trình C#', 3),
('CSDL', N'Cơ sở dữ liệu', 3);
GO

-- 3. Thêm dữ liệu mẫu cho bảng SINHVIEN
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, MaLop) VALUES 
('SV01', N'Nguyễn Văn A', '2005-01-01', 'CNTT1'),
('SV02', N'Trần Thị B', '2005-02-02', 'CNTT1'),
('SV03', N'Lê Văn C', '2005-03-03', 'CNTT2');
GO

-- 4. Thêm dữ liệu ĐIỂM mẫu cho bảng KETQUA
INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) VALUES 
('SV01', 'CSDL', 8.5, N'Khá'),
('SV02', 'CSDL', 9.0, N'Giỏi'),
('SV01', 'LTC', 7.0, N'Bình thường');
GO