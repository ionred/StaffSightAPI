∩╗┐USE [master]
GO
/****** Object:  Database [StaffSightDB]    Script Date: 2023-10-19 12:07:45 AM ******/
CREATE DATABASE [StaffSightDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StaffSightDB', FILENAME = N'/var/opt/mssql/data/StaffSightDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StaffSightDB_log', FILENAME = N'/var/opt/mssql/data/StaffSightDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StaffSightDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StaffSightDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StaffSightDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StaffSightDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StaffSightDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StaffSightDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StaffSightDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StaffSightDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StaffSightDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StaffSightDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StaffSightDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StaffSightDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StaffSightDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StaffSightDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StaffSightDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StaffSightDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StaffSightDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StaffSightDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StaffSightDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StaffSightDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StaffSightDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StaffSightDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StaffSightDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StaffSightDB] SET RECOVERY FULL 
GO
ALTER DATABASE [StaffSightDB] SET  MULTI_USER 
GO
ALTER DATABASE [StaffSightDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StaffSightDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StaffSightDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StaffSightDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StaffSightDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StaffSightDB] SET QUERY_STORE = OFF
GO
USE [StaffSightDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET ACCELERATED_PLAN_FORCING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET BATCH_MODE_ADAPTIVE_JOINS = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET BATCH_MODE_MEMORY_GRANT_FEEDBACK = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET BATCH_MODE_ON_ROWSTORE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET DEFERRED_COMPILATION_TV = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ELEVATE_ONLINE = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ELEVATE_RESUMABLE = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET GLOBAL_TEMPORARY_TABLE_AUTO_DROP = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET INTERLEAVED_EXECUTION_TVF = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ISOLATE_SECURITY_POLICY_CARDINALITY = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LAST_QUERY_PLAN_STATS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LIGHTWEIGHT_QUERY_PROFILING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET OPTIMIZE_FOR_AD_HOC_WORKLOADS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ROW_MODE_MEMORY_GRANT_FEEDBACK = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET TSQL_SCALAR_UDF_INLINING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET VERBOSE_TRUNCATION_WARNINGS = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_PROCEDURE_EXECUTION_STATISTICS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_QUERY_EXECUTION_STATISTICS = OFF;
GO
USE [StaffSightDB]
GO
/****** Object:  Table [dbo].[auditTrail]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[auditTrail](
	[auditTrailID] [int] NOT NULL,
	[moduleUsed] [varchar](100) NULL,
	[tableName] [varchar](100) NULL,
	[tableRowID] [int] NULL,
	[oldValue] [nvarchar](1000) NULL,
	[newValue] [nvarchar](1000) NULL,
	[RecordDeleted] [bit] NULL,
	[changedByEmpID] [varchar](10) NULL,
	[isConfidential] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[auditTrailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[auth_appGroupMapping]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[auth_appGroupMapping](
	[appGroupMappingID] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](100) NOT NULL,
	[appGroupName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[appGroupMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[auth_claimMapping]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[auth_claimMapping](
	[claimMappingID] [int] IDENTITY(1,1) NOT NULL,
	[claimName] [nvarchar](100) NOT NULL,
	[groupOrUserName] [nvarchar](100) NOT NULL,
	[groupOrUserType] [nvarchar](100) NULL,
	[removeClaim] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[claimMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[branch]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branch](
	[branchID] [varchar](10) NOT NULL,
	[branchName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[branchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[classAttendance]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classAttendance](
	[classAttendanceID] [int] NOT NULL,
	[trainingClassID] [int] NULL,
	[empID] [varchar](10) NULL,
	[reportingEmpID] [varchar](10) NULL,
	[attendanceType] [varchar](75) NULL,
	[incidentDate] [date] NULL,
	[isPreApproved] [bit] NULL,
	[timeNotified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[classAttendanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[classNameBuilder]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classNameBuilder](
	[classNameBuilderID] [int] NOT NULL,
	[codeName] [char](3) NULL,
	[codeType] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[classNameBuilderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[classroomAssignment]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classroomAssignment](
	[classroomAssignmentID] [int] NOT NULL,
	[roomType] [varchar](30) NULL,
	[roomLocation] [varchar](100) NULL,
	[roomID] [varchar](100) NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
	[startTime] [time](7) NULL,
	[endTime] [time](7) NULL,
	[trainingClassID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[classroomAssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employeedm]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeedm](
	[empID] [varchar](10) NOT NULL,
	[firstName] [varchar](75) NULL,
	[lastName] [varchar](75) NULL,
	[location] [varchar](75) NULL,
	[hireDate] [date] NULL,
	[billetNumber] [varchar](75) NULL,
	[vendor] [varchar](75) NULL,
	[supervisorEmpID] [varchar](10) NULL,
	[branchID] [varchar](10) NULL,
	[employeeType] [nvarchar](20) NULL,
	[CurrentRow] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[empID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employeeLeave]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeeLeave](
	[leaveID] [int] IDENTITY(1,1) NOT NULL,
	[empID] [varchar](10) NULL,
	[leaveDate] [date] NULL,
	[enteredDate] [datetime] NULL,
	[enteredBy] [varchar](10) NULL,
	[note] [nvarchar](1000) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employeeNote]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeeNote](
	[employeeNoteID] [int] IDENTITY(1,1) NOT NULL,
	[preHireID] [int] NULL,
	[note] [nvarchar](1000) NULL,
	[isConfidential] [bit] NULL,
	[enteredDate] [datetime] NULL,
	[enteredBy] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employeePreHire]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeePreHire](
	[preHireID] [int] IDENTITY(1,1) NOT NULL,
	[empID] [varchar](10) NOT NULL,
	[firstName] [varchar](75) NULL,
	[lastName] [varchar](75) NULL,
	[location] [varchar](75) NULL,
	[hireDate] [date] NULL,
	[billetNumber] [varchar](75) NULL,
	[vendor] [varchar](75) NULL,
	[supervisorEmpID] [varchar](10) NULL,
	[branchID] [varchar](10) NULL,
	[addressOne] [varchar](75) NULL,
	[addressTwo] [varchar](75) NULL,
	[city] [varchar](75) NULL,
	[state] [char](2) NULL,
	[zip] [smallint] NULL,
	[phoneNumber] [varchar](15) NULL,
	[phoneExtension] [varchar](15) NULL,
	[phoneType] [varchar](15) NULL,
	[personalEmail] [varchar](75) NULL,
	[shiftID] [int] NULL,
	[reqID] [varchar](20) NULL,
	[costCenter] [varchar](20) NULL,
	[stfAsstEmpID] [varchar](10) NULL,
	[isp] [varchar](20) NULL,
	[ispOther] [varchar](20) NULL,
	[ethernet] [bit] NULL,
	[ritm] [varchar](20) NULL,
	[activationID] [varchar](20) NULL,
	[ciscoNumber] [varchar](20) NULL,
	[isContractor] [bit] NULL,
	[isConversion] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[preHireID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employeeSalOffHist]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeeSalOffHist](
	[salaryID] [int] IDENTITY(1,1) NOT NULL,
	[preHireID] [int] NULL,
	[salary] [decimal](19, 2) NULL,
	[salaryType] [varchar](75) NULL,
	[enteredDate] [datetime] NULL,
	[enteredBy] [varchar](10) NULL,
	[note] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[salaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genericDefinition]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genericDefinition](
	[definitionID] [int] IDENTITY(1,1) NOT NULL,
	[definitionType] [varchar](75) NULL,
	[definitionValue] [varchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[definitionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[location]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location](
	[locationID] [int] NOT NULL,
	[locationName] [varchar](255) NULL,
	[classOnly] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[locationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[preHireBillet]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[preHireBillet](
	[billetNumber] [varchar](75) NOT NULL,
	[positionNumber] [varchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[billetNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shift]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shift](
	[shiftID] [int] NOT NULL,
	[DOA] [text] NULL,
	[hoaStart] [datetime] NULL,
	[hoaEnd] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[shiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trainerAssignment]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trainerAssignment](
	[trainerAssignmentID] [int] NOT NULL,
	[empID] [varchar](10) NULL,
	[trainingClassID] [int] NULL,
	[trainerType] [varchar](100) NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[trainerAssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trainingActivity]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trainingActivity](
	[trainingActivityID] [int] NOT NULL,
	[activityName] [varchar](100) NULL,
	[actDate] [date] NULL,
	[trainingClassID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[trainingActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trainingClass]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trainingClass](
	[trainingClassID] [int] NOT NULL,
	[className] [varchar](100) NULL,
	[classType] [varchar](100) NULL,
	[locationID] [int] NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
	[startTime] [time](7) NULL,
	[endTime] [time](7) NULL,
	[employeeType] [varchar](100) NULL,
	[targetHeadcount] [int] NULL,
	[isNEO] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[trainingClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trainingExclusion]    Script Date: 2023-10-19 12:07:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trainingExclusion](
	[trainingExclusionID] [int] NOT NULL,
	[exclusionDate] [date] NULL,
	[trainingClassID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[trainingExclusionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[employeedm] ([empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [employeeType], [CurrentRow]) VALUES (N'A6597', N'Bryan', N'Chaffin', N'Heritage Oaks', CAST(N'2019-07-19' AS Date), N'0001IDK002', NULL, N'50000', N'W000098', N'FTE', 1)
SET IDENTITY_INSERT [dbo].[employeeNote] ON 

INSERT [dbo].[employeeNote] ([employeeNoteID], [preHireID], [note], [isConfidential], [enteredDate], [enteredBy]) VALUES (1, 3, N'FirstNote For PH3', 0, CAST(N'2023-10-18T23:55:00.000' AS DateTime), N'A6597')
SET IDENTITY_INSERT [dbo].[employeeNote] OFF
SET IDENTITY_INSERT [dbo].[employeePreHire] ON 

INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (1, N'Z0001', N'Josiah', N'Bartlet', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (2, N'Z0002', N'C.J.', N'Cregg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (3, N'Z0003', N'Toby', N'Ziegler', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (4, N'Z0004', N'Josh', N'Lyman', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (5, N'Z0005', N'Donna', N'Moss', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (6, N'Z0006', N'Charlie', N'Young', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (7, N'Z0007', N'Leo', N'McGarry', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (8, N'Z0008', N'Will', N'Bailey', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (9, N'Z0009', N'Abbey', N'Bartlet', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (10, N'Z0010', N'Sam', N'Seaborn', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (11, N'Z0011', N'Margaret', N'Hooper', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (12, N'Z0012', N'Zoey', N'Bartlet', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (13, N'Z0013', N'Kate', N'Harper', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (14, N'Z0014', N'Bob', N'Russell', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (15, N'Z0015', N'Debbie', N'Fiderer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (16, N'Z0016', N'Oliver', N'Babish', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (17, N'Z0017', N'Ainsley', N'Hayes', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (18, N'Z0018', N'Amy', N'Gardner', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (19, N'Z0019', N'Danny', N'Concannon', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (20, N'Z0020', N'Annabeth', N'Schott', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (21, N'Z0021', N'Matt', N'Santos', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (22, N'Z0022', N'Nancy', N'McNally', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[employeePreHire] ([preHireID], [empID], [firstName], [lastName], [location], [hireDate], [billetNumber], [vendor], [supervisorEmpID], [branchID], [addressOne], [addressTwo], [city], [state], [zip], [phoneNumber], [phoneExtension], [phoneType], [personalEmail], [shiftID], [reqID], [costCenter], [stfAsstEmpID], [isp], [ispOther], [ethernet], [ritm], [activationID], [ciscoNumber], [isContractor], [isConversion]) VALUES (23, N'Z0023', N'Helen', N'Santos', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[employeePreHire] OFF
SET IDENTITY_INSERT [dbo].[employeeSalOffHist] ON 

INSERT [dbo].[employeeSalOffHist] ([salaryID], [preHireID], [salary], [salaryType], [enteredDate], [enteredBy], [note]) VALUES (2, 2, CAST(18.25 AS Decimal(19, 2)), N'Hourly', CAST(N'2023-10-18T22:45:00.000' AS DateTime), N'A6597', N'FirstSalary')
SET IDENTITY_INSERT [dbo].[employeeSalOffHist] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_employeePreHire_empID]    Script Date: 2023-10-19 12:07:45 AM ******/
ALTER TABLE [dbo].[employeePreHire] ADD  CONSTRAINT [UQ_employeePreHire_empID] UNIQUE NONCLUSTERED 
(
	[empID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[auth_claimMapping] ADD  DEFAULT ((0)) FOR [removeClaim]
GO
ALTER TABLE [dbo].[employeedm] ADD  CONSTRAINT [DF_employee_dm_CurrentRow]  DEFAULT ((1)) FOR [CurrentRow]
GO
ALTER TABLE [dbo].[auditTrail]  WITH CHECK ADD  CONSTRAINT [FK_auditTrail_changedByEmpID] FOREIGN KEY([changedByEmpID])
REFERENCES [dbo].[employeedm] ([empID])
GO
ALTER TABLE [dbo].[auditTrail] CHECK CONSTRAINT [FK_auditTrail_changedByEmpID]
GO
ALTER TABLE [dbo].[classAttendance]  WITH CHECK ADD  CONSTRAINT [FK_classAttendance_empID] FOREIGN KEY([empID])
REFERENCES [dbo].[employeePreHire] ([empID])
GO
ALTER TABLE [dbo].[classAttendance] CHECK CONSTRAINT [FK_classAttendance_empID]
GO
ALTER TABLE [dbo].[classAttendance]  WITH CHECK ADD  CONSTRAINT [FK_classAttendance_trainingClassID] FOREIGN KEY([trainingClassID])
REFERENCES [dbo].[trainingClass] ([trainingClassID])
GO
ALTER TABLE [dbo].[classAttendance] CHECK CONSTRAINT [FK_classAttendance_trainingClassID]
GO
ALTER TABLE [dbo].[classroomAssignment]  WITH CHECK ADD  CONSTRAINT [FK_classroomAssignment_trainingClassID] FOREIGN KEY([trainingClassID])
REFERENCES [dbo].[trainingClass] ([trainingClassID])
GO
ALTER TABLE [dbo].[classroomAssignment] CHECK CONSTRAINT [FK_classroomAssignment_trainingClassID]
GO
ALTER TABLE [dbo].[employeeLeave]  WITH CHECK ADD  CONSTRAINT [FK_employeeLeave_empID] FOREIGN KEY([empID])
REFERENCES [dbo].[employeePreHire] ([empID])
GO
ALTER TABLE [dbo].[employeeLeave] CHECK CONSTRAINT [FK_employeeLeave_empID]
GO
ALTER TABLE [dbo].[employeeLeave]  WITH CHECK ADD  CONSTRAINT [FK_employeeLeave_enteredBy] FOREIGN KEY([enteredBy])
REFERENCES [dbo].[employeedm] ([empID])
GO
ALTER TABLE [dbo].[employeeLeave] CHECK CONSTRAINT [FK_employeeLeave_enteredBy]
GO
ALTER TABLE [dbo].[employeeNote]  WITH CHECK ADD  CONSTRAINT [FK_employeeNote_enteredBy] FOREIGN KEY([enteredBy])
REFERENCES [dbo].[employeedm] ([empID])
GO
ALTER TABLE [dbo].[employeeNote] CHECK CONSTRAINT [FK_employeeNote_enteredBy]
GO
ALTER TABLE [dbo].[employeeNote]  WITH CHECK ADD  CONSTRAINT [FK_employeeNote_preHireID] FOREIGN KEY([preHireID])
REFERENCES [dbo].[employeePreHire] ([preHireID])
GO
ALTER TABLE [dbo].[employeeNote] CHECK CONSTRAINT [FK_employeeNote_preHireID]
GO
ALTER TABLE [dbo].[employeePreHire]  WITH CHECK ADD  CONSTRAINT [FK_employeePreHire_billetNumber] FOREIGN KEY([billetNumber])
REFERENCES [dbo].[preHireBillet] ([billetNumber])
GO
ALTER TABLE [dbo].[employeePreHire] CHECK CONSTRAINT [FK_employeePreHire_billetNumber]
GO
ALTER TABLE [dbo].[employeePreHire]  WITH CHECK ADD  CONSTRAINT [FK_employeePreHire_branchID] FOREIGN KEY([branchID])
REFERENCES [dbo].[branch] ([branchID])
GO
ALTER TABLE [dbo].[employeePreHire] CHECK CONSTRAINT [FK_employeePreHire_branchID]
GO
ALTER TABLE [dbo].[employeePreHire]  WITH CHECK ADD  CONSTRAINT [FK_employeePreHire_shiftID] FOREIGN KEY([shiftID])
REFERENCES [dbo].[shift] ([shiftID])
GO
ALTER TABLE [dbo].[employeePreHire] CHECK CONSTRAINT [FK_employeePreHire_shiftID]
GO
ALTER TABLE [dbo].[employeePreHire]  WITH CHECK ADD  CONSTRAINT [FK_employeePreHire_stfAsstEmpID] FOREIGN KEY([stfAsstEmpID])
REFERENCES [dbo].[employeedm] ([empID])
GO
ALTER TABLE [dbo].[employeePreHire] CHECK CONSTRAINT [FK_employeePreHire_stfAsstEmpID]
GO
ALTER TABLE [dbo].[employeePreHire]  WITH CHECK ADD  CONSTRAINT [FK_employeePreHire_supervisorEmpID] FOREIGN KEY([supervisorEmpID])
REFERENCES [dbo].[employeedm] ([empID])
GO
ALTER TABLE [dbo].[employeePreHire] CHECK CONSTRAINT [FK_employeePreHire_supervisorEmpID]
GO
ALTER TABLE [dbo].[employeeSalOffHist]  WITH CHECK ADD  CONSTRAINT [FK_employeeSalOffHist_enteredBy] FOREIGN KEY([enteredBy])
REFERENCES [dbo].[employeedm] ([empID])
GO
ALTER TABLE [dbo].[employeeSalOffHist] CHECK CONSTRAINT [FK_employeeSalOffHist_enteredBy]
GO
ALTER TABLE [dbo].[employeeSalOffHist]  WITH CHECK ADD  CONSTRAINT [FK_employeeSalOffHist_preHireID] FOREIGN KEY([preHireID])
REFERENCES [dbo].[employeePreHire] ([preHireID])
GO
ALTER TABLE [dbo].[employeeSalOffHist] CHECK CONSTRAINT [FK_employeeSalOffHist_preHireID]
GO
ALTER TABLE [dbo].[trainerAssignment]  WITH CHECK ADD  CONSTRAINT [FK_trainerAssignment_empID] FOREIGN KEY([empID])
REFERENCES [dbo].[employeedm] ([empID])
GO
ALTER TABLE [dbo].[trainerAssignment] CHECK CONSTRAINT [FK_trainerAssignment_empID]
GO
ALTER TABLE [dbo].[trainerAssignment]  WITH CHECK ADD  CONSTRAINT [FK_trainerAssignment_trainingClassID] FOREIGN KEY([trainingClassID])
REFERENCES [dbo].[trainingClass] ([trainingClassID])
GO
ALTER TABLE [dbo].[trainerAssignment] CHECK CONSTRAINT [FK_trainerAssignment_trainingClassID]
GO
ALTER TABLE [dbo].[trainingActivity]  WITH CHECK ADD  CONSTRAINT [FK_trainingActivity_trainingClassID] FOREIGN KEY([trainingClassID])
REFERENCES [dbo].[trainingClass] ([trainingClassID])
GO
ALTER TABLE [dbo].[trainingActivity] CHECK CONSTRAINT [FK_trainingActivity_trainingClassID]
GO
ALTER TABLE [dbo].[trainingClass]  WITH CHECK ADD  CONSTRAINT [FK_trainingClass_locationID] FOREIGN KEY([locationID])
REFERENCES [dbo].[location] ([locationID])
GO
ALTER TABLE [dbo].[trainingClass] CHECK CONSTRAINT [FK_trainingClass_locationID]
GO
ALTER TABLE [dbo].[trainingExclusion]  WITH CHECK ADD  CONSTRAINT [FK_trainingExclusion_trainingClassID] FOREIGN KEY([trainingClassID])
REFERENCES [dbo].[trainingClass] ([trainingClassID])
GO
ALTER TABLE [dbo].[trainingExclusion] CHECK CONSTRAINT [FK_trainingExclusion_trainingClassID]
GO
ALTER TABLE [dbo].[auth_claimMapping]  WITH CHECK ADD CHECK  (([groupOrUserType]='User' OR [groupOrUserType]='AppGroup' OR [groupOrUserType]='AD'))
GO
USE [master]
GO
ALTER DATABASE [StaffSightDB] SET  READ_WRITE 
GO
