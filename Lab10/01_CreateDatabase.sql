USE master;
GO
DROP DATABASE IF EXISTS EduManagerDB;
GO
CREATE DATABASE EduManagerDB;
GO
USE EduManagerDB;
GO

-- 1. Bảng KHOA
CREATE TABLE KHOA (
    MaKhoa VARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

-- 2. Bảng LOP (Tham chiếu KHOA)
CREATE TABLE LOP (
    MaLop VARCHAR(10) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(10),
    FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
);

-- 3. Bảng SINHVIEN (Tham chiếu LOP, ràng buộc Giới tính)
CREATE TABLE SINHVIEN (
    MaSV VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ')), -- Ràng buộc giới tính[cite: 1]
    NgaySinh DATE,
    MaLop VARCHAR(10),
    FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);

-- 4. Bảng MONHOC (Ràng buộc Số tín chỉ > 0)
CREATE TABLE MONHOC (
    MaMH VARCHAR(10) PRIMARY KEY,
    TenMH NVARCHAR(100) NOT NULL,
    SoTinChi INT CHECK (SoTinChi > 0) -- Ràng buộc số tín chỉ[cite: 1]
);

-- 5. Bảng KETQUA (Tham chiếu SINHVIEN và MONHOC, ràng buộc Điểm 0-10)
CREATE TABLE KETQUA (
    MaSV VARCHAR(10),
    MaMH VARCHAR(10),
    Diem FLOAT CHECK (Diem >= 0 AND Diem <= 10), -- Ràng buộc điểm số[cite: 1]
    PRIMARY KEY (MaSV, MaMH),
    FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);

-- 6. Bảng TAIKHOAN
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(50) NOT NULL
);