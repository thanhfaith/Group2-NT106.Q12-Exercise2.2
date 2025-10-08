
USE QuanlyNguoiDung;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    MatKhau NVARCHAR(256) NOT NULL,
    SoDienThoai NVARCHAR(15) NULL,
    NgaySinh DATE NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    );
END
GO

SELECT * FROM Users;