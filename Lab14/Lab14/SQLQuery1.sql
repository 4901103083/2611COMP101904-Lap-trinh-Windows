USE master;
GO

-- 1. Ngắt tất cả các kết nối đang dùng database này (ví dụ từ Visual Studio) để cho phép xóa
ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

-- 2. Xóa toàn bộ database cũ
DROP DATABASE IF EXISTS EduManagerDB;
GO

-- 3. Tạo lại database mới
CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

-- 4. Tạo bảng MONHOC chuẩn theo đề bài
CREATE TABLE MONHOC (
    MaMonHoc nvarchar(10) NOT NULL PRIMARY KEY,
    TenMonHoc nvarchar(100) NOT NULL,
    SoTinChi int CHECK (SoTinChi >= 1 AND SoTinChi <= 6),
    TrangThai bit DEFAULT 1
);
GO