-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Creates a new Flow Test Data entry
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTestData_Create]
	-- Add the parameters for the stored procedure here
	@Id INT = 0 OUTPUT,
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
	INSERT INTO [dbo].[FlowTestData] (
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
	) VALUES (
		@FlowTestId,
		@AssetRole,
		@AssetRoleId,
		@Asset,
		@AssetTypeId,
		@AssetId,
		@Nozzles,
		@NozzleId,
		@StaticPsi,
		@TestPsi,
		@Flow,
		@ModelStaticPsi,
		@ModelTestPsi,
		@ModelFlow,
		@Elevation,
		@DischargeCoeff,
		@Multiplier
	);

	SELECT @Id = SCOPE_IDENTITY();
END
GO
