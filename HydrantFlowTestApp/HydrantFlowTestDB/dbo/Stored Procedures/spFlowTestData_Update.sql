-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Updates a Flow Test Data entry by Id
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTestData_Update]
	-- Add the parameters for the stored procedure here
	@Id INT,
	@FlowTestId INT,
	@AssetRole NVARCHAR(50),
	@AssetRoleId INT,
	@Asset NVARCHAR(200),
	@AssetTypeId INT,
	@AssetId INT,
	@Nozzles nvarchar(100),
	@NozzleId INT,
	@StaticPsi FLOAT,
	@TestPsi FLOAT,
	@Flow FLOAT,
	@ModelStaticPsi FLOAT,
	@ModelTestPsi FLOAT,
	@ModelFlow FLOAT,
	@Elevation FLOAT,
	@DischargeCoeff FLOAT,
	@Multiplier FLOAT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	UPDATE [dbo].[FlowTestData]
	SET [FlowTestId] = @FlowTestId,
		[AssetRole] = @AssetRole,
		[AssetRoleId] = @AssetRoleId,
		[Asset] = @Asset,
		[AssetTypeId] = @AssetTypeId,
		[AssetId] = @AssetId,
		[Nozzles] = @Nozzles,
		[NozzleId] = @NozzleId,
		[StaticPsi] = @StaticPsi,
		[TestPsi] = @TestPsi,
		[Flow] = @Flow,
		[ModelStaticPsi] = @ModelStaticPsi,
		[ModelTestPsi] = @ModelTestPsi,
		[ModelFlow] = @ModelFlow,
		[Elevation] = @Elevation,
		[DischargeCoeff] = @DischargeCoeff,
		[Multiplier] = @Multiplier
	WHERE [Id] = @Id;
END
GO
