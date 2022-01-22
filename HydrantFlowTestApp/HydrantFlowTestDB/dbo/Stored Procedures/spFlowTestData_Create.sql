-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Creates a new Flow Test Data entry
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTestData_Create]
	-- Add the parameters for the stored procedure here
	@Id INT = 0 OUTPUT,
	@FlowTestId INT,
	@AssetRoleId INT,
	@AssetTypeId INT,
	@AssetNumber INT,
	@HydrantNozzleId INT,
	@StaticPsi FLOAT,
	@ResidualPsi FLOAT,
	@FlowGpm FLOAT,
	@ModelStaticPsi FLOAT,
	@ModelResidualPsi FLOAT,
	@ModelFlowGpm FLOAT,
	@Elevation FLOAT,
	@ErrorStaticPsi FLOAT,
	@ErrorResidualPsi FLOAT,
	@ErrorFlowGpm FLOAT,
	@CorrectedErrorResidualPsi FLOAT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	INSERT INTO [dbo].[FlowTestData] (
		[FlowTestId],
		[AssetRoleId],
		[AssetTypeId],
		[AssetNumber],
		[HydrantNozzleId],
		[StaticPsi],
		[ResidualPsi],
		[FlowGpm],
		[ModelStaticPsi],
		[ModelResidualPsi],
		[ModelFlowGpm],
		[ErrorStaticPsi],
		[ErrorResidualPsi],
		[ErrorFlowGpm],
		[Elevation],
		[CorrectedErrorResidualPsi]
	) VALUES (
		@FlowTestId,
		@AssetRoleId,
		@AssetTypeId,
		@AssetNumber,
		@HydrantNozzleId,
		@StaticPsi,
		@ResidualPsi,
		@FlowGpm,
		@ModelStaticPsi,
		@ModelResidualPsi,
		@ModelFlowGpm,
		@ErrorStaticPsi,
		@ErrorResidualPsi,
		@ErrorFlowGpm,
		@Elevation,
		@CorrectedErrorResidualPsi
	);

	SELECT @Id = SCOPE_IDENTITY();
END
GO
