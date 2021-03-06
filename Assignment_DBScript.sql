USE [master]
GO
/****** Object:  Database [Assignment]    Script Date: 10-09-2021 13:31:31 ******/
CREATE DATABASE [Assignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assignment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Assignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Assignment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Assignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Assignment] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Assignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Assignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Assignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Assignment] SET  MULTI_USER 
GO
ALTER DATABASE [Assignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Assignment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Assignment] SET QUERY_STORE = OFF
GO
USE [Assignment]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10-09-2021 13:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](200) NULL,
	[Designation] [varchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 10-09-2021 13:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDetails](
	[EmpDtlId] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [int] NOT NULL,
	[FileName] [varchar](100) NULL,
	[FilePath] [varchar](500) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_EmployeeDetails] PRIMARY KEY CLUSTERED 
(
	[EmpDtlId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmpId], [Name], [Email], [Designation]) VALUES (19, N'Krupali Pandya', N'krupalipandya411@gmail.com', N'Developer')
INSERT [dbo].[Employee] ([EmpId], [Name], [Email], [Designation]) VALUES (20, N'Test', N'test@gmail.com', N'Test')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeDetails] ON 

INSERT [dbo].[EmployeeDetails] ([EmpDtlId], [EmpId], [FileName], [FilePath], [CreatedDate]) VALUES (22, 19, N'InterviewTask_2021 (1).txt', N'/UploadedFiles/InterviewTask_2021 (1).txt', CAST(N'2021-09-10T13:26:57.823' AS DateTime))
INSERT [dbo].[EmployeeDetails] ([EmpDtlId], [EmpId], [FileName], [FilePath], [CreatedDate]) VALUES (23, 19, N'CV .Net Developer-Krupali Pandya.pdf', N'/UploadedFiles/CV .Net Developer-Krupali Pandya.pdf', CAST(N'2021-09-10T13:26:57.827' AS DateTime))
INSERT [dbo].[EmployeeDetails] ([EmpDtlId], [EmpId], [FileName], [FilePath], [CreatedDate]) VALUES (24, 19, N'Cover Letter - .Net Developer - Krupali Pandya.docx', N'/UploadedFiles/Cover Letter - .Net Developer - Krupali Pandya.docx', CAST(N'2021-09-10T13:26:57.830' AS DateTime))
INSERT [dbo].[EmployeeDetails] ([EmpDtlId], [EmpId], [FileName], [FilePath], [CreatedDate]) VALUES (25, 20, N'New Microsoft Excel Worksheet.xlsx', N'/UploadedFiles/New Microsoft Excel Worksheet.xlsx', CAST(N'2021-09-10T13:27:42.337' AS DateTime))
INSERT [dbo].[EmployeeDetails] ([EmpDtlId], [EmpId], [FileName], [FilePath], [CreatedDate]) VALUES (27, 20, N'InterviewTask_2021.txt', N'/UploadedFiles/InterviewTask_2021.txt', CAST(N'2021-09-10T13:27:42.340' AS DateTime))
INSERT [dbo].[EmployeeDetails] ([EmpDtlId], [EmpId], [FileName], [FilePath], [CreatedDate]) VALUES (28, 20, N'Anjali-pramana1.jpg', N'/UploadedFiles/Anjali-pramana1.jpg', CAST(N'2021-09-10T13:27:55.790' AS DateTime))
SET IDENTITY_INSERT [dbo].[EmployeeDetails] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_CRUDEmployee]    Script Date: 10-09-2021 13:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_CRUDEmployee] --null,'rerre','sds','sss','I'
(
@EmpId int = NULL,
@Name varchar(100) = NULL,
@Email varchar(200) = NULL,
@Designation varchar(100) = NULL,
@Type char(1)
)
as
begin

if(@Type = 'I')
begin
    declare @id int

	insert into Employee (Name,Email,Designation)
	values (@Name,@Email,@Designation)
    set @id = SCOPE_IDENTITY()
	select @id as id
end

else if(@Type = 'U')
begin
	update Employee set Name = @Name,Email = @Email, Designation = @Designation where EmpId = @EmpId
end

else if(@Type = 'D')
begin
	delete from Employee where EmpId = @EmpId
	delete from EmployeeDetails where EmpId = @EmpId
end

else if(@Type = 'S')
begin
	select * from Employee(nolock)
end

else if(@Type = 'E')
begin
	select * from Employee(nolock) where EmpId = @EmpId
end
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CRUDEmployeeDtl]    Script Date: 10-09-2021 13:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_CRUDEmployeeDtl]
(
@EmpDtlId int = NULL,
@EmpId int = NULL,
@FileName varchar(100) = NULL,
@FilePath varchar(500) = NULL,
@CreatedDate datetime = NULL,
@Type char(1)
)
as
begin

if(@Type = 'I')
begin
	insert into EmployeeDetails(EmpId,FileName,FilePath,CreatedDate)
	values (@EmpId,@FileName,@FilePath,GETDATE())
end

else if(@Type = 'U')
begin
	--delete from EmployeeDetails where EmpId = @EmpId
	insert into EmployeeDetails(EmpId,FileName,FilePath,CreatedDate)
	values (@EmpId,@FileName,@FilePath,GETDATE())
	--update EmployeeDetails set EmpId = @EmpId,FileName = @FileName, FilePath = @FilePath, CreatedDate = GETDATE() where EmpDtlId = @EmpDtlId
end

else if(@Type = 'D')
begin
	delete from EmployeeDetails where EmpDtlId = @EmpDtlId
end

else if(@Type = 'C')
begin
	delete from EmployeeDetails where EmpId = @EmpId
end

else if(@Type = 'S')
begin
	select * from EmployeeDetails(nolock)
end

else if(@Type = 'E')
begin
	select * from EmployeeDetails(nolock) where EmpId = @EmpId
end
end
GO
USE [master]
GO
ALTER DATABASE [Assignment] SET  READ_WRITE 
GO
