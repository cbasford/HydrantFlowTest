-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Updates a Flow Test entry by Id
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTest_Update]
	-- Add the parameters for the stored procedure here
	@Id INT,
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
	UPDATE [dbo].[FlowTest]
	SET [FlowValveStatusId] = @FlowValveStatusId,
		[ModelVersionId] = @ModelVersionId,
		[Status] = @Status,
		[TestName] = @TestName,
		[TestDate] = @TestDate,
		[PlanFlowDate] = @PlanFlowDate,
		[Summary] = @Summary,
		[Workorder] = @Workorder,
		[TestBy] = @TestBy,
		[DisplayMap] = @DisplayMap,
		[SiteMap] = @SiteMap,
		[SimlMap] = @SimlMap,
		[TotalFlowGpm] = @TotalFlowGpm,
		[TestDataFile] = @TestDataFile,
		[MaxErrorStaticPsi] = @MaxErrorStaticPsi,
		[AvgErrorStaticPsi] = @AvgErrorStaticPsi,
		[MaxErrorResidualPsi] = @MaxErrorResidualPsi,
		[AvgErrorResidualPsi] = @AvgErrorResidualPsi,
		[FlowErrorGpm] = @FlowErrorGpm,
		[VarErrorStaticPsi] = @VarErrorStaticPsi,
		[VarErrorResidualPsi] = @VarErrorResidualPsi,
		[ModelRevisionDate] = @ModelRevisionDate,
		[Calculate] = @Calculate,
		[MapScale] = @MapScale,
		[CalcFlowAt20] = @CalcFlowAt20
	WHERE [Id] = @Id;
END
GO
