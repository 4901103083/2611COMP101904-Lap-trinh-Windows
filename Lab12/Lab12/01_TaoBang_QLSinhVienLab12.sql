-- 1. Tạo Database
CREATE DATABASE QLSinhVienLab12;
GO

USE QLSinhVienLab12;
GO

-- 2. Tạo bảng LOP (Phải tạo trước vì SINHVIEN tham chiếu đến)
-- Khóa chính: MaLop
CREATE TABLE LOP (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);
GO

-- 3. Tạo bảng MONHOC (Phải tạo trước vì KETQUA tham chiếu đến)
-- Khóa chính: MaMon
CREATE TABLE MONHOC (
    MaMon VARCHAR(20) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    SoTinChi INT
);
GO

-- 4. Tạo bảng SINHVIEN
-- Khóa chính: MaSV
-- Khóa ngoại: MaLop tham chiếu đến LOP.MaLop
CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    MaLop VARCHAR(20),
    CONSTRAINT FK_SinhVien_Lop FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

-- 5. Tạo bảng KETQUA
-- Khóa chính kép: MaSV và MaMon
-- Khóa ngoại 1: MaSV tham chiếu SINHVIEN.MaSV
-- Khóa ngoại 2: MaMon tham chiếu MONHOC.MaMon
-- Ràng buộc: Diem nằm trong khoảng từ 0 đến 10
CREATE TABLE KETQUA (
    MaSV VARCHAR(20),
    MaMon VARCHAR(20),
    Diem FLOAT,
    GhiChu NVARCHAR(255),
    CONSTRAINT PK_KetQua PRIMARY KEY (MaSV, MaMon),
    CONSTRAINT FK_KetQua_SinhVien FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KetQua_MonHoc FOREIGN KEY (MaMon) REFERENCES MONHOC(MaMon),
    CONSTRAINT CHK_Diem CHECK (Diem >= 0 AND Diem <= 10)
);
GO