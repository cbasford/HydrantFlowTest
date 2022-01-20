-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Retrieves all Flow Test entries
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTest_RetrieveAll]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	SELECT [Id],
		[TestName],
		[TestDate],
		[TestCurrent]
	FROM [dbo].[FlowTest];
END
GO
