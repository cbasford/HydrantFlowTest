-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Updates a Flow Test Data entry by Id
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTestData_Update]
	-- Add the parameters for the stored procedure here
	@Id INT,
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
	UPDATE [dbo].[FlowTestData]
	SET [FlowTestId] = @FlowTestId,
		[AssetRoleId] = @AssetRoleId,
		[AssetTypeId] = @AssetTypeId,
		[AssetNumber] = @AssetNumber,
		[HydrantNozzleId] = @HydrantNozzleId,
		[StaticPsi] = @StaticPsi,
		[ResidualPsi] = @ResidualPsi,
		[FlowGpm] = @FlowGpm,
		[ModelStaticPsi] = @ModelStaticPsi,
		[ModelResidualPsi] = @ModelResidualPsi,
		[ModelFlowGpm] = @ModelFlowGpm,
		[ErrorStaticPsi] = @ErrorStaticPsi,
		[ErrorResidualPsi] = @ErrorResidualPsi,
		[ErrorFlowGpm] = @ErrorFlowGpm,
		[Elevation] = @Elevation,
		[CorrectedErrorResidualPsi] = @CorrectedErrorResidualPsi
	WHERE [Id] = @Id;
END
GO
