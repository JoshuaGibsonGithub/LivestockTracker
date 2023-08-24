
CREATE TABLE [dbo].[Employees] (
    [Username] NVARCHAR (20) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
);



CREATE TABLE [dbo].[Farmers] (
    [Username] NVARCHAR (20) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
);

CREATE TABLE [dbo].[Products] (
    [ProductName] NVARCHAR (50) NOT NULL,
    [ProductType] NVARCHAR (50) NOT NULL,
    [DateAdded] Date NOT NULL,
    [Username] NVARCHAR (10) NOT NULL,
);

INSERT INTO Farmers
VALUES ('John', 'Password');

INSERT INTO Products
VALUES ('Eli2', 'Lamb2', '2021/05/16', 'Farmer1');
