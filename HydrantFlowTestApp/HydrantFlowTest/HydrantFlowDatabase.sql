USE [Engineering]
GO

/****** Object:  Table [task].[FlowTest]    Script Date: 1/20/2022 3:09:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [task].[FlowTest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FlowValveStatusID] [int] NULL,
	[ModelVersionID] [int] NULL,
	[Status] [bit] NULL,
	[TestName] [nvarchar](35) NULL,
	[TestDate] [datetime] NULL,
	[PlanFlowDate] [datetime] NULL,
	[Summary] [nvarchar](50) NULL,
	[Workorder] [int] NULL,
	[TestBy] [nvarchar](25) NULL,
	[DisplayMap] [nvarchar](255) NULL,
	[SiteMap] [nvarchar](255) NULL,
	[SimlMap] [nvarchar](255) NULL,
	[TotalFlowGpm] [float] NULL,
	[TestDataFile] [nvarchar](255) NULL,
	[MaxErrorStaticPsi] [float] NULL,
	[AvgErrorStaticPsi] [float] NULL,
	[MaxErrorResidualPsi] [float] NULL,
	[AvgErrorResidualPsi] [float] NULL,
	[FlowErrorGpm] [float] NULL,
	[VarErrorStaticPsi] [float] NULL,
	[VarErrorresidualPsi] [float] NULL,
	[ModelRevisionDate] [nvarchar](50) NULL,
	[Calculate] [nvarchar](1) NULL,
	[MapScale] [int] NOT NULL,
	[CalcFlowAt20] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [task].[FlowTest] ADD  DEFAULT ((5000)) FOR [MapScale]
GO

ALTER TABLE [task].[FlowTest] ADD  DEFAULT ((0)) FOR [CalcFlowAt20]
GO

ALTER TABLE [task].[FlowTest]  WITH CHECK ADD FOREIGN KEY([FlowValveStatusID])
REFERENCES [task].[FlowTestValveStatus] ([HydFlowValveStatusID])
GO

ALTER TABLE [task].[FlowTest]  WITH CHECK ADD FOREIGN KEY([ModelVersionID])
REFERENCES [task].[ModelVersion] ([ModelVersionID])
GO


--------

USE [Engineering]
GO

/****** Object:  Table [task].[FlowTestData]    Script Date: 1/20/2022 3:09:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [task].[FlowTestData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FlowTestID] [int] NULL,
	[AssetRoleID] [int] NULL,
	[AssetTypeID] [int] NOT NULL,
	[AssetNumber] [int] NULL,
	[HydrantNozzleID] [int] NULL,
	[StaticPsi] [float] NULL,
	[ResidualPsi] [float] NULL,
	[FlowGpm] [float] NULL,
	[ModelStaticPsi] [float] NULL,
	[ModelResidualPsi] [float] NULL,
	[ModelFlowGpm] [float] NULL,
	[Elevation] [float] NULL,
	[ErrorStaticPsi] [float] NULL,
	[ErrorResidualPsi] [float] NULL,
	[ErrorFlowGpm] [float] NULL,
	[CorrectedErrorResidualPsi] [float] NULL,
 CONSTRAINT [PK__HydFlowT__1E24E3E355E7E54B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [task].[FlowTestData]  WITH CHECK ADD  CONSTRAINT [FK__HydFlowTe__Asset__1C330188] FOREIGN KEY([AssetTypeID])
REFERENCES [task].[CvtAssetType] ([ID])
GO

ALTER TABLE [task].[FlowTestData] CHECK CONSTRAINT [FK__HydFlowTe__Asset__1C330188]
GO

ALTER TABLE [task].[FlowTestData]  WITH CHECK ADD  CONSTRAINT [FK__HydFlowTe__HydFl__1A4AB916] FOREIGN KEY([FlowTestID])
REFERENCES [task].[FlowTest] ([ID])
GO

ALTER TABLE [task].[FlowTestData] CHECK CONSTRAINT [FK__HydFlowTe__HydFl__1A4AB916]
GO

ALTER TABLE [task].[FlowTestData]  WITH CHECK ADD  CONSTRAINT [FK__HydFlowTe__Hydra__1D2725C1] FOREIGN KEY([HydrantNozzleID])
REFERENCES [task].[CvtHydrantNozzle] ([ID])
GO

ALTER TABLE [task].[FlowTestData] CHECK CONSTRAINT [FK__HydFlowTe__Hydra__1D2725C1]
GO



--------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spRequest_AddNew]    Script Date: 1/20/2022 3:10:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [task].[spRequest_AddNew]
	@Title nvarchar(50)
	,@RequestDate DateTime
	,@CustomerId int
	,@RequestType nvarchar(25)
	,@CustomerNotes nvarchar(255)
	
	,@ID int = 0 output
as
begin
set nocount on

INSERT INTO task.Request ( Title, RequestDate,  RequestType, CustomerID, CustomerNotes, IsClosed)
Values (
		 @Title
		, GETDATE()
		, @RequestType
		, @CustomerId
		, @CustomerNotes
		, 0 );


UPDATE Task.Request
SET RequestTypeId = b.ID
FROM Task.Request a
INNER JOIN Task.CvtRequestType b ON a.RequestType = b.RequestType;


select @id = SCOPE_IDENTITY();


end


GO

----------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spRequest_GetAll]    Script Date: 1/20/2022 3:11:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [task].[spRequest_GetAll]
 @IsClosed bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


SELECT a.*, RTRIM(b.RequestType) AS RequestType
FROM task.Request a
inner join task.CvtRequestType b ON a.RequestTypeId = b.ID
where IsClosed = @IsClosed ;


END

GO

-------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spRequest_Update]    Script Date: 1/20/2022 3:11:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [task].[spRequest_Update]
	@ID int
	,@Title nvarchar(50)
	,@CustomerID int
	,@IsClosed int
	,@FlowTestID int
	,@WwNotes nvarchar(255)
	,@CloseDate DateTime

as
begin
set nocount on

update task.Request 
SET
Title = @Title
, CustomerID = @CustomerID
, FlowTestID = @FlowTestID
, IsClosed = @IsClosed
, WwNotes = @WwNotes
, CloseDate = @CloseDate  --GETDATE()
where ID = @ID
end
GO

-----------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spFlowTest_AddNew]    Script Date: 1/20/2022 3:12:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [task].[spFlowTest_AddNew]
@Title nvarchar(35)
,@RequestID int
,@ID int = 0 output
as
begin
set nocount on
insert into task.FlowTest (TestName)
values ( @Title )
select @id = SCOPE_IDENTITY();

UPDATE task.Request
SET FlowTestID = @Id
WHERE ID = @RequestID;




end

GO

------------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spFlowTest_GetAll]    Script Date: 1/20/2022 3:12:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [task].[spFlowTest_GetAll]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT *
FROM task.FlowTest;

END
GO

---------------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spFlowTest_GetData]    Script Date: 1/20/2022 3:12:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [task].[spFlowTest_GetData]
@FlowTestID int
as
begin
set nocount on
select 
	a.[ID]
      ,d.[AssetRole] 
	  , b.AssetType AS Asset
      ,a.[AssetNumber] AS AssetId
      ,c.Nozzles
      ,[StaticPsi]
      ,[ResidualPsi] AS TestPsi
      ,[FlowGpm]
      ,[ModelStaticPsi]
      ,[ModelResidualPsi] AS ModelTestPsi
      ,[ModelFlowGpm] AS ModelFlow
      ,[Elevation]
      ,[ErrorStaticPsi]
      ,[ErrorResidualPsi]
      ,[ErrorFlowGpm]
      ,[CorrectedErrorResidualPsi]
	  , c.DischargeCoeff
	  , c.Multiplier
from task.FlowTestData a
inner join task.CvtAssetType b on a.AssetTypeID = b.ID
inner join task.CvtHydrantNozzle c on a.HydrantNozzleID = c.id
inner join task.cvtAssetRole d on a.AssetRoleID = d.ID
where FlowTestID = @FlowTestID;
end
GO

------------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spCustomer_AddNew]    Script Date: 1/20/2022 3:13:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [task].[spCustomer_AddNew]
@FirstName nvarchar(35)
,@LastName nvarchar(35)
,@Company nvarchar(35)
,@Address1 nvarchar(35)
,@Address2 nvarchar(20)
,@City nvarchar(25)
,@State nvarchar(2)
,@Zip nvarchar(5)
,@Phone nvarchar(10)
,@Email nvarchar(55)
--,@IsActive bit
,@CreatedDate date
,@ID int = 0 output
as
begin
set nocount on
insert into task.Customer (FirstName, LastName, Company, Address1, Address2, City, State, Zip, Phone, Email, IsActive, CreatedDate)
values ( 
@FirstName 
,@LastName
,@Company 
,@Address1
,@Address2 
,@City 
,@State 
,@Zip 
,@Phone
,@Email 
,1
,cast(getdate() as date));

select @id = SCOPE_IDENTITY();
end
GO

----------------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spCustomer_GetAll]    Script Date: 1/20/2022 3:13:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [task].[spCustomer_GetAll]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT *
FROM task.Customer
WHERE IsActive = 1;
END
GO

---------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spFlowPoint_AddNew]    Script Date: 1/20/2022 3:14:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [task].[spFlowPoint_AddNew]
  @FlowTestID int
, @AssetRoleID int
, @AssetTypeID int
, @AssetNumber int
, @HydrantNozzleID int
, @StaticPsi float
, @ResidualPsi float

as
begin
set nocount on

insert into task.FlowTestData (FlowTestID, AssetRoleID, AssetTypeID, AssetNumber, HydrantNozzleID, StaticPsi, ResidualPsi)
values  ( 
	  @FlowTestID 
	, @AssetRoleID 
	, @AssetTypeID 
	, @AssetNumber 
	, @HydrantNozzleID 
	, @StaticPsi 
	, @ResidualPsi 
);
end
GO

----------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spFlowPoint_Delete]    Script Date: 1/20/2022 3:14:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [task].[spFlowPoint_Delete]
  @ID int


as
begin
set nocount on

delete from  task.FlowTestData 
where ID = @ID;
end
GO

--------
USE [Engineering]
GO

/****** Object:  StoredProcedure [task].[spFlowPoint_Update]    Script Date: 1/20/2022 3:14:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [task].[spFlowPoint_Update]
  @ID int
, @AssetRoleID int
, @AssetTypeID int
, @AssetNumber int
, @HydrantNozzleID int
, @StaticPsi float
, @ResidualPsi float

as
begin
set nocount on
update  task.FlowTestData
set 
	AssetRoleID = @AssetRoleID 
	, AssetTypeID = @AssetTypeID 
	, AssetNumber =  @AssetNumber 
	, HydrantNozzleID = @HydrantNozzleID 
	, StaticPsi = @StaticPsi 
	, ResidualPsi =  @ResidualPsi 
WHERE ID = @ID
;
end
GO










