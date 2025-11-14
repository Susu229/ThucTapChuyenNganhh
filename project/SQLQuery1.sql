USE QuanLyCaPheSU;
GO

SELECT DB_NAME() AS CurrentDB;

SELECT TABLE_SCHEMA, TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME LIKE '%Product%';

CREATE TABLE Products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Code NVARCHAR(20),
    Name NVARCHAR(100),
    Price INT,
    Status NVARCHAR(50)
);


INSERT INTO dbo.Products (Code, Name, Price, Status) VALUES
('LAT01', 'Latte', 32000, N'Còn hàng'),
('MAT01', 'Matcha Latte', 35000, N'Còn hàng'),
('CAP01', 'Cappuccino', 34000, N'Sắp hết'),
('ESP01', 'Espresso', 28000, N'Còn hàng'),
('MOCHA01', 'Mocha', 36000, N'Hết hàng'),
('AME01', 'Americano', 30000, N'Còn hàng'),
('CARAMEL01', 'Caramel Macchiato', 39000, N'Còn hàng'),
('CHOCO01', 'Chocolate', 33000, N'Sắp hết'),
('MILK01', N'Sữa Tươi Trân Châu Đường Đen', 29000, N'Còn hàng'),
('TRA01', N'Trà Đào Cam Sả', 32000, N'Hết hàng');
