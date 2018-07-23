
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/22/2018 20:35:20
-- Generated from EDMX file: C:\Users\Lusine\Desktop\Send\ContactsApp\ContactsApp\DataAccess\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Contacts];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[Хранилище ContactsModelContainer].[FK_ContactMailingAddress_ContactID]', 'F') IS NOT NULL
    ALTER TABLE [Хранилище ContactsModelContainer].[ContactMailingAddress] DROP CONSTRAINT [FK_ContactMailingAddress_ContactID];
GO
IF OBJECT_ID(N'[Хранилище ContactsModelContainer].[FK_ContactMailingAddress_MailingAddress]', 'F') IS NOT NULL
    ALTER TABLE [Хранилище ContactsModelContainer].[ContactMailingAddress] DROP CONSTRAINT [FK_ContactMailingAddress_MailingAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailAddress_ContactId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmailAddress] DROP CONSTRAINT [FK_EmailAddress_ContactId];
GO
IF OBJECT_ID(N'[dbo].[FK_PhoneNumber_ContactID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhoneNumber] DROP CONSTRAINT [FK_PhoneNumber_ContactID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
GO
IF OBJECT_ID(N'[dbo].[EmailAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailAddress];
GO
IF OBJECT_ID(N'[dbo].[MailingAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailingAddress];
GO
IF OBJECT_ID(N'[dbo].[PhoneNumber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhoneNumber];
GO
IF OBJECT_ID(N'[Хранилище ContactsModelContainer].[ContactMailingAddress]', 'U') IS NOT NULL
    DROP TABLE [Хранилище ContactsModelContainer].[ContactMailingAddress];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] int  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NULL,
    [Type] int  NOT NULL,
    [BirthDate] datetime  NULL
);
GO

-- Creating table 'EmailAddresses'
CREATE TABLE [dbo].[EmailAddresses] (
    [Id] int  NOT NULL,
    [ContactId] int  NOT NULL,
    [Email] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'MailingAddresses'
CREATE TABLE [dbo].[MailingAddresses] (
    [Id] int  NOT NULL,
    [Mailing] nvarchar(50)  NULL
);
GO

-- Creating table 'PhoneNumbers'
CREATE TABLE [dbo].[PhoneNumbers] (
    [Id] int  NOT NULL,
    [ContactId] int  NOT NULL,
    [Phone] char(9)  NOT NULL
);
GO

-- Creating table 'ContactMailingAddress'
CREATE TABLE [dbo].[ContactMailingAddress] (
    [Contacts_Id] int  NOT NULL,
    [MailingAddresses_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailAddresses'
ALTER TABLE [dbo].[EmailAddresses]
ADD CONSTRAINT [PK_EmailAddresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailingAddresses'
ALTER TABLE [dbo].[MailingAddresses]
ADD CONSTRAINT [PK_MailingAddresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhoneNumbers'
ALTER TABLE [dbo].[PhoneNumbers]
ADD CONSTRAINT [PK_PhoneNumbers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Contacts_Id], [MailingAddresses_Id] in table 'ContactMailingAddress'
ALTER TABLE [dbo].[ContactMailingAddress]
ADD CONSTRAINT [PK_ContactMailingAddress]
    PRIMARY KEY CLUSTERED ([Contacts_Id], [MailingAddresses_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ContactId] in table 'EmailAddresses'
ALTER TABLE [dbo].[EmailAddresses]
ADD CONSTRAINT [FK_EmailAddress_ContactId]
    FOREIGN KEY ([ContactId])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailAddress_ContactId'
CREATE INDEX [IX_FK_EmailAddress_ContactId]
ON [dbo].[EmailAddresses]
    ([ContactId]);
GO

-- Creating foreign key on [ContactId] in table 'PhoneNumbers'
ALTER TABLE [dbo].[PhoneNumbers]
ADD CONSTRAINT [FK_PhoneNumber_ContactID]
    FOREIGN KEY ([ContactId])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhoneNumber_ContactID'
CREATE INDEX [IX_FK_PhoneNumber_ContactID]
ON [dbo].[PhoneNumbers]
    ([ContactId]);
GO

-- Creating foreign key on [Contacts_Id] in table 'ContactMailingAddress'
ALTER TABLE [dbo].[ContactMailingAddress]
ADD CONSTRAINT [FK_ContactMailingAddress_Contact]
    FOREIGN KEY ([Contacts_Id])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MailingAddresses_Id] in table 'ContactMailingAddress'
ALTER TABLE [dbo].[ContactMailingAddress]
ADD CONSTRAINT [FK_ContactMailingAddress_MailingAddress]
    FOREIGN KEY ([MailingAddresses_Id])
    REFERENCES [dbo].[MailingAddresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactMailingAddress_MailingAddress'
CREATE INDEX [IX_FK_ContactMailingAddress_MailingAddress]
ON [dbo].[ContactMailingAddress]
    ([MailingAddresses_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------