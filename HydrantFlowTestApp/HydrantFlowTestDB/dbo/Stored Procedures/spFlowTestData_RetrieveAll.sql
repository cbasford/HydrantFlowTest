-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Retrieves all Flow Test Data entries
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTestData_RetrieveAll]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	SELECT [Id],
		[FlowTestId],
		[AssetRole],
		[AssetRoleId],
		[Asset],
		[AssetTypeId],
		[AssetId],
		[Nozzles],
		[NozzleId],
		[StaticPsi],
		[TestPsi],
		[Flow],
		[ModelStaticPsi],
		[ModelTestPsi],
		[ModelFlow],
		[Elevation],
		[DischargeCoeff],
		[Multiplier]
	FROM [dbo].[FlowTestData];
END
GO
