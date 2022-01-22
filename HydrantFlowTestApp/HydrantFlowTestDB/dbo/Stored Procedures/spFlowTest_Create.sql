-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Creates a new Flow Test entry
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTest_Create]
	-- Add the parameters for the stored procedure here
	@Id INT = 0 OUTPUT,
	@FlowValveStatusId INT,
	@ModelVersionId INT,
	@Status BIT,
	@TestName NVARCHAR(35),
	@TestDate DATETIME2,
	@PlanFlowDate DATETIME2,
	@Summary NVARCHAR(50),
	@Workorder INT,
	@TestBy NVARCHAR(25),
	@DisplayMap NVARCHAR(255),
	@SiteMap NVARCHAR(255),
	@SimlMap NVARCHAR(255),
	@TotalFlowGpm FLOAT,
	@TestDataFile NVARCHAR(255),
	@MaxErrorStaticPsi FLOAT,
	@AvgErrorStaticPsi FLOAT,
	@MaxErrorResidualPsi FLOAT,
	@AvgErrorResidualPsi FLOAT,
	@FlowErrorGpm FLOAT,
	@VarErrorStaticPsi FLOAT,
	@VarErrorResidualPsi FLOAT,
	@ModelRevisionDate NVARCHAR(50),
	@Calculate NVARCHAR(1),
	@MapScale INT = 5000,
	@CalcFlowAt20 FLOAT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	INSERT INTO [dbo].[FlowTest] (
		[FlowValveStatusId],
		[ModelVersionId],
		[Status],
		[TestName],
		[TestDate],
		[PlanFlowDate],
		[Summary],
		[Workorder],
		[TestBy],
		[DisplayMap],
		[SiteMap],
		[SimlMap],
		[TotalFlowGpm],
		[TestDataFile],
		[MaxErrorStaticPsi],
		[AvgErrorStaticPsi],
		[MaxErrorResidualPsi],
		[AvgErrorResidualPsi],
		[FlowErrorGpm],
		[VarErrorStaticPsi],
		[VarErrorResidualPsi],
		[ModelRevisionDate],
		[Calculate],
		[MapScale],
		[CalcFlowAt20]
	) VALUES (
		@FlowValveStatusId,
		@ModelVersionId,
		@Status,
		@TestName,
		@TestDate,
		@PlanFlowDate,
		@Summary,
		@Workorder,
		@TestBy,
		@DisplayMap,
		@SiteMap,
		@SimlMap,
		@TotalFlowGpm,
		@TestDataFile,
		@MaxErrorStaticPsi,
		@AvgErrorStaticPsi,
		@MaxErrorResidualPsi,
		@AvgErrorResidualPsi,
		@FlowErrorGpm,
		@VarErrorStaticPsi,
		@VarErrorResidualPsi,
		@ModelRevisionDate,
		@Calculate,
		@MapScale,
		@CalcFlowAt20
	);

	SELECT @Id = SCOPE_IDENTITY();
END
GO
