CREATE PROC sp_Lop_GetAll
AS
BEGIN
    SELECT MaLop, TenLop FROM LOP;
END
GO
CREATE PROC sp_MonHoc_GetAll
AS
BEGIN
    SELECT MaMon, TenMon, SoTinChi FROM MONHOC;
END
GO
CREATE PROC sp_KetQua_GetByLopMon
    @MaLop VARCHAR(20),
    @MaMon VARCHAR(20)
AS
BEGIN
    SELECT 
        sv.MaSV, 
        sv.HoTen, 
        kq.Diem, 
        kq.GhiChu
    FROM 
        SINHVIEN sv
    -- Dùng LEFT JOIN để lấy tất cả sinh viên của lớp, kể cả chưa có điểm
    LEFT JOIN KETQUA kq ON sv.MaSV = kq.MaSV AND kq.MaMon = @MaMon
    WHERE 
        sv.MaLop = @MaLop;
END
GO
CREATE PROC sp_KetQua_Save
    @MaSV VARCHAR(20),
    @MaMon VARCHAR(20),
    @Diem FLOAT,
    @GhiChu NVARCHAR(255)
AS
BEGIN
    -- Kiểm tra xem đã tồn tại bản ghi của sinh viên và môn học này chưa
    IF EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = @MaSV AND MaMon = @MaMon)
    BEGIN
        -- Nếu đã có -> Cập nhật điểm và ghi chú
        UPDATE KETQUA 
        SET 
            Diem = @Diem, 
            GhiChu = @GhiChu 
        WHERE 
            MaSV = @MaSV AND MaMon = @MaMon;
    END
    ELSE
    BEGIN
        -- Nếu chưa có -> Thêm mới dòng dữ liệu
        INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) 
        VALUES (@MaSV, @MaMon, @Diem, @GhiChu);
    END
END
GO