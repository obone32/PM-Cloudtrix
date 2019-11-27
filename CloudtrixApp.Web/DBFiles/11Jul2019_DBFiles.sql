
GO

/****** Object:  Table [dbo].[Project]    Script Date: 7/11/2019 5:22:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](max) NOT NULL,
	[BillingName] [nvarchar](max) NULL,
	[ArchitectId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[EmployeeIDs] [varchar](100) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Associate]    Script Date: 7/11/2019 5:22:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Associate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArchitectId] [int] NULL,
	[Name] [varchar](200) NULL,
	[Mobile] [varchar](20) NULL,
	[Email] [varchar](200) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[IsDelete] [bit] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Architect]    Script Date: 7/11/2019 5:22:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Architect](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArchitectName] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Architect] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Project_dbo.Architect_ArchitectId] FOREIGN KEY([ArchitectId])
REFERENCES [dbo].[Architect] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_dbo.Project_dbo.Architect_ArchitectId]
GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Project_dbo.Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_dbo.Project_dbo.Customer_CustomerId]
GO








---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
/****** Object:  StoredProcedure [dbo].[Associate_Add]    Script Date: 7/11/2019 5:21:48 PM ******/
DROP PROCEDURE [dbo].[Associate_Add]
GO

/****** Object:  StoredProcedure [dbo].[Associate_Update]    Script Date: 7/11/2019 5:21:48 PM ******/
DROP PROCEDURE [dbo].[Associate_Update]
GO

/****** Object:  StoredProcedure [dbo].[Associate_Delete]    Script Date: 7/11/2019 5:21:48 PM ******/
DROP PROCEDURE [dbo].[Associate_Delete]
GO

/****** Object:  StoredProcedure [dbo].[Associate_ListAll]    Script Date: 7/11/2019 5:21:48 PM ******/
DROP PROCEDURE [dbo].[Associate_ListAll]
GO

/****** Object:  StoredProcedure [dbo].[Project_ListallEmployee]    Script Date: 7/11/2019 5:21:48 PM ******/
DROP PROCEDURE [dbo].[Project_ListallEmployee]
GO

/****** Object:  StoredProcedure [dbo].[Employee_Verify]    Script Date: 7/11/2019 5:21:48 PM ******/
DROP PROCEDURE [dbo].[Employee_Verify]
GO

/****** Object:  StoredProcedure [dbo].[Employee_Verify]    Script Date: 7/11/2019 5:21:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati 
--Drop Procedure Employee_Verify
/* 
Exec Employee_Verify 'sunil@cloudtrix.in','12345'
Select * from Employee
*/    
Create Procedure [dbo].[Employee_Verify]
	@pEmployeeEmail Varchar(100),
	@pPassword Varchar(50)
--With Encryption
As    
Begin    
Begin Try    
	Set NoCount On    

	
	Declare @dCurDateTime DateTime= GETDATE()
	Declare @dLastLoginTime DateTime = ''
	Declare @iId Int = 0
	Declare @cPassword Varchar(50) = ''
	Declare @iRoleID Int = 0

	Select @iId = EM.Id
		,@cPassword = EM.[Password]
		,@iRoleID = EM.RoleID
	from Employee EM With(Nolock)
	Where EM.EmployeeEmail = @pEmployeeEmail
	And EM.IsActive = 1

	IF @iId = 0
	Begin
		Raiserror('Invalid login credentials',16,1); 
	End

	If @pPassword <> @cPassword collate sql_latin1_general_cp1_cs_as
	Begin
		Raiserror('Invalid login credentials',16,1);
	End
	
	Select Id As EmpID,EmployeeName,EmployeeEmail,EmployeePhone,EmployeeGender
		,EmployeeDOB,EmployeeDOJ,EmployeeAddress,EmployeeSalary,Description
		,CreateDate,UpdateDate,IsActive,RoleID,Password,IsDelete
		,CASE When @iRoleID = 1 Then cast(1 as int) else cast(0 as int) end As IsAdmin
	From Employee With (NoLock)
	Where Id = @iId    
     
	--Select MM.MenuName
	--	,MM.MenuID, MM.ParentMenuID 
	--	,MR.IsView
	--	,ISNULL(MM.PageURL,'') AS PageURL
	--from tblMenuRights MR With (Nolock)
	--Inner Join tblMenuMaster MM With (Nolock) On (MR.MenuID = MM.MenuID)
	--where MR.RoleID = @iRoleID
	--Order by MM.MenuID
	


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

