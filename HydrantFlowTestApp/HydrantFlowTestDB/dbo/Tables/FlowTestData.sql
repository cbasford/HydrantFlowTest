CREATE TABLE [dbo].[FlowTestData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FlowTestId] INT NULL,
	[AssetRoleId] INT NULL,
	[AssetTypeId] INT NOT NULL,
	[AssetNumber] INT NULL,
	[HydrantNozzleId] INT NULL, 
    [StaticPsi] FLOAT NULL,
	[ResidualPsi] FLOAT NULL,
	[FlowGpm] FLOAT NULL,
	[ModelStaticPsi] FLOAT NULL,
	[ModelResidualPsi] FLOAT NULL,
	[ModelFlowGpm] FLOAT NULL,
	[Elevation] FLOAT NULL,
	[ErrorStaticPsi] FLOAT NULL,
	[ErrorResidualPsi] FLOAT NULL,
	[ErrorFlowGpm] FLOAT NULL,
	[CorrectedErrorResidualPsi] FLOAT NULL,
    CONSTRAINT [FK_FlowTestData_FlowTest] FOREIGN KEY ([FlowTestId]) REFERENCES [FlowTest]([Id])
)
