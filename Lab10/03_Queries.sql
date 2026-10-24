USE EduManagerDB;
GO

-- 1. Liệt kê toàn bộ sinh viên
SELECT * FROM SINHVIEN;

-- 2. Liệt kê sinh viên kèm tên lớp và tên khoa
SELECT SV.MaSV, SV.HoTen, L.TenLop, K.TenKhoa
FROM SINHVIEN SV
JOIN LOP L ON SV.MaLop = L.MaLop
JOIN KHOA K ON L.MaKhoa = K.MaKhoa;

-- 3. Tìm sinh viên theo một phần họ tên bằng LIKE (VD: tên 'A')
SELECT * FROM SINHVIEN WHERE HoTen LIKE N'%A%';

-- 4. Liệt kê sinh viên theo mã lớp (VD: lớp 'CNTT1')
SELECT * FROM SINHVIEN WHERE MaLop = 'CNTT1';

-- 5. Cập nhật họ tên hoặc lớp của một sinh viên
UPDATE SINHVIEN SET HoTen = N'Nguyễn Văn A Phẩy' WHERE MaSV = 'SV01';

-- 6. Xóa một sinh viên chưa có dữ liệu điểm 
-- (SV05 có điểm rồi, ta giả sử SV05 chưa có điểm để xóa, hoặc tạo SV mới chưa có điểm để xóa)
-- Cách an toàn: Tạo SV mới rồi xóa
INSERT INTO SINHVIEN VALUES ('SV99', N'Test Xóa', N'Nam', '2000-01-01', 'KT1');
DELETE FROM SINHVIEN WHERE MaSV = 'SV99' AND MaSV NOT IN (SELECT MaSV FROM KETQUA);

-- 7. Liệt kê điểm của từng sinh viên theo từng môn
SELECT SV.HoTen, MH.TenMH, KQ.Diem
FROM KETQUA KQ
JOIN SINHVIEN SV ON KQ.MaSV = SV.MaSV
JOIN MONHOC MH ON KQ.MaMH = MH.MaMH;

-- 8. Tính điểm trung bình của từng sinh viên
SELECT MaSV, AVG(Diem) AS DiemTrungBinh
FROM KETQUA
GROUP BY MaSV;

-- 9. Thống kê số sinh viên theo từng lớp
SELECT MaLop, COUNT(MaSV) AS SoLuongSinhVien
FROM SINHVIEN
GROUP BY MaLop;

-- 10. Liệt kê các lớp có từ 2 sinh viên trở lên
SELECT MaLop, COUNT(MaSV) AS SoLuongSinhVien
FROM SINHVIEN
GROUP BY MaLop
HAVING COUNT(MaSV) >= 2;

-- 11. Test lỗi khi thêm sinh viên vào lớp không tồn tại (sẽ báo lỗi Foreign Key)
-- Ghi chú lại trong script hoặc chụp ảnh lỗi
-- INSERT INTO SINHVIEN VALUES ('SV07', N'Lỗi Lớp', N'Nam', '2000-01-01', 'LOP_KHONG_TON_TAI');

-- 12. Test lỗi khi nhập điểm ngoài khoảng 0 đến 10 (sẽ báo lỗi Check Constraint)
-- INSERT INTO KETQUA VALUES ('SV01', 'TA', 11);