﻿CREATE TABLE [dbo].[tblVehicle]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [MakeId] UNIQUEIDENTIFIER NOT NULL, 
    [ColorId] UNIQUEIDENTIFIER NOT NULL, 
    [ModelId] UNIQUEIDENTIFIER NOT NULL, 
    [VIN] VARCHAR(20) NOT NULL, 
    [Year] INT NOT NULL
)
