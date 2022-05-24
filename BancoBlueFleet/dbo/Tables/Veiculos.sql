CREATE TABLE [dbo].[Veiculos] (
    [Id]        INT IDENTITY(1,1) NOT NULL,
    [Placa]     NCHAR (7)   NOT NULL,
    [Montadora] NCHAR (100) NOT NULL,
    [Modelo]    NCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);