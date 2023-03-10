USE [1C_Enterprise]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 17.02.2023 11:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[ID] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[Experience] [nvarchar](150) NOT NULL,
	[HarmfulProduction] [bit] NOT NULL,
	[Pension] [bit] NOT NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 17.02.2023 11:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Attendance] ([ID], [Age], [Experience], [HarmfulProduction], [Pension]) VALUES (1, 62, N'44', 0, 1)
INSERT [dbo].[Attendance] ([ID], [Age], [Experience], [HarmfulProduction], [Pension]) VALUES (2, 51, N'23', 1, 1)
INSERT [dbo].[Attendance] ([ID], [Age], [Experience], [HarmfulProduction], [Pension]) VALUES (3, 30, N'9', 1, 0)
INSERT [dbo].[Attendance] ([ID], [Age], [Experience], [HarmfulProduction], [Pension]) VALUES (4, 35, N'15', 1, 1)
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [FIO]) VALUES (1, N'Иванов И.С.')
INSERT [dbo].[Employee] ([ID], [FIO]) VALUES (2, N'Петров И.П.')
INSERT [dbo].[Employee] ([ID], [FIO]) VALUES (3, N'Сидоров А.А.')
INSERT [dbo].[Employee] ([ID], [FIO]) VALUES (4, N'Павлов П.О.')
SET IDENTITY_INSERT [dbo].[Employee] OFF
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Employee] FOREIGN KEY([ID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Employee]
GO
/****** Object:  StoredProcedure [dbo].[SelectAttendance]    Script Date: 17.02.2023 11:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAttendance]
AS
Select *,
(Case when Attendance.HarmfulProduction = 0 then 'false' else 'true' End) as HarmfulProduction_,
(Case when Attendance.Pension = 0   then  'false' else 'true'   End) as Pension_ from Employee
Inner Join Attendance Attendance on Attendance.ID = Employee.ID;
GO
/****** Object:  StoredProcedure [dbo].[SelectUpdateAttendance]    Script Date: 17.02.2023 11:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectUpdateAttendance]
@yearsold int,
@Harmfulyearsold int	
AS
Select *,
(Case when Attendance.HarmfulProduction = 0 then 'false' else 'true' End) as HarmfulProduction_,
(Case when Attendance.Age >= @yearsold  or Attendance.Experience >= @Harmfulyearsold  then 'true' else 'false'  End) as Pension_ 
FROM Employee
Inner Join Attendance Attendance on Attendance.ID = Employee.ID;
GO
/****** Object:  StoredProcedure [dbo].[UpdateAttendance]    Script Date: 17.02.2023 11:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAttendance]
@yearsold int,
@Harmfulyearsold int	
AS
UPDATE Attendance SET Attendance.Pension = (Case when Attendance.Age >= @yearsold  or Attendance.Experience >= @Harmfulyearsold  then  1 else 0  End);
GO
