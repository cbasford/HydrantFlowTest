-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Updates a Flow Test entry by Id
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTest_Update]
	-- Add the parameters for the stored procedure here
	@Id INT,
	@TestName NVARCHAR(200),
	@TestDate DATETIME2,
	@TestCurrent BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	UPDATE [dbo].[FlowTest]
	SET [TestName] = @TestName,
		[TestDate] = @TestDate,
		[TestCurrent] = @TestCurrent
	WHERE [Id] = @Id;
END
GO
