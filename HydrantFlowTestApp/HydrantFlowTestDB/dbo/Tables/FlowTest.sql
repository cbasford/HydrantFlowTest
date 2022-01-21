﻿CREATE TABLE [dbo].[FlowTest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FlowValveStatusId] INT NULL,
	[ModelVersionId] INT NULL,
	[Status] BIT NULL,
	[TestName] NVARCHAR(35) NULL,
	[TestDate] DATETIME2 NULL,
	[PlanFlowDate] DATETIME2 NULL,
	[Summary] NVARCHAR(50) NULL,
	[Workorder] INT NULL,
	[TestBy] NVARCHAR(25) NULL,
	[DisplayMap] NVARCHAR(255) NULL,
	[SiteMap] NVARCHAR(255) NULL,
	[SimlMap] NVARCHAR(255) NULL,
	[TotalFlowGpm] FLOAT NULL,
	[TestDataFile] NVARCHAR(255) NULL,
	[MaxErrorStaticPsi] FLOAT NULL,
	[AvgErrorStaticPsi] FLOAT NULL,
	[MaxErrorResidualPsi] FLOAT NULL,
	[AvgErrorResidualPsi] FLOAT NULL,
	[FlowErrorGpm] FLOAT NULL,
	[VarErrorStaticPsi] FLOAT NULL,
	[VarErrorResidualPsi] FLOAT NULL,
	[ModelRevisionDate] NVARCHAR(50) NULL,
	[Calculate] NVARCHAR(1) NULL,
	[MapScale] INT NOT NULL DEFAULT 5000,
	[CalcFlowAt20] FLOAT NULL DEFAULT 0
)
