

/****** Object:  StoredProcedure [dbo].[StateMaster_ListAll]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure StateMaster_ListAll
/*
Exec StateMaster_ListAll 0,''
Select * from tblStateMaster
*/
CREATE Procedure [dbo].[StateMaster_ListAll]
	@pStateID Int,
	@pStateName Varchar(100)
--With Encryption
As
Begin
Begin Try
	Set NoCount On

	Select StateID,Name as StateName,IsDelete
		,IGST,CGST,SGST,Discount
	from tblStateMaster With (Nolock)
	Where (@pStateID = 0 Or StateID = @pStateID)
	And  (@pStateName = '' Or Name = @pStateName)
	Order by Name ASC

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

/****** Object:  StoredProcedure [dbo].[LoginHistory_Add]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure LoginHistory_Add
/*
Declare @pLoginHistoryID Int
Exec LoginHistory_Add @pLoginHistoryID Out
select @pLoginHistoryID

Select * from tblLoginHistory
*/
CREATE Procedure [dbo].[LoginHistory_Add]
	@pLoginHistoryID Int Out,
	@pEmailID Varchar(100),
	@pPassword Varchar(50),
	@pLoginIP Varchar(20)
As
Begin
Begin Try
	Set NoCount On
	
	Declare @dCurDateTime DateTime = GetDate()

	Select @pLoginHistoryID = IsNull(MAX(LoginHistoryID),0) + 1 From tblLoginHistory With (Nolock)
	
	Insert Into tblLoginHistory
	(
		LoginHistoryID,EmpID,EmailID,Password,IsSuccess,Message,LoginDateTime,LoginIP
	)
	Values
	(
		@pLoginHistoryID,0,@pEmailID,@pPassword,0,'',@dCurDateTime,@pLoginIP
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

/****** Object:  StoredProcedure [dbo].[LoginHistory_Update]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure LoginHistory_Update
/*
Declare @pLoginHistoryID Int
Exec LoginHistory_Update @pLoginHistoryID
select @pLoginHistoryID

Select * from tblLoginHistory
*/
CREATE Procedure [dbo].[LoginHistory_Update]
	@pLoginHistoryID Int,
	@pEmpID Int,
	@pIsSuccess Bit,
	@pMessage Varchar(500)
As
Begin
Begin Try
	Set NoCount On
	
	Update tblLoginHistory With (Rowlock)
	Set IsSuccess = @pIsSuccess
		,EmpID = @pEmpID
		,Message = @pMessage
	Where LoginHistoryID = @pLoginHistoryID
	
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

/****** Object:  StoredProcedure [dbo].[Employee_Verify]    Script Date: 5/19/2019 10:25:47 AM ******/
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

/****** Object:  StoredProcedure [dbo].[CityMaster_ListAll]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure CityMaster_ListAll
/*
Exec CityMaster_ListAll 0,0
Select * from tblCityMaster
*/
CREATE Procedure [dbo].[CityMaster_ListAll]
	@pCityID Int,
	@pStateID Int
--With Encryption
As
Begin
Begin Try
	Set NoCount On

	Select CM.CityID,CM.Name As CityName,CM.StateID,Sm.Name As StateName,SM.IGST,SM.CGST,SM.SGST,SM.Discount,CM.IsDelete
	from tblCityMaster CM With (Nolock)
	Inner Join tblStateMaster SM With (Nolock) On (CM.StateID = SM.StateID)
	Where (@pStateID = 0 Or CM.StateID = @pStateID)
	And (@pCityID = 0 Or CM.CityID = @pCityID)
	Order by CM.Name ASC

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

/****** Object:  StoredProcedure [dbo].[RoleMaster_Add]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure RoleMaster_Add
/*
Declare @pRoleID Int
Exec RoleMaster_Add @pRoleID Out,'Credit Administrator Approver','Credit Administrator Maker'
select @pRoleID
*/
CREATE Procedure [dbo].[RoleMaster_Add]
	@pRoleID Int Out,
	@pRoleName Varchar(100),
	@pRoleDesc Varchar(200)
As
Begin
Begin Try
	Set NoCount On
	

	Declare @dCurDateTime DateTime = GetDate()

	Select @pRoleId = IsNull(MAX(RoleID),0) + 1 From tblRoleMaster With (Nolock)
	
	Insert Into tblRoleMaster
	(
		RoleID,RoleName,RoleDesc,CreateDate,UpdateDate,IsDelete
	)
	Values
	(
		@pRoleId,@pRoleName, @pRoleDesc,@dCurDateTime,@dCurDateTime, 0
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

/****** Object:  StoredProcedure [dbo].[RoleMaster_Update]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure RoleMaster_Update
/*
Declare @pRoleID Int
Exec RoleMaster_Update @pRoleID,'Credit Administrator Approver','Credit Administrator Maker',0
select @pRoleID
*/
CREATE Procedure [dbo].[RoleMaster_Update]
	@pRoleID Int,
	@pRoleName Varchar(100),
	@pRoleDesc Varchar(200),
	@pIsDelete Bit
As
Begin
Begin Try
	Set NoCount On
	

	Declare @dCurDateTime DateTime = GetDate()

	Update tblRoleMaster 
	Set RoleName = @pRoleName
		,RoleDesc = @pRoleDesc
		,UpdateDate = @dCurDateTime
		,IsDelete = @pIsDelete
	Where RoleID = @pRoleID
	
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

/****** Object:  StoredProcedure [dbo].[RoleMaster_ListAll]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure RoleMaster_ListAll
/*
Exec RoleMaster_ListAll 0
Select * from mRoleMaster
*/
CREATE Procedure [dbo].[RoleMaster_ListAll]
	@pRoleID Int
--With Encryption
As
Begin
Begin Try
	Set NoCount On

	Select RoleID,RoleName,RoleDesc,CreateDate,UpdateDate,IsDelete
	from tblRoleMaster With (Nolock)
	Where (@pRoleID = 0 Or RoleID = @pRoleID)
	Order by RoleID Desc

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

/****** Object:  StoredProcedure [dbo].[MenuRights_Add]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure MenuRights_Add
/*
Declare @pMenuRightsID Int
Exec MenuRights_Add @pMenuRightsID Out,1,1,1,1,1,1
Select @pMenuRightsID

Select * from mMenuRights
*/
Create Procedure [dbo].[MenuRights_Add]
	@pMenuRightsID Int Out,
	@pMenuID Int,
	@pRoleID Int,
	@pIsAdd Bit,
	@pIsUpdate Bit,
	@pIsDelete Bit,
	@pIsView Bit
--With Encryption
As
Begin
Begin Try
	Set NoCount On
	
	Declare @dCurDateTime DateTime = GetDate()
	
	Select @pMenuRightsID = IsNull(MAX(MenuRightsID),0) + 1 From tblMenuRights With (Nolock)
	
	Insert Into tblMenuRights
	(
		MenuRightsID,MenuID,RoleID,IsAdd,IsUpdate,IsDelete,IsView,CreateDate,UpdateDate
	)
	Values
	(
		@pMenuRightsID,@pMenuID,@pRoleID,@pIsAdd, @pIsUpdate, @pIsDelete, @pIsView ,@dCurDateTime,@dCurDateTime
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

/****** Object:  StoredProcedure [dbo].[MenuRights_Update]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure MenuRights_Update
/*
Declare @pMenuRightsID Int
Exec MenuRights_Add @pMenuRightsID,1,1,1,1,1,1
Select @pMenuRightsID

Select * from mMenuRights
*/
Create Procedure [dbo].[MenuRights_Update]
	@pMenuRightsID Int,
	@pMenuID Int,
	@pRoleID Int,
	@pIsAdd Bit,
	@pIsUpdate Bit,
	@pIsDelete Bit,
	@pIsView Bit
--With Encryption
As
Begin
Begin Try
	Set NoCount On
	
	Declare @dCurDateTime DateTime = GetDate()
	
	Update tblMenuRights
	Set MenuID = @pMenuID
		,RoleID = @pRoleID
		,IsAdd = @pIsAdd
		,IsUpdate = @pIsUpdate
		,IsDelete = @pIsDelete
		,IsView = @pIsView
		,UpdateDate = @dCurDateTime
	Where MenuRightsID = @pMenuRightsID
	
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

/****** Object:  StoredProcedure [dbo].[MenuRoleRights_ListAll]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure MenuRoleRights_ListAll  
/*  
Exec MenuRoleRights_ListAll '1',0,0
Select * from mMenuRights  
Select * from mMenuRightsProcessHistory  
*/  
Create Procedure [dbo].[MenuRoleRights_ListAll]
	@pRoleIDs Varchar(100), --Default ''
	@pMenuID Int,--Default 0
	@pParentMenuID Int
--With Encryption
As  
Begin  
Begin Try  
	Set NoCount On  
  
	Select  distinct MM.MenuID
		,MM.ParentMenuID
		,MM.OrderNo
		,IsNull(MM.MenuName,'') AS MenuName
		,IsNull(MAK.IsAdd,0) AS IsAdd
		,IsNull(CHK.IsUpdate,0) AS IsUpdate
		,IsNull(APP.IsDelete,0) AS IsDelete
		,IsNull(VIE.IsView,0) AS IsView
	From tblMenuMaster MM
	Left Outer  Join (
		Select distinct MR.MenuID,MM.ParentMenuID  
		,MM.MenuName,MR.IsAdd
		from tblMenuRights MR With (Nolock)  
		Inner Join tblMenuMaster MM With (Nolock) On (MM.MenuID = MR.MenuID)  
		Inner Join tblRoleMaster RM With (Nolock) On (RM.RoleID = MR.RoleID)
		Where (@pRoleIDs = '' Or (MR.RoleID In (Select Item from dbo.SplitStringFun(@pRoleIDs,','))))  
		And (@pMenuID = 0 or MM.MenuID = @pMenuID)
		And (@pParentMenuID = 0 or MM.ParentMenuID = @pParentMenuID)
		And MR.IsAdd = 1
	) MAK On MAK.MenuID = MM.MenuID
	Left Outer Join (
		Select distinct MR.MenuID,MM.ParentMenuID  
		,MM.MenuName,MR.IsUpdate
		from tblMenuRights MR With (Nolock)  
		Inner Join tblMenuMaster MM With (Nolock) On (MM.MenuID = MR.MenuID)  
		Inner Join tblRoleMaster RM With (Nolock) On (RM.RoleID = MR.RoleID)
		Where (@pRoleIDs = '' Or (MR.RoleID In (Select Item from dbo.SplitStringFun(@pRoleIDs,','))))  
		And (@pMenuID = 0 or MM.MenuID = @pMenuID)
		And (@pParentMenuID = 0 or MM.ParentMenuID = @pParentMenuID)
		And MR.IsUpdate = 1
	) CHK On CHK.MenuID = MM.MenuID
	Left Outer   Join (
		Select distinct MR.MenuID,MM.ParentMenuID  
		,MM.MenuName,MR.IsDelete
		from tblMenuRights MR With (Nolock)  
		Inner Join tblMenuMaster MM With (Nolock) On (MM.MenuID = MR.MenuID)  
		Inner Join tblRoleMaster RM With (Nolock) On (RM.RoleID = MR.RoleID)
		Where (@pRoleIDs = '' Or (MR.RoleID In (Select Item from dbo.SplitStringFun(@pRoleIDs,','))))  
		And (@pMenuID = 0 or MM.MenuID = @pMenuID)
		And (@pParentMenuID = 0 or MM.ParentMenuID = @pParentMenuID)
		And MR.IsDelete = 1
	)APP On APP.MenuID = MM.MenuID
	Left Outer   Join (
		Select distinct MR.MenuID,MM.ParentMenuID  
		,MM.MenuName,MR.IsView  
		from tblMenuRights MR With (Nolock)  
		Inner Join tblMenuMaster MM With (Nolock) On (MM.MenuID = MR.MenuID)  
		Inner Join tblRoleMaster RM With (Nolock) On (RM.RoleID = MR.RoleID)
		Where (@pRoleIDs = '' Or (MR.RoleID In (Select Item from dbo.SplitStringFun(@pRoleIDs,','))))  
		And (@pMenuID = 0 or MM.MenuID = @pMenuID)
		And (@pParentMenuID = 0 or MM.ParentMenuID = @pParentMenuID)
		And MR.IsView = 1
	)VIE On VIE.MenuID = MM.MenuID
	Where (MAK.IsAdd <> 0 Or CHK.IsUpdate <> 0 Or APP.IsDelete <> 0 Or VIE.IsView <> 0) 
	Order by MM.OrderNo
	

   
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

/****** Object:  StoredProcedure [dbo].[MenuRights_ListAll]    Script Date: 5/19/2019 10:25:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure MenuRights_ListAll
/*
Exec MenuRights_ListAll 0,0,1
*/
CREATE Procedure [dbo].[MenuRights_ListAll]
	@pMenuRightsID Int, --Default 0
	@pMenuID Int, --Default 0
	@pRoleID Int
As
Begin
Begin Try
	Set NoCount On
    
	IF @pRoleID <> 0
	Begin
		Select MR.MenuRightsID,MR.MenuID,MR.RoleID
			,MM.ParentMenuID
			,MM.MenuName,RM.RoleName,RM.RoleDesc
			,MR.IsAdd,MR.IsUpdate,MR.IsDelete
			,MR.IsView
			,CASE WHEN IsNull((Select Count(*) from tblMenuMaster MM1 With (Nolock) Where MM1.ParentMenuID = MM.MenuID
						And MM.ParentMenuID = -1),0) = 0 
				THEN CAST(0 As Bit) ELSE CAST(1 As Bit) END  AS IsChild
		From tblMenuRights MR With (Nolock)
		Inner Join tblMenuMaster MM With (Nolock) On (MM.MenuID = MR.MenuID)
		Inner Join tblRoleMaster RM With (Nolock) On (RM.RoleID = MR.RoleID)
		Where (@pMenuRightsID = 0 or MR.MenuRightsID = @pMenuRightsID)
		And (@pMenuID = 0 Or MR.MenuID = @pMenuID)
		And (@pRoleID = 0 Or MR.RoleID = @pRoleID)
		Order by MM.OrderNo Asc
	End
	Else
	Begin
		Select CAST(0  AS Int) AS MenuRightsID
			,MM.MenuID
			,CAST(0  AS Int) AS RoleID
			,MM.ParentMenuID
			,MM.MenuName
			,'' AS RoleName,'' AS RoleDesc
			,CAST(0  AS Bit) AS IsAdd
			,CAST(0  AS Bit) AS IsUpdate
			,CAST(0  AS Bit) AS IsDelete
			,CAST(0  AS Bit) AS IsView
		from tblMenuMaster MM With (Nolock)
		Where (@pMenuID = 0 Or MM.MenuID = @pMenuID)
		Order by MM.OrderNo Asc
	End

	
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



/****** Object:  UserDefinedFunction [dbo].[SplitStringFun]    Script Date: 5/19/2019 10:25:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Created By : Jayesh Prajapati ()
-- Drop Function dbo.SplitStringFun
/*
Declare @cField Varchar(50) 
Declare @Sep Char
Set @cField = 'A,B,C,D,E'
Set @Sep = ','
Select * from dbo.SplitStringFun(@cField,@Sep)
*/
Create Function [dbo].[SplitStringFun]
(
	@List VarChar(Max),
	@Delim Char
)
Returns @ParsedList Table (Item Varchar(max), ID Int)
As
Begin
	Declare @Item Varchar(Max), @Pos Int, @ID Int
	Set @ID = 1
	Set @List = LTRIM(RTRIM(@List)) + @Delim
	Set @Pos = CHARINDEX(@Delim,@List, 1)
	While @Pos > 0
	Begin
		Set @Item = LTRIM(RTRIM(LEFT(@list,@Pos - 1)))
		If @Item <> ''
		Begin
			Insert Into @ParsedList (Item, Id)
			Values(CAST(@Item as Varchar(Max)), @ID)
		End
		Set @List = Right(@List, Len(@List) - @Pos)
		Set @Pos = CharIndex(@Delim,@list,1)
		Set @ID = @ID + 1
	End
	Return
End


GO





