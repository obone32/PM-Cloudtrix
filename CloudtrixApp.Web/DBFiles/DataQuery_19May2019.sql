
GO
Update Employee
Set EmployeeEmail =  'sunil@cloudtrix.in'
,IsActive = 1
,RoleID = 1
,Password = '12345'
Where  Id = 1 

GO
INSERT [dbo].[tblCityMaster] ([CityID], [Name], [StateID], [IsDelete]) VALUES (1, N'Ahmedabad', 24, 0)
GO
INSERT [dbo].[tblCityMaster] ([CityID], [Name], [StateID], [IsDelete]) VALUES (2, N'Mumbai', 27, 0)
GO
INSERT [dbo].[tblCityMaster] ([CityID], [Name], [StateID], [IsDelete]) VALUES (3, N'Delhi', 7, 0)
GO
INSERT [dbo].[tblCityMaster] ([CityID], [Name], [StateID], [IsDelete]) VALUES (4, N'Chennai', 33, 0)
GO
INSERT [dbo].[tblCityMaster] ([CityID], [Name], [StateID], [IsDelete]) VALUES (5, N'Bhopal', 23, 0)
GO
INSERT [dbo].[tblMenuMaster] ([MenuID], [ParentMenuID], [MenuName], [MenuDesc], [OrderNo], [PageURL], [CreateDate], [UpdateDate]) VALUES (1, 0, N'Dashboard', N'Dashboard', 1, NULL, CAST(N'2019-05-13 12:02:49.807' AS DateTime), CAST(N'2019-05-13 12:02:49.807' AS DateTime))
GO
INSERT [dbo].[tblMenuMaster] ([MenuID], [ParentMenuID], [MenuName], [MenuDesc], [OrderNo], [PageURL], [CreateDate], [UpdateDate]) VALUES (2, 0, N'Customer', N'Customer', 1, NULL, CAST(N'2019-05-13 12:02:49.810' AS DateTime), CAST(N'2019-05-13 12:02:49.810' AS DateTime))
GO
INSERT [dbo].[tblMenuMaster] ([MenuID], [ParentMenuID], [MenuName], [MenuDesc], [OrderNo], [PageURL], [CreateDate], [UpdateDate]) VALUES (3, 0, N'Project', N'Project', 1, NULL, CAST(N'2019-05-13 12:02:49.810' AS DateTime), CAST(N'2019-05-13 12:02:49.810' AS DateTime))
GO
INSERT [dbo].[tblMenuMaster] ([MenuID], [ParentMenuID], [MenuName], [MenuDesc], [OrderNo], [PageURL], [CreateDate], [UpdateDate]) VALUES (4, 0, N'Architect', N'Architect', 1, NULL, CAST(N'2019-05-13 12:02:49.810' AS DateTime), CAST(N'2019-05-13 12:02:49.810' AS DateTime))
GO
INSERT [dbo].[tblMenuMaster] ([MenuID], [ParentMenuID], [MenuName], [MenuDesc], [OrderNo], [PageURL], [CreateDate], [UpdateDate]) VALUES (5, 0, N'Employee', N'Employee', 1, NULL, CAST(N'2019-05-13 12:02:49.810' AS DateTime), CAST(N'2019-05-13 12:02:49.810' AS DateTime))
GO
INSERT [dbo].[tblMenuMaster] ([MenuID], [ParentMenuID], [MenuName], [MenuDesc], [OrderNo], [PageURL], [CreateDate], [UpdateDate]) VALUES (6, 0, N'Invoice', N'Invoice', 1, N'', CAST(N'2019-05-16 10:37:39.630' AS DateTime), CAST(N'2019-05-16 10:37:39.630' AS DateTime))
GO
INSERT [dbo].[tblMenuMaster] ([MenuID], [ParentMenuID], [MenuName], [MenuDesc], [OrderNo], [PageURL], [CreateDate], [UpdateDate]) VALUES (7, 0, N'Time sheet', N'Timesheet', 1, NULL, CAST(N'2019-05-13 12:02:49.810' AS DateTime), CAST(N'2019-05-13 12:02:49.810' AS DateTime))
GO
INSERT [dbo].[tblMenuMaster] ([MenuID], [ParentMenuID], [MenuName], [MenuDesc], [OrderNo], [PageURL], [CreateDate], [UpdateDate]) VALUES (8, 0, N'StoreSettings', N'StoreSettings', 1, NULL, CAST(N'2019-05-13 12:02:49.810' AS DateTime), CAST(N'2019-05-13 12:02:49.810' AS DateTime))
GO
INSERT [dbo].[tblMenuMaster] ([MenuID], [ParentMenuID], [MenuName], [MenuDesc], [OrderNo], [PageURL], [CreateDate], [UpdateDate]) VALUES (9, 0, N'Roles', N'Roles', 1, NULL, CAST(N'2019-05-13 00:00:00.000' AS DateTime), CAST(N'2019-05-13 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[tblMenuRights] ([MenuRightsID], [MenuID], [RoleID], [IsAdd], [IsUpdate], [IsDelete], [IsView], [CreateDate], [UpdateDate]) VALUES (1, 1, 1, 1, 0, 0, 1, CAST(N'2019-05-13 12:05:05.103' AS DateTime), CAST(N'2019-05-16 12:32:15.940' AS DateTime))
GO
INSERT [dbo].[tblMenuRights] ([MenuRightsID], [MenuID], [RoleID], [IsAdd], [IsUpdate], [IsDelete], [IsView], [CreateDate], [UpdateDate]) VALUES (2, 2, 1, 1, 0, 0, 1, CAST(N'2019-05-13 12:05:05.107' AS DateTime), CAST(N'2019-05-16 12:32:15.943' AS DateTime))
GO
INSERT [dbo].[tblMenuRights] ([MenuRightsID], [MenuID], [RoleID], [IsAdd], [IsUpdate], [IsDelete], [IsView], [CreateDate], [UpdateDate]) VALUES (3, 3, 1, 1, 0, 0, 1, CAST(N'2019-05-13 12:05:05.110' AS DateTime), CAST(N'2019-05-16 12:32:15.943' AS DateTime))
GO
INSERT [dbo].[tblMenuRights] ([MenuRightsID], [MenuID], [RoleID], [IsAdd], [IsUpdate], [IsDelete], [IsView], [CreateDate], [UpdateDate]) VALUES (4, 4, 1, 1, 0, 0, 1, CAST(N'2019-05-13 12:05:05.110' AS DateTime), CAST(N'2019-05-16 12:32:15.947' AS DateTime))
GO
INSERT [dbo].[tblMenuRights] ([MenuRightsID], [MenuID], [RoleID], [IsAdd], [IsUpdate], [IsDelete], [IsView], [CreateDate], [UpdateDate]) VALUES (5, 5, 1, 1, 0, 0, 1, CAST(N'2019-05-13 12:05:05.110' AS DateTime), CAST(N'2019-05-16 12:32:15.950' AS DateTime))
GO
INSERT [dbo].[tblMenuRights] ([MenuRightsID], [MenuID], [RoleID], [IsAdd], [IsUpdate], [IsDelete], [IsView], [CreateDate], [UpdateDate]) VALUES (6, 6, 1, 1, 0, 0, 1, CAST(N'2019-05-13 12:05:05.110' AS DateTime), CAST(N'2019-05-16 12:32:15.950' AS DateTime))
GO
INSERT [dbo].[tblMenuRights] ([MenuRightsID], [MenuID], [RoleID], [IsAdd], [IsUpdate], [IsDelete], [IsView], [CreateDate], [UpdateDate]) VALUES (7, 7, 1, 1, 0, 0, 1, CAST(N'2019-05-13 12:05:05.110' AS DateTime), CAST(N'2019-05-16 12:32:15.950' AS DateTime))
GO
INSERT [dbo].[tblMenuRights] ([MenuRightsID], [MenuID], [RoleID], [IsAdd], [IsUpdate], [IsDelete], [IsView], [CreateDate], [UpdateDate]) VALUES (8, 8, 1, 1, 0, 0, 1, CAST(N'2019-05-14 00:00:00.000' AS DateTime), CAST(N'2019-05-16 12:32:15.950' AS DateTime))
GO
INSERT [dbo].[tblMenuRights] ([MenuRightsID], [MenuID], [RoleID], [IsAdd], [IsUpdate], [IsDelete], [IsView], [CreateDate], [UpdateDate]) VALUES (9, 9, 1, 1, 0, 0, 1, CAST(N'2019-05-14 00:00:00.000' AS DateTime), CAST(N'2019-05-16 12:32:15.953' AS DateTime))
GO
INSERT [dbo].[tblRoleMaster] ([RoleID], [RoleName], [RoleDesc], [CreateDate], [UpdateDate], [IsDelete]) VALUES (1, N'Admin', N'Admin', CAST(N'2019-05-13 12:03:51.253' AS DateTime), CAST(N'2019-05-16 12:32:15.940' AS DateTime), 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (1, N'Jammu & Kashmir', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (2, N'Himachal Pradesh', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (3, N'Punjab', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (4, N'Chandigarh', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (5, N'Uttarakhand', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (6, N'Haryana', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (7, N'Delhi', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (8, N'Rajasthan', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (9, N'Uttar Pradesh', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (10, N'Bihar', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (11, N'Sikkim', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (12, N'Arunachal Pradesh', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (13, N'Nagaland', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (14, N'Manipur', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (15, N'Mizoram', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (16, N'Tripura', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (17, N'Meghalaya', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (18, N'Assam', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (19, N'West Bengal', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (20, N'Jharkhand', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (21, N'Orissa', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (22, N'Chhattisgarh', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (23, N'Madhya Pradesh', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (24, N'Gujarat', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (25, N'Daman & Diu', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (26, N'Dadra & Nagar Haveli', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (27, N'Maharashtra', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (28, N'Andhra Pradesh', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (29, N'Karnataka', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (30, N'Goa', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (31, N'Lakshadweep', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (32, N'Kerala', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (33, N'Tamil Nadu', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (34, N'Puducherry', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (35, N'Andaman & Nicobar Islands', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (36, N'Telengana', 0, 0, 0, 0, 0)
GO
INSERT [dbo].[tblStateMaster] ([StateID], [Name], [IGST], [CGST], [SGST], [Discount], [IsDelete]) VALUES (37, N'Andrapradesh(New)', 0, 0, 0, 0, 0)
GO
