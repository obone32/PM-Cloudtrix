

CREATE TABLE [dbo].[StoreSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Logo] [nvarchar](max) NULL,
	[StoreName] [nvarchar](max) NOT NULL,
	[State] [nvarchar](200) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Web] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Currency] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.StoreSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO





----------------------------------------------------------------
--Created By : Jayesh Prajapati
--Drop Procedure Customer_StateVerify
/*
Exec Customer_StateVerify 1
Select * from TimeSheet
*/
CREATE Procedure [dbo].[Customer_StateVerify]
	@pCustomerID Int
	--With Encryption
As
Begin
Begin Try
	Set NoCount On

	Declare @bIsFound Bit  = 0
	Declare @cCustStateName Varchar(200) = ''
	Declare @cCompStateName Varchar(200) = ''

	Select @cCustStateName = State	
	from Customer With (Nolock)
	Where Id = @pCustomerID
	
	Select @cCustStateName = State	
	from StoreSetting With (Nolock)
	Where Id = @pCustomerID
	

	If @cCompStateName = @cCustStateName
	Begin
		Set @bIsFound = 1
	End
	
	Select @bIsFound AS IsStateMatch


End Try
Begin Catch
	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
	
	SET @ErrorMessage = ERROR_MESSAGE();
	SET @ErrorSeverity = ERROR_SEVERITY();
	SET @ErrorState = ERROR_STATE();
	
	Raiserror(@ErrorMessage,@ErrorSeverity,@ErrorState)
End Catch
End


GO

/****** Object:  StoredProcedure [dbo].[TimeSheet_VerifyDetails]    Script Date: 6/6/2019 9:43:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure TimeSheet_VerifyDetails
/*
Exec TimeSheet_VerifyDetails 1,1,'',''
Select * from TimeSheet
*/
CREATE Procedure [dbo].[TimeSheet_VerifyDetails]
	@pEmployeeId Int,
	@pProjectId Int,
	@pStartTime DateTime,
	@pEndTime DateTime
--With Encryption
As
Begin
Begin Try
	Set NoCount On

	Declare @bIsFound Bit  = 0

	Select @bIsFound = Count(*)
	from TimeSheet With (Nolock)
	Where (EmployeeID = @pEmployeeId)
	And  (ProjectId = @pProjectId)
	And ((@pStartTime between StartTime and EndTime) 
				Or (@pEndTime between StartTime and EndTime))
	And IsDelete = 0

	Select @bIsFound AS IsFound


End Try
Begin Catch
	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
	
	SET @ErrorMessage = ERROR_MESSAGE();
	SET @ErrorSeverity = ERROR_SEVERITY();
	SET @ErrorState = ERROR_STATE();
	
	Raiserror(@ErrorMessage,@ErrorSeverity,@ErrorState)
End Catch
End
GO


