
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/26/2015 07:25:06
-- Generated from EDMX file: C:\Users\jws85\Desktop\Source\PersonnalContact\Contact.Repository\Contact.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ContactDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ContactAddress_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactAddress] DROP CONSTRAINT [FK_ContactAddress_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonAddress_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactAddress] DROP CONSTRAINT [FK_PersonAddress_Address];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
GO
IF OBJECT_ID(N'[dbo].[ContactAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactAddress];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Line1] nvarchar(50)  NULL,
    [Line2] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [State] nvarchar(50)  NULL,
    [Country] nvarchar(50)  NULL
);
GO

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MobileNo] nvarchar(50)  NULL,
    [HomePhoneNo] nvarchar(50)  NULL,
    [OfficePhoneNo] nvarchar(50)  NULL,
    [Type] nvarchar(50)  NULL,
    [OrganizationName] nvarchar(50)  NULL,
    [FirstName] nvarchar(50)  NULL,
    [MiddleName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [SSN] nvarchar(50)  NULL
);
GO

-- Creating table 'ContactAddresses'
CREATE TABLE [dbo].[ContactAddresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ContactId] int  NULL,
    [AddressId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactAddresses'
ALTER TABLE [dbo].[ContactAddresses]
ADD CONSTRAINT [PK_ContactAddresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AddressId] in table 'ContactAddresses'
ALTER TABLE [dbo].[ContactAddresses]
ADD CONSTRAINT [FK_PersonAddress_Address]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonAddress_Address'
CREATE INDEX [IX_FK_PersonAddress_Address]
ON [dbo].[ContactAddresses]
    ([AddressId]);
GO

-- Creating foreign key on [ContactId] in table 'ContactAddresses'
ALTER TABLE [dbo].[ContactAddresses]
ADD CONSTRAINT [FK_ContactAddress_Contact]
    FOREIGN KEY ([ContactId])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactAddress_Contact'
CREATE INDEX [IX_FK_ContactAddress_Contact]
ON [dbo].[ContactAddresses]
    ([ContactId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------