# BÁO CÁO BÀI THỰC HÀNH LAB 10
**Chủ đề:** Thiết kế và cài đặt cơ sở dữ liệu EduManagerDB bằng SQL Server

## Thông tin sinh viên
- **Họ và tên:** Nguyễn Trung Tín
- **MSSV:** 49.01.103.083
- **Trường:** Đại học Sư phạm TP.HCM (HCMUE)

---

## 1. Mục tiêu đã hoàn thành
- Thiết kế thành công CSDL `EduManagerDB` cho bài toán quản lý sinh viên.
- Cài đặt đầy đủ 6 bảng bắt buộc: `KHOA`, `LOP`, `SINHVIEN`, `MONHOC`, `KETQUA`, `TAIKHOAN`.
- Thiết lập chuẩn xác các Khóa chính (Primary Key), Khóa ngoại (Foreign Key).
- Cài đặt các Ràng buộc (Check Constraint): Giới tính (Nam/Nữ), Điểm số (0-10), Số tín chỉ (> 0).
- Chèn đầy đủ dữ liệu mẫu và đảm bảo tính toàn vẹn dữ liệu.
- Thực thi và kiểm thử thành công các câu lệnh truy vấn (SELECT, JOIN, GROUP BY, UPDATE, DELETE).
- Kiểm thử thành công các trường hợp cố tình nhập sai dữ liệu để xác nhận các ràng buộc hoạt động đúng.

## 2. Cấu trúc thư mục nộp bài
Bài nộp bao gồm các tệp tin sau:
1. `01_CreateDatabase.sql`: Script khởi tạo CSDL, tạo bảng và thiết lập khóa, ràng buộc.
2. `02_InsertSampleData.sql`: Script thêm dữ liệu mẫu vào các bảng.
3. `03_Queries.sql`: Script chứa 12 câu lệnh truy vấn dữ liệu và kiểm thử lỗi.
4. `README.md`: Báo cáo chi tiết quá trình thực hiện.
5. Các tệp hình ảnh minh chứng: `1.png`, `2.png`, `3.png`, `4png.png`, `5.png`.

---

## 3. Quy trình thực thi và Kết quả minh chứng

### Bước 1: Khởi tạo Cơ sở dữ liệu
- **Thao tác:** Chạy tệp `01_CreateDatabase.sql`.
- **Kết quả:** Hệ thống tạo thành công CSDL và 6 bảng với đầy đủ cấu trúc.
- **Minh chứng:** Hình ảnh hiển thị thông báo *"Commands completed successfully"*.

![Khởi tạo CSDL thành công](3.png)

### Bước 2: Nhập dữ liệu mẫu
- **Thao tác:** Chạy tệp `02_InsertSampleData.sql`.
- **Kết quả:** Toàn bộ dữ liệu mẫu (2 khoa, 3 lớp, 6 sinh viên, 4 môn học, 8 kết quả, 2 tài khoản) được bơm vào hệ thống thành công, đúng các mối quan hệ giữa các bảng.
- **Minh chứng:** Hình ảnh hiển thị số dòng (rows affected) được thêm vào thành công.

![Nhập dữ liệu thành công](2.png)

### Bước 3: Thực thi các câu lệnh truy vấn (Từ câu 1 đến câu 10)
- **Thao tác:** Bôi đen và chạy các lệnh `SELECT`, `JOIN`, `UPDATE`, `GROUP BY` trong tệp `03_Queries.sql`.
- **Kết quả:** Hệ thống trích xuất và hiển thị dữ liệu chính xác theo yêu cầu (liệt kê sinh viên, thống kê điểm, tìm kiếm,...).
- **Minh chứng:** Hình ảnh hiển thị các bảng kết quả truy xuất dữ liệu (Results).

![Kết quả truy vấn](1.png)

### Bước 4: Kiểm thử ràng buộc dữ liệu (Câu 11 & Câu 12)
Để chứng minh hệ thống được thiết kế chặt chẽ và an toàn, em đã tiến hành chạy thử các lệnh nhập liệu sai quy tắc:

- **Kiểm thử Khóa ngoại (Câu 11):** Tiến hành thêm một sinh viên vào mã lớp `'LOP99'` (lớp không tồn tại). Hệ thống đã chặn lại và văng lỗi.
  - **Minh chứng:** Thông báo lỗi do vi phạm `FOREIGN KEY constraint`.

![Lỗi Khóa ngoại](4png.png)

- **Kiểm thử Điều kiện kiểm tra (Câu 12):** Tiến hành nhập điểm `11` cho sinh viên (vượt quá thang điểm tối đa là 10). Hệ thống lập tức từ chối lệnh nhập.
  - **Minh chứng:** Thông báo lỗi do vi phạm `CHECK constraint`.

![Lỗi Điểm số](5.png)
