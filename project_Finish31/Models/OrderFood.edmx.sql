
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/22/2020 13:56:59
-- Generated from EDMX file: E:\專題版面\project0722\project0722new\Models\OrderFood.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OrderFood];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OrderTableOrderDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT [FK_OrderTableOrderDetail];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FoodUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodUser];
GO
IF OBJECT_ID(N'[dbo].[FoodProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodProduct];
GO
IF OBJECT_ID(N'[dbo].[OrderDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetail];
GO
IF OBJECT_ID(N'[dbo].[OrderTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderTable];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FoodUser'
CREATE TABLE [dbo].[FoodUser] (
    [UserID] int  NOT NULL,
    [UserName] nvarchar(30)  NULL,
    [PhoneNum] char(10)  NULL,
    [Email] varchar(50)  NULL,
    [BirthDate] datetime  NULL,
    [Address] nvarchar(50)  NULL,
    [Password] varchar(100)  NULL
);
GO

-- Creating table 'FoodProduct'
CREATE TABLE [dbo].[FoodProduct] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [ProductClass] char(15)  NULL,
    [ProductName] nvarchar(30)  NULL,
    [Price] int  NULL,
    [Weight] int  NULL,
    [Calories] int  NULL,
    [Photo] varchar(50)  NULL,
    [Caption] nvarchar(200)  NULL,
    [Seasoning] nvarchar(50)  NULL,
    [Description] nvarchar(max)  NULL,
    [test] int  NOT NULL
);
GO

-- Creating table 'OrderDetail'
CREATE TABLE [dbo].[OrderDetail] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [ProductID] int  NULL,
    [ProductName] nvarchar(30)  NULL,
    [Amount] int  NULL,
    [Price] int  NULL,
    [OrderTableOrderID] int  NOT NULL
);
GO

-- Creating table 'OrderTable'
CREATE TABLE [dbo].[OrderTable] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [PriceTotal] int  NOT NULL,
    [OrderDate] datetime  NULL,
    [ShipDate] datetime  NULL,
    [Status] char(10)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'FoodUser'
ALTER TABLE [dbo].[FoodUser]
ADD CONSTRAINT [PK_FoodUser]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [ProductID] in table 'FoodProduct'
ALTER TABLE [dbo].[FoodProduct]
ADD CONSTRAINT [PK_FoodProduct]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [OrderID] in table 'OrderDetail'
ALTER TABLE [dbo].[OrderDetail]
ADD CONSTRAINT [PK_OrderDetail]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [OrderID] in table 'OrderTable'
ALTER TABLE [dbo].[OrderTable]
ADD CONSTRAINT [PK_OrderTable]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OrderTableOrderID] in table 'OrderDetail'
ALTER TABLE [dbo].[OrderDetail]
ADD CONSTRAINT [FK_OrderTableOrderDetail]
    FOREIGN KEY ([OrderTableOrderID])
    REFERENCES [dbo].[OrderTable]
        ([OrderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderTableOrderDetail'
CREATE INDEX [IX_FK_OrderTableOrderDetail]
ON [dbo].[OrderDetail]
    ([OrderTableOrderID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------