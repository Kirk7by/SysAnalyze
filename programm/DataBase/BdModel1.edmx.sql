
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/18/2015 15:23:25
-- Generated from EDMX file: C:\my program Projects\SysAnalyze\programm\DataBase\BdModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DataBase.Model1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ВодителиАвтомобили]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[АвтомобилиSet] DROP CONSTRAINT [FK_ВодителиАвтомобили];
GO
IF OBJECT_ID(N'[dbo].[FK_Путевые_листыВодители]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Путевые_листыSet] DROP CONSTRAINT [FK_Путевые_листыВодители];
GO
IF OBJECT_ID(N'[dbo].[FK_Путевые_листыАвтомобили]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Путевые_листыSet] DROP CONSTRAINT [FK_Путевые_листыАвтомобили];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ВодителиSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ВодителиSet];
GO
IF OBJECT_ID(N'[dbo].[АвтомобилиSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[АвтомобилиSet];
GO
IF OBJECT_ID(N'[dbo].[Путевые_листыSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Путевые_листыSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ВодителиSet'
CREATE TABLE [dbo].[ВодителиSet] (
    [Табельный_номер] int IDENTITY(1,1) NOT NULL,
    [ФИО] nvarchar(max)  NOT NULL,
    [Дата_взятия_на_работу] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'АвтомобилиSet'
CREATE TABLE [dbo].[АвтомобилиSet] (
    [Регистрационный_номер] nvarchar(max)  NOT NULL,
    [ВодителиТабельный_номер] int  NOT NULL,
    [Марка_авто] nvarchar(max)  NOT NULL,
    [Дата_выпуска] datetime  NOT NULL,
    [Путевые_листыНомер_путевого] int  NOT NULL
);
GO

-- Creating table 'Путевые_листыSet'
CREATE TABLE [dbo].[Путевые_листыSet] (
    [Номер_путевого] int IDENTITY(1,1) NOT NULL,
    [Дата_и_время_отправления] datetime  NOT NULL,
    [Показания_спидометра] int  NULL,
    [Остаток_топлива] int  NULL,
    [Остаток_топлива_при_приезде] int  NULL,
    [Показания_спидометра_при_приезде] int  NULL,
    [Марка_топлива] nvarchar(max)  NULL,
    [Дата_время_возвращения] datetime  NULL,
    [Количество_литров] int  NULL,
    [Водители_Табельный_номер] int  NOT NULL,
    [Автомобили_Регистрационный_номер] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Табельный_номер] in table 'ВодителиSet'
ALTER TABLE [dbo].[ВодителиSet]
ADD CONSTRAINT [PK_ВодителиSet]
    PRIMARY KEY CLUSTERED ([Табельный_номер] ASC);
GO

-- Creating primary key on [Регистрационный_номер] in table 'АвтомобилиSet'
ALTER TABLE [dbo].[АвтомобилиSet]
ADD CONSTRAINT [PK_АвтомобилиSet]
    PRIMARY KEY CLUSTERED ([Регистрационный_номер] ASC);
GO

-- Creating primary key on [Номер_путевого] in table 'Путевые_листыSet'
ALTER TABLE [dbo].[Путевые_листыSet]
ADD CONSTRAINT [PK_Путевые_листыSet]
    PRIMARY KEY CLUSTERED ([Номер_путевого] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ВодителиТабельный_номер] in table 'АвтомобилиSet'
ALTER TABLE [dbo].[АвтомобилиSet]
ADD CONSTRAINT [FK_ВодителиАвтомобили]
    FOREIGN KEY ([ВодителиТабельный_номер])
    REFERENCES [dbo].[ВодителиSet]
        ([Табельный_номер])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ВодителиАвтомобили'
CREATE INDEX [IX_FK_ВодителиАвтомобили]
ON [dbo].[АвтомобилиSet]
    ([ВодителиТабельный_номер]);
GO

-- Creating foreign key on [Водители_Табельный_номер] in table 'Путевые_листыSet'
ALTER TABLE [dbo].[Путевые_листыSet]
ADD CONSTRAINT [FK_Путевые_листыВодители]
    FOREIGN KEY ([Водители_Табельный_номер])
    REFERENCES [dbo].[ВодителиSet]
        ([Табельный_номер])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Путевые_листыВодители'
CREATE INDEX [IX_FK_Путевые_листыВодители]
ON [dbo].[Путевые_листыSet]
    ([Водители_Табельный_номер]);
GO

-- Creating foreign key on [Автомобили_Регистрационный_номер] in table 'Путевые_листыSet'
ALTER TABLE [dbo].[Путевые_листыSet]
ADD CONSTRAINT [FK_Путевые_листыАвтомобили]
    FOREIGN KEY ([Автомобили_Регистрационный_номер])
    REFERENCES [dbo].[АвтомобилиSet]
        ([Регистрационный_номер])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Путевые_листыАвтомобили'
CREATE INDEX [IX_FK_Путевые_листыАвтомобили]
ON [dbo].[Путевые_листыSet]
    ([Автомобили_Регистрационный_номер]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------