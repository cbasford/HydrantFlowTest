﻿-- =============================================
-- Author:		Pierre J.-L. Plourde
-- Create date:	20/01/2022
-- Description:	Retrieves Flow Test entry by Id
-- =============================================
CREATE PROCEDURE [dbo].[spFlowTest_RetrieveById]
	-- Add the parameters for the stored procedure here
	@Id INT
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
	FROM [dbo].[FlowTest]
	WHERE [Id] = @Id;
END
GO