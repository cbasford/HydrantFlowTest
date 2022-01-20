CREATE TABLE [dbo].[FlowTestData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FlowTestId] INT NOT NULL,
	[AssetRole] NVARCHAR(50) NOT NULL,
	[AssetRoleId] INT NOT NULL,
	[Asset] NVARCHAR(200) NOT NULL,
	[AssetTypeId] INT NOT NULL,
	[AssetId] INT NOT NULL,
	[Nozzles] NVARCHAR(100) NOT NULL,
	[NozzleId] INT NOT NULL, 
    [StaticPsi] FLOAT NOT NULL,
	[TestPsi] FLOAT NOT NULL,
	[Flow] FLOAT NOT NULL,
	[ModelStaticPsi] FLOAT NOT NULL,
	[ModelTestPsi] FLOAT NOT NULL,
	[ModelFlow] FLOAT NOT NULL,
	[Elevation] FLOAT NOT NULL,
	[DischargeCoeff] FLOAT NOT NULL,
	[Multiplier] FLOAT NOT NULL, 
    CONSTRAINT [FK_FlowTestData_FlowTest] FOREIGN KEY ([FlowTestId]) REFERENCES [FlowTest]([Id])
)
