CREATE TABLE [dbo].[Products] (
    [ProductId]    INT             NOT NULL,
    [ProductName]  VARCHAR (50)    NOT NULL,
    [Rate]         DECIMAL (18, 2) NOT NULL,
    [Description]  VARCHAR (200)   NOT NULL,
    [CategoryName] VARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

