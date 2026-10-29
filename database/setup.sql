-- Demo schema reconstructed from QuanLyQuanCaPhe/Model1.edmx.
-- Run in SSMS or with sqlcmd against a new demo database.
-- No existing tables or user data are dropped or overwritten.
USE [master];
GO
IF DB_ID(N'CoffeeManagement') IS NULL
    EXEC(N'CREATE DATABASE [CoffeeManagement]');
GO
USE [CoffeeManagement];
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    IF OBJECT_ID(N'dbo.Account') IS NOT NULL
       OR OBJECT_ID(N'dbo.TableFood') IS NOT NULL
       OR OBJECT_ID(N'dbo.Category') IS NOT NULL
       OR OBJECT_ID(N'dbo.Drink') IS NOT NULL
       OR OBJECT_ID(N'dbo.Bill') IS NOT NULL
       OR OBJECT_ID(N'dbo.BillInfo') IS NOT NULL
    BEGIN
        THROW 50001, 'Application tables already exist. Use a new demo database; no changes were applied.', 1;
    END;

    CREATE TABLE dbo.Account (
        Username nvarchar(50) NOT NULL CONSTRAINT PK_Account PRIMARY KEY,
        DisplayName nvarchar(100) NOT NULL,
        Password varchar(50) NOT NULL,
        Access nvarchar(100) NOT NULL
    );

    CREATE TABLE dbo.TableFood (
        IdTable int IDENTITY(1,1) NOT NULL CONSTRAINT PK_TableFood PRIMARY KEY,
        NameTable nvarchar(100) NOT NULL,
        StatusTable nvarchar(30) NOT NULL
    );

    CREATE TABLE dbo.Category (
        IdCategory int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Category PRIMARY KEY,
        NameCategory nvarchar(100) NOT NULL
    );

    CREATE TABLE dbo.Drink (
        IdDrink int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Drink PRIMARY KEY,
        NameDrink nvarchar(100) NOT NULL,
        PriceDrink float NOT NULL,
        IdCategory int NOT NULL,
        CONSTRAINT FK_Drink_Category FOREIGN KEY (IdCategory) REFERENCES dbo.Category(IdCategory)
    );

    CREATE TABLE dbo.Bill (
        IdBill int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Bill PRIMARY KEY,
        DateCheckInBill date NOT NULL,
        DateCheckOutBill date NULL,
        StatusBill bit NOT NULL,
        Discount int NOT NULL,
        TotalPrice float NOT NULL,
        IdTable int NOT NULL,
        CONSTRAINT FK_Bill_TableFood FOREIGN KEY (IdTable) REFERENCES dbo.TableFood(IdTable)
    );

    CREATE TABLE dbo.BillInfo (
        IdBillInfo int IDENTITY(1,1) NOT NULL CONSTRAINT PK_BillInfo PRIMARY KEY,
        IdBill int NOT NULL,
        IdDrink int NOT NULL,
        Amount int NOT NULL,
        CONSTRAINT FK_BillInfo_Bill FOREIGN KEY (IdBill) REFERENCES dbo.Bill(IdBill),
        CONSTRAINT FK_BillInfo_Drink FOREIGN KEY (IdDrink) REFERENCES dbo.Drink(IdDrink)
    );

    -- MD5("1"), matching the existing PasswordHasher and account creation logic.
    INSERT INTO dbo.Account (Username, DisplayName, Password, Access)
    VALUES (N'admin', N'Demo Admin', 'c4ca4238a0b923820dcc509a6f75849b', N'Admin'),
           (N'staff', N'Demo Staff', 'c4ca4238a0b923820dcc509a6f75849b', N'Staff');

    INSERT INTO dbo.TableFood (NameTable, StatusTable)
    VALUES (N'Bàn 1', N'Trống'), (N'Bàn 2', N'Trống'), (N'Bàn 3', N'Trống');

    INSERT INTO dbo.Category (NameCategory)
    VALUES (N'Cà phê'), (N'Trà');

    INSERT INTO dbo.Drink (NameDrink, PriceDrink, IdCategory)
    SELECT N'Cà phê đen', 25000, IdCategory FROM dbo.Category WHERE NameCategory = N'Cà phê'
    UNION ALL
    SELECT N'Cà phê sữa', 30000, IdCategory FROM dbo.Category WHERE NameCategory = N'Cà phê'
    UNION ALL
    SELECT N'Trà đào', 35000, IdCategory FROM dbo.Category WHERE NameCategory = N'Trà';

    COMMIT TRANSACTION;
    PRINT 'CoffeeManagement demo database is ready. Demo accounts: admin / 1 and staff / 1.';
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO
