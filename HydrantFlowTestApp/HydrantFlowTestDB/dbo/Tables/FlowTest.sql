﻿CREATE TABLE [dbo].[FlowTest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TestName] NVARCHAR(200) NOT NULL, 
    [TestDate] DATETIME2 NOT NULL, 
    [TestCurrent] BIT NOT NULL
)
