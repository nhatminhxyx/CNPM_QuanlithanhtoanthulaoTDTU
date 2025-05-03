create database Quanlithulao


-------------------------------------------------------------
-- 2. Tạo lại bảng từ đầu
-------------------------------------------------------------

-- Bảng Khoa
CREATE TABLE Khoa (
    MaKhoa NVARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

-- Bảng Users
CREATE TABLE Users (
    Username NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(100) NOT NULL,  -- Lưu ý: nên mã hóa mật khẩu thực tế
    MaLienKet Nvarchar(20),
	Role NVARCHAR(20) NOT NULL         -- 'Admin', 'User', 'Student'
);
alter table users add MaLienKet Nvarchar(20)
-- Bảng GiangVien
CREATE TABLE GiangVien (
    MaGV NVARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    MaKhoa NVARCHAR(10) NOT NULL,
    HocVi NVARCHAR(50),
	QueQuan NVARCHAR(50),
    SoDienThoai NVARCHAR(15) DEFAULT N'Chưa cập nhật',
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);
 


-- Bảng DeTai
CREATE TABLE DeTai (
    MaDeTai NVARCHAR(20) PRIMARY KEY,
    TenDeTai NVARCHAR(255) NOT NULL,
    MaKhoa NVARCHAR(10) NOT NULL,
    MaGV NVARCHAR(20) NOT NULL,
    KinhPhi float,
    ThoiGianBatDau DATE,
    ThoiGianKetThuc DATE,
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa),
    FOREIGN KEY (MaGV) REFERENCES GiangVien(MaGV)
);
alter table DeTai add Trangthai nvarchar(20) default 

-- Bảng SinhVien
CREATE TABLE SinhVien (
    MaSV NVARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Lop NVARCHAR(50) NOT NULL,
    NgaySinh DATE NOT NULL,
    QueQuan NVARCHAR(100) NOT NULL,
    MaKhoa NVARCHAR(10) NOT NULL,
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);


-- Tạo bảng DangKyDeTai
CREATE TABLE DangKyDeTai (
    MaDangKy INT IDENTITY(1,1) PRIMARY KEY,
    MaSV NVARCHAR(20) NOT NULL,
    MaDeTai NVARCHAR(20) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT 'Chờ duyệt',
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaDeTai) REFERENCES DeTai(MaDeTai)
);

CREATE TABLE ThanhToan (
    MaThanhToan NVARCHAR(20) PRIMARY KEY,
    MaGV NVARCHAR(20) NOT NULL,
    MaDeTai NVARCHAR(20) NOT NULL,
    SoTien FLOAT NOT NULL,
    NgayThanhToan DATE NOT NULL,
    TrangThai NVARCHAR(50),
    FOREIGN KEY (MaGV) REFERENCES GiangVien(MaGV),
    FOREIGN KEY (MaDeTai) REFERENCES DeTai(MaDeTai)
);

-------------------------------------------------------------
-- 3. Trigger tự động thêm User khi Insert GiangVien và SinhVien
-------------------------------------------------------------

create TRIGGER trg_AddUser_GiangVien
ON GiangVien
AFTER INSERT
AS
BEGIN
    -- Thêm tài khoản người dùng với MaLienKet là MaGV
    INSERT INTO Users (Username, Password, Role, MaLienKet)
    SELECT MaGV, MaGV, 'GV', MaGV
    FROM inserted;
END

-- Trigger thêm User cho Sinh Viên khi thêm mới
create TRIGGER trg_AddUser_SinhVien
ON SinhVien
AFTER INSERT
AS
BEGIN
    -- Thêm tài khoản người dùng với MaLienKet là MaSV
    INSERT INTO Users (Username, Password, Role, MaLienKet)
    SELECT MaSV, MaSV, 'SV', MaSV
    FROM inserted;
END
-- Xóa User khi xóa Giảng Viên
create TRIGGER trg_DeleteUser_GiangVien
ON GiangVien
AFTER DELETE
AS
BEGIN
    DELETE FROM Users
    WHERE MaLienKet IN (SELECT MaGV FROM deleted);
END

-- Xóa User khi xóa Sinh Viên
create TRIGGER trg_DeleteUser_SinhVien
ON SinhVien
AFTER DELETE
AS
BEGIN
    DELETE FROM Users
    WHERE MaLienKet IN (SELECT MaSV FROM deleted);
END


-------------------------------------------------------------
-- 4. Thủ tục đăng nhập và đổi mật khẩu
-------------------------------------------------------------

-- Thủ tục đăng nhập
CREATE PROCEDURE proc_login
    @Username NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Role
    FROM Users
    WHERE Username = @Username AND Password = @Password;
END

-- Thủ tục đổi mật khẩu
CREATE PROCEDURE proc_change_password
    @Username NVARCHAR(50),
    @OldPassword NVARCHAR(100),
    @NewPassword NVARCHAR(100),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Users WHERE Username = @Username AND Password = @OldPassword)
    BEGIN
        UPDATE Users
        SET Password = @NewPassword
        WHERE Username = @Username;
        SET @Result = 1; -- Thành công
    END
    ELSE
    BEGIN
        SET @Result = 0; -- Sai mật khẩu cũ
    END
END

-------------------------------------------------------------
-- 5. Thêm dữ liệu mẫu ban đầu
-------------------------------------------------------------

-- Thêm Khoa
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES
('IT', N'Công nghệ thông tin'),
('MKT', N'Marketing'),
('QTKD', N'Quản trị kinh doanh'),
('SP', N'Sư phạm');

-- Thêm tài khoản Admin
INSERT INTO Users (Username, Password, Role) VALUES
('admin', 'admin123', 'Admin');


select * from GiangVien
select * from Users
select * from SinhVien
select * from DeTai
select * FROM ThanhToan;
select * from DangKyDeTai

