-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Creates a new Flow Test entry
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTest_Create]
	-- Add the parameters for the stored procedure here
	@Id INT = 0 OUTPUT,
	@TestName NVARCHAR(200),
	@TestDate DATETIME2,
	@TestCurrent BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	INSERT INTO [dbo].[FlowTest] (
		[TestName],
		[TestDate],
		[TestCurrent]
	) VALUES (
		@TestName,
		@TestDate,
		@TestCurrent
	);

	SELECT @Id = SCOPE_IDENTITY();
END
GO
