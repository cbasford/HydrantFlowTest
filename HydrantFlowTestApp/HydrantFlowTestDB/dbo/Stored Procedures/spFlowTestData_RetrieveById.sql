-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Retrieves Flow Test Data entry by Id
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTestData_RetrieveById]
	-- Add the parameters for the stored procedure here
	@Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	SELECT [Id],
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
	FROM [dbo].[FlowTestData]
	WHERE [Id] = @Id;
END
GO
