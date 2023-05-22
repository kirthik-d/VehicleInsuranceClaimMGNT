IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Insurance_Companies] (
    [Company_Identification_No] int NOT NULL,
    [Company_Name] nvarchar(50) NOT NULL,
    [Company_Contact] nvarchar(50) NOT NULL,
    [Company_Address] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Insurance_Companies] PRIMARY KEY ([Company_Identification_No])
);

GO

CREATE TABLE [Login] (
    [Id] int NOT NULL,
    [UserName] nvarchar(50) NULL,
    [Password] nvarchar(50) NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [User_ID] int NOT NULL,
    [User_Name] nvarchar(50) NOT NULL,
    [Age] int NOT NULL,
    [Email_ID] nvarchar(50) NOT NULL,
    [Address] nvarchar(100) NOT NULL,
    [Mobile_Number] nvarchar(10) NOT NULL,
    [State] nvarchar(50) NOT NULL,
    [Country] nvarchar(50) NOT NULL,
    [Pin_Code] nvarchar(50) NOT NULL,
    [No_Of_Claims] int NULL,
    [Password] nvarchar(50) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([User_ID])
);

GO

CREATE TABLE [Vehicles] (
    [Vehicle_No] int NOT NULL,
    [Vehicle_Name] nvarchar(50) NULL,
    [Vehicle_Type] nvarchar(50) NULL,
    [Vehicle_Model/Maker] nvarchar(50) NULL,
    [Gross_Vehicle_Weight] nvarchar(50) NULL,
    [Vehicle_Power] nvarchar(50) NULL,
    [Vehicle_Capacity] nvarchar(50) NULL,
    [Vehicle_Length] nvarchar(50) NULL,
    [Vehicle_Owner] nvarchar(50) NULL,
    [Vehicle_Engine_No] nvarchar(50) NULL,
    [Fuel_Type] nvarchar(50) NULL,
    [Vehicle_Company] nvarchar(50) NULL,
    [Owner_Id] int NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Vehicle_No]),
    CONSTRAINT [fk_vehicle] FOREIGN KEY ([Owner_Id]) REFERENCES [Users] ([User_ID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Policy] (
    [Policy_Id] int NOT NULL,
    [Vehicle_Id] int NOT NULL,
    [Policy_Name] nvarchar(10) NOT NULL,
    [Effective_Date] date NOT NULL,
    [Expiry_Date] date NOT NULL,
    CONSTRAINT [PK_Policy] PRIMARY KEY ([Policy_Id]),
    CONSTRAINT [fk_policy] FOREIGN KEY ([Vehicle_Id]) REFERENCES [Vehicles] ([Vehicle_No]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Claims] (
    [Claim_Id] int NOT NULL,
    [Policy_Id] int NOT NULL,
    [Vehicle_Bill] nvarchar(50) NULL,
    [Driver_Licence_No] nvarchar(50) NULL,
    [Vehicle_Condition] nvarchar(50) NULL,
    [Claim_Status] nvarchar(50) NULL,
    [User_Id] int NOT NULL,
    CONSTRAINT [PK_Claims] PRIMARY KEY ([Claim_Id]),
    CONSTRAINT [Fk_policyid] FOREIGN KEY ([Policy_Id]) REFERENCES [Policy] ([Policy_Id]) ON DELETE CASCADE,
    CONSTRAINT [Fk_user] FOREIGN KEY ([User_Id]) REFERENCES [Users] ([User_ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Claims_Policy_Id] ON [Claims] ([Policy_Id]);

GO

CREATE INDEX [IX_Claims_User_Id] ON [Claims] ([User_Id]);

GO

CREATE INDEX [IX_Policy_Vehicle_Id] ON [Policy] ([Vehicle_Id]);

GO

CREATE INDEX [IX_Vehicles_Owner_Id] ON [Vehicles] ([Owner_Id]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230405101555_FirstMig', N'2.1.14-servicing-32113');

GO

