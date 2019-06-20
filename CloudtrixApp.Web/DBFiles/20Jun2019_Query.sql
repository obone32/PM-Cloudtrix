CREATE TABLE [dbo].[TimeSheet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[TotTime] [varchar](50) NULL,
	[WorkDetails] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.TimeSheet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



--------------------------------------------------------------------------------------------------------
GO

/****** Object:  StoredProcedure [dbo].[TimeSheet_Listall]    Script Date: 6/20/2019 11:42:33 AM ******/
DROP PROCEDURE [dbo].[TimeSheet_Listall]
GO

/****** Object:  StoredProcedure [dbo].[Project_Listall]    Script Date: 6/20/2019 11:42:33 AM ******/
DROP PROCEDURE [dbo].[Project_Listall]
GO

/****** Object:  StoredProcedure [dbo].[TimeSheet_Report]    Script Date: 6/20/2019 11:42:33 AM ******/
DROP PROCEDURE [dbo].[TimeSheet_Report]
GO

/****** Object:  StoredProcedure [dbo].[TimeSheet_Report]    Script Date: 6/20/2019 11:42:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure TimeSheet_Report
/*
Exec TimeSheet_Report 1
Select * from TimeSheet
*/
CREATE Procedure [dbo].[TimeSheet_Report]
	@pProjectId Int
--With Encryption
As
Begin
Begin Try
	Set NoCount On


	select A.EmployeeName,A.TotalHour 
		,(B.EmployeeSalary / 200) as HourlyRate
		, ((B.EmployeeSalary / 200) * A.TotalHour) As TotalCost 
	from 
	(
		Select EM.EmployeeName,em.Id
		,Sum(CAST(TotTime as decimal(5,2))) as TotalHour
		from TimeSheet TS With (Nolock)
		inner join Project PS With (nolock) On (PS.Id = TS.ProjectId)
		inner join Employee EM With (nolock) On (EM.Id = TS.EmployeeId)
		Where  (ProjectId = @pProjectId)
		Group by em.Id,EM.EmployeeName
	)a,
	(select Id, EmployeeSalary from Employee EM With (nolock)
	)b
	where A.ID = B.Id


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

/****** Object:  StoredProcedure [dbo].[Project_Listall]    Script Date: 6/20/2019 11:42:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure Project_Listall
/*
Exec Project_Listall
Select * from TimeSheet
*/
CREATE Procedure [dbo].[Project_Listall]
--With Encryption
As
Begin
Begin Try
	Set NoCount On

	Select Id,ProjectName
	from Project pr With (Nolock) 
	
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

/****** Object:  StoredProcedure [dbo].[TimeSheet_Listall]    Script Date: 6/20/2019 11:42:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Created By : Jayesh Prajapati
--Drop Procedure TimeSheet_Listall
/*
Exec TimeSheet_Listall
Select * from TimeSheet
*/
CREATE Procedure [dbo].[TimeSheet_Listall]
--With Encryption
As
Begin
Begin Try
	Set NoCount On

	Select TS.Id,TS.EmployeeId,em.EmployeeName, TS.ProjectId,pr.ProjectName,TS.EntryDate
		,TS.StartTime,TS.EndTime,TS.TotTime,TS.WorkDetails,TS.CreateDate,TS.UpdateDate,TS.IsDelete
	from TimeSheet TS With (Nolock)
	inner join Employee em With (Nolock) on (em.Id = TS.EmployeeId)
	inner join Project pr With (Nolock) on (pr.Id = TS.ProjectId)
	
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