/****** Object:  StoredProcedure [dbo].[Project_ListallEmployee]    Script Date: 7/11/2019 5:21:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure Project_ListallEmployee
/*
Exec Project_ListallEmployee 2
Select * from Project
Select * from EMployee
*/
CREATE Procedure [dbo].[Project_ListallEmployee]
	@pId Int
--With Encryption
As
Begin
Begin Try
	Set NoCount On

	Select Id,ProjectName
	,IsNull((Select Stuff((SELECT ',' + EM1.EmployeeName
			FROM  Employee EM1 With (Nolock)
			Where EM1.ID In (Select Item from dbo.SplitStringFun(PR.EmployeeIDs,','))	
			FOR xml path ('')), 1, 1, '')),'') AS EmployeeNames
	From Project PR With (Nolock) 
	Where PR.Id = @pId
	
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

/****** Object:  StoredProcedure [dbo].[Associate_ListAll]    Script Date: 7/11/2019 5:21:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure Associate_ListAll
/*
Exec Associate_ListAll 0
Select * from Associate
*/
CREATE Procedure [dbo].[Associate_ListAll]
	@pArchitectId Int
--With Encryption
As
Begin
Begin Try
	Set NoCount On

	Select CM.Id,CM.ArchitectId,CM.Name,CM.Mobile,CM.Email
		,CM.CreateDate,CM.UpdateDate,CM.IsDelete
	from Associate CM With (Nolock)
	Where (CM.ArchitectId = @pArchitectId)
	Order by CM.Id ASC

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

/****** Object:  StoredProcedure [dbo].[Associate_Delete]    Script Date: 7/11/2019 5:21:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure Associate_Delete
/*
Exec Associate_Delete
*/
CREATE Procedure [dbo].[Associate_Delete]
	@pID Int
As
Begin
Begin Try
	Set NoCount On
	

	Declare @dCurDateTime DateTime = GetDate()

	Update Associate
	Set IsDelete = 1
		,UpdateDate = @dCurDateTime
	Where Id = @pID
	
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

/****** Object:  StoredProcedure [dbo].[Associate_Update]    Script Date: 7/11/2019 5:21:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure Associate_Update
/*
Exec Associate_Update
*/
CREATE Procedure [dbo].[Associate_Update]
	@pID Int,
	@pName Varchar(200),
	@pMobile Varchar(20),
	@pEmail Varchar(200)
As
Begin
Begin Try
	Set NoCount On
	

	Declare @dCurDateTime DateTime = GetDate()

	Update Associate
	Set Name = @pName
		,Mobile = @pMobile
		,Email = @pEmail
		,UpdateDate = @dCurDateTime
	Where Id = @pID
	
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

/****** Object:  StoredProcedure [dbo].[Associate_Add]    Script Date: 7/11/2019 5:21:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure Associate_Add
/*
Exec Associate_Add
*/
CREATE Procedure [dbo].[Associate_Add]
	@pID Int Out,
	@pArchitectId Int,
	@pName Varchar(200),
	@pMobile Varchar(20),
	@pEmail Varchar(200)
As
Begin
Begin Try
	Set NoCount On
	

	Declare @dCurDateTime DateTime = GetDate()

	Select @pID = IsNull(MAX(ID),0) + 1 From Associate With (Nolock)
	
	Insert Into Associate
	(
		Id,ArchitectId,Name,Mobile,Email,CreateDate,UpdateDate,IsDelete
	)
	Values
	(
		@pId,@pArchitectId,@pName,@pMobile,@pEmail,@dCurDateTime,@dCurDateTime, 0
	)
	
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


