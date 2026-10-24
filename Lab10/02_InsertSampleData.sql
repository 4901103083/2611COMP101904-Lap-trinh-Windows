USE EduManagerDB;
GO

-- Thêm 2 Khoa
INSERT INTO KHOA VALUES ('CNTT', N'Công nghệ thông tin'), ('KT', N'Kinh tế');

-- Thêm 3 Lớp
INSERT INTO LOP VALUES ('CNTT1', N'Công nghệ thông tin 1', 'CNTT'), 
                       ('CNTT2', N'Công nghệ thông tin 2', 'CNTT'), 
                       ('KT1', N'Kinh tế 1', 'KT');

-- Thêm 6 Sinh viên (Lưu ý giới tính chỉ 'Nam' hoặc 'Nữ')
INSERT INTO SINHVIEN VALUES 
('SV01', N'Nguyễn Văn A', N'Nam', '2000-01-01', 'CNTT1'),
('SV02', N'Trần Thị B', N'Nữ', '2000-02-02', 'CNTT1'),
('SV03', N'Lê Văn C', N'Nam', '2001-03-03', 'CNTT2'),
('SV04', N'Phạm Thị D', N'Nữ', '2001-04-04', 'CNTT2'),
('SV05', N'Hoàng Văn E', N'Nam', '2002-05-05', 'KT1'),
('SV06', N'Đỗ Thị F', N'Nữ', '2002-06-06', 'KT1');

-- Thêm 4 Môn học
INSERT INTO MONHOC VALUES 
('CSDL', N'Cơ sở dữ liệu', 3),
('LTC', N'Lập trình C', 3),
('KTCT', N'Kinh tế chính trị', 2),
('TA', N'Tiếng Anh', 2);

-- Thêm 8 Kết quả học tập
INSERT INTO KETQUA VALUES 
('SV01', 'CSDL', 8.5), ('SV01', 'LTC', 7.0),
('SV02', 'CSDL', 9.0), ('SV03', 'LTC', 6.5),
('SV04', 'CSDL', 5.5), ('SV05', 'KTCT', 8.0),
('SV06', 'KTCT', 9.5), ('SV06', 'TA', 7.5);

-- Thêm 2 Tài khoản
INSERT INTO TAIKHOAN VALUES ('admin', '123456'), ('giaovien', 'password123');