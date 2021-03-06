USE [master]
GO
/****** Object:  Database [TPA.PLS]    Script Date: 16/06/2017 6:34:46 PM ******/
CREATE DATABASE [TPA.PLS] ON  PRIMARY 
( NAME = N'TPA.PLS', FILENAME = N'D:\DatabaseQLTK\TPA.PLS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TPA.PLS_log', FILENAME = N'D:\DatabaseQLTK\TPA.PLS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TPA.PLS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TPA.PLS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TPA.PLS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TPA.PLS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TPA.PLS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TPA.PLS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TPA.PLS] SET ARITHABORT OFF 
GO
ALTER DATABASE [TPA.PLS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TPA.PLS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TPA.PLS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TPA.PLS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TPA.PLS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TPA.PLS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TPA.PLS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TPA.PLS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TPA.PLS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TPA.PLS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TPA.PLS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TPA.PLS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TPA.PLS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TPA.PLS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TPA.PLS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TPA.PLS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TPA.PLS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TPA.PLS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TPA.PLS] SET  MULTI_USER 
GO
ALTER DATABASE [TPA.PLS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TPA.PLS] SET DB_CHAINING OFF 
GO
USE [TPA.PLS]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BillCode] [nvarchar](50) NULL,
	[BillName] [nvarchar](200) NULL,
	[IssueDate] [datetime] NULL,
	[ParkingCardID] [int] NULL,
	[VehicleTypeID] [int] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Money] [decimal](18, 4) NULL,
	[LicensePlate] [nvarchar](50) NULL,
	[PersonName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Camera]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Camera](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CameraCode] [nvarchar](50) NULL,
	[CameraName] [nvarchar](200) NULL,
	[CameraUrl] [nvarchar](200) NULL,
	[IsLPR] [bit] NULL,
	[ParkingLotID] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Camera] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [nvarchar](50) NULL,
	[CompanyName] [nvarchar](200) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingLotID] [int] NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[CustomerType] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormAndFunction]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormAndFunction](
	[ID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Code] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[ShiftKey] [bit] NULL,
	[CtrlKey] [bit] NULL,
	[AltKey] [bit] NULL,
	[ShortcutKey] [nvarchar](20) NULL,
	[FormAndFunctionGroupID] [int] NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](20) NULL,
	[UpdatedDate] [datetime] NULL,
	[IsHide] [bit] NOT NULL,
 CONSTRAINT [PK_FormAndFunction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormAndFunctionGroup]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormAndFunctionGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](500) NULL,
	[Name] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
	[ParentID] [int] NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[IsHide] [bit] NOT NULL,
 CONSTRAINT [PK_FormAndFunctionGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parking]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingPalletID] [int] NULL,
	[ParkingCardID] [int] NULL,
	[InTime] [datetime] NULL,
	[OutTime] [datetime] NULL,
	[ParkingTypeID] [int] NULL,
	[VehicleTypeID] [int] NULL,
	[InLicensePlate] [nvarchar](20) NULL,
	[OutLicensePlate] [nvarchar](20) NULL,
	[PersonName] [nvarchar](50) NULL,
	[CompanyID] [int] NULL,
	[InImagePath1] [nvarchar](200) NULL,
	[InImagePath2] [nvarchar](200) NULL,
	[OutImagePath1] [nvarchar](200) NULL,
	[OutImagePath2] [nvarchar](200) NULL,
	[InImage1] [nvarchar](max) NULL,
	[InImage2] [nvarchar](max) NULL,
	[OutImage1] [nvarchar](max) NULL,
	[OutImage2] [nvarchar](max) NULL,
	[InLPImage] [nvarchar](max) NULL,
	[OutLPImage] [nvarchar](max) NULL,
	[LostCard] [bit] NULL,
	[Comment] [nvarchar](max) NULL,
	[LostTimeUpdate] [datetime] NULL,
	[TotalTime] [decimal](18, 4) NULL,
	[ParkingFee] [decimal](18, 4) NULL,
	[LostCardPrice] [decimal](18, 4) NULL,
	[TotalPrice] [decimal](18, 4) NULL,
	[ReadLicensePlateOk] [bit] NULL,
 CONSTRAINT [PK_Parking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingArea]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingArea](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingLotID] [int] NULL,
	[Code] [varchar](20) NULL,
	[Name] [nvarchar](250) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ParkingArea] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingBlock]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingBlock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingAreaID] [int] NULL,
	[Code] [nvarchar](10) NULL,
	[Name] [nvarchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ParkingBlock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingCard]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingCard](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingLotID] [int] NULL,
	[ParkingCardCode] [nvarchar](50) NULL,
	[ParkingCardName] [nvarchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ParkingCard] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingFeeConfig]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingFeeConfig](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingLotID] [int] NULL,
	[VehicleTypeID] [int] NULL,
	[StartDayTime] [int] NULL,
	[EndDayTime] [int] NULL,
	[DayFee] [decimal](18, 4) NULL,
	[NightFee] [decimal](18, 4) NULL,
	[AllDayFee] [decimal](18, 4) NULL,
	[Blog24H] [bit] NOT NULL,
	[NightCalculate] [bit] NOT NULL,
 CONSTRAINT [PK_ParkingFeeConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingGate]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingGate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingGateCode] [nvarchar](50) NULL,
	[ParkingGateName] [nvarchar](100) NULL,
	[ParkingLotID] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ParkingGate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingImage]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingID] [int] NOT NULL,
	[Image1] [nvarchar](max) NULL,
	[Image2] [nvarchar](max) NULL,
	[Image3] [nvarchar](max) NULL,
	[Image4] [nvarchar](max) NULL,
 CONSTRAINT [PK_ParkingImage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingLine]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingLine](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingLineCode] [nvarchar](50) NULL,
	[ParkingLineName] [nvarchar](100) NULL,
	[ParkingGateID] [int] NULL,
	[Active] [bit] NOT NULL,
	[ParkingLineLocation] [nvarchar](50) NULL,
 CONSTRAINT [PK_ParkingLine] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingLot]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingLot](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Active] [bit] NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[TotalSlot] [int] NULL,
	[TotalEmptySlot] [int] NULL,
	[TotalBusySlot] [int] NULL,
 CONSTRAINT [PK_ParkingLot] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingPallet]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingPallet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingBlockID] [int] NULL,
	[Code] [varchar](20) NULL,
	[Name] [nvarchar](250) NULL,
	[VehicleTypeID] [int] NULL,
	[Active] [bit] NULL,
	[Empty] [bit] NULL,
 CONSTRAINT [PK_ParkingPallet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingType]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingTypeCode] [nvarchar](50) NULL,
	[ParkingTypeName] [nvarchar](200) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ParkingType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Partner]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partner](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PartnerCode] [nvarchar](50) NULL,
	[PartnerName] [nvarchar](200) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reader]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reader](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReaderCode] [nvarchar](50) NULL,
	[ReaderName] [nvarchar](50) NULL,
	[COMPort] [int] NULL,
	[PortMode] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[ParkingLotID] [int] NULL,
 CONSTRAINT [PK_Reader] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sys_Function]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Function](
	[FunctionID] [nvarchar](200) NOT NULL,
	[FunctionName] [nvarchar](200) NULL,
	[FunctionParentID] [nvarchar](200) NULL,
	[ControlName] [nvarchar](200) NULL,
	[Form] [nvarchar](200) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Sys_Function] PRIMARY KEY CLUSTERED 
(
	[FunctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sys_Group]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Group](
	[GroupID] [nvarchar](200) NOT NULL,
	[GroupName] [nvarchar](200) NULL,
	[Active] [bit] NULL,
	[CanDelete] [bit] NULL,
 CONSTRAINT [PK_Sys_Group] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sys_Logger]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Logger](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LogTime] [datetime] NULL,
	[UserID] [int] NOT NULL,
	[HostName] [nvarchar](50) NULL,
	[IPAddress] [nvarchar](50) NULL,
	[MacAddress] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sys_Member]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Member](
	[GroupID] [nvarchar](200) NOT NULL,
	[UserID] [nvarchar](200) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sys_Permission]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Permission](
	[FunctionID] [nvarchar](200) NOT NULL,
	[GroupID] [nvarchar](200) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sys_User]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_User](
	[UserID] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](200) NULL,
	[Password] [nvarchar](200) NULL,
	[ShortName] [nvarchar](200) NULL,
	[Photo] [image] NULL,
	[Active] [bit] NULL,
	[PartnerID] [int] NULL,
 CONSTRAINT [PK_Sys_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translate]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translate](
	[Name] [nvarchar](max) NULL,
	[Vietnamese] [nvarchar](max) NULL,
	[English] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NULL,
	[Width] [int] NULL,
	[EditMark] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[TruongNhom] [int] NULL,
	[DepartmentID] [int] NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroupRightDistribution]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupRightDistribution](
	[ID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FormAndFunctionID] [int] NOT NULL,
	[UserGroupID] [int] NOT NULL,
 CONSTRAINT [PK_UserGroupRightDistribution_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRightDistribution]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRightDistribution](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FormAndFunctionID] [int] NULL,
	[UserID] [int] NULL,
	[ViewRight] [bit] NULL,
	[CreateRight] [bit] NULL,
	[ModifyRight] [bit] NULL,
	[DeleteRight] [bit] NULL,
	[SpecialRight] [bit] NULL,
	[UserInsertID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UserUpdateID] [int] NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Code] [nvarchar](50) NULL,
	[LoginName] [nvarchar](50) NULL,
	[PasswordHash] [nvarchar](250) NULL,
	[FullName] [nvarchar](250) NULL,
	[BirthOfDate] [datetime] NULL,
	[Sex] [int] NULL,
	[Qualifications] [nvarchar](250) NULL,
	[BankAccount] [nvarchar](250) NULL,
	[BHYT] [nvarchar](250) NULL,
	[MST] [nvarchar](250) NULL,
	[BHXH] [nvarchar](250) NULL,
	[CMTND] [nvarchar](250) NULL,
	[JobDescription] [nvarchar](200) NULL,
	[Telephone] [nvarchar](100) NULL,
	[HandPhone] [nvarchar](100) NULL,
	[HomeAddress] [nvarchar](100) NULL,
	[Resident] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[DepartmentID] [int] NULL,
	[Status] [int] NULL,
	[Communication] [nvarchar](100) NULL,
	[PassExpireDate] [datetime] NULL,
	[IsCashier] [bit] NULL,
	[CashierNo] [int] NULL,
	[EmailCom] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[StartWorking] [datetime] NULL,
	[UserGroupID] [int] NULL,
	[MainViewID] [int] NULL,
	[Position] [nvarchar](50) NULL,
	[IsSetupFunction] [bit] NULL,
	[ImagePath] [ntext] NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](20) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingLotID] [int] NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Active] [bit] NOT NULL,
	[Height] [decimal](18, 4) NULL,
	[Width] [decimal](18, 4) NULL,
	[Length] [decimal](18, 4) NULL,
	[Weight] [decimal](18, 4) NULL,
 CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vCamera]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vCamera]
AS
SELECT        dbo.Camera.ID, dbo.Camera.CameraCode, dbo.Camera.CameraName, dbo.Camera.CameraUrl, dbo.Camera.IsLPR, dbo.Camera.ParkingLotID, dbo.Camera.Active, dbo.ParkingLot.Name
FROM            dbo.Camera LEFT OUTER JOIN
                         dbo.ParkingLot ON dbo.Camera.ParkingLotID = dbo.ParkingLot.ID

GO
/****** Object:  View [dbo].[vParking]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vParking]
AS
SELECT        dbo.Parking.ID, dbo.Parking.ParkingPalletID, dbo.Parking.ParkingCardID, dbo.Parking.InTime, dbo.Parking.OutTime, dbo.Parking.InLicensePlate, dbo.Parking.OutLicensePlate, dbo.Parking.InImagePath1, 
                         dbo.Parking.LostCard, dbo.Parking.TotalTime, dbo.Parking.ParkingFee, dbo.Parking.LostCardPrice, dbo.Parking.TotalPrice, dbo.Parking.ReadLicensePlateOk, dbo.ParkingPallet.Code AS PalletCode, 
                         dbo.ParkingPallet.Name AS PalletName, dbo.ParkingBlock.Code AS BlockCode, dbo.ParkingBlock.Name AS BlockName, dbo.ParkingArea.Code AS AreaCode, dbo.ParkingArea.Name AS AreaName, 
                         dbo.ParkingLot.Code AS ParkingLotCode, dbo.ParkingLot.Name AS ParkingLotName, dbo.ParkingCard.ParkingCardCode, dbo.ParkingCard.ParkingCardName, 
                         dbo.ParkingBlock.ParkingAreaID AS PBParkingAreaID
FROM            dbo.ParkingArea LEFT OUTER JOIN
                         dbo.ParkingLot ON dbo.ParkingArea.ParkingLotID = dbo.ParkingLot.ID RIGHT OUTER JOIN
                         dbo.ParkingBlock ON dbo.ParkingArea.ID = dbo.ParkingBlock.ParkingAreaID RIGHT OUTER JOIN
                         dbo.ParkingPallet ON dbo.ParkingBlock.ID = dbo.ParkingPallet.ParkingBlockID RIGHT OUTER JOIN
                         dbo.Parking LEFT OUTER JOIN
                         dbo.ParkingCard ON dbo.Parking.ParkingCardID = dbo.ParkingCard.ID ON dbo.ParkingPallet.ID = dbo.Parking.ParkingPalletID

GO
/****** Object:  View [dbo].[vParkingArea]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vParkingArea]
AS
SELECT     dbo.ParkingArea.ID, dbo.ParkingArea.ParkingLotID, dbo.ParkingArea.Code, dbo.ParkingArea.Name, dbo.ParkingArea.Active, dbo.ParkingLot.Code AS ParkingLotCode, 
                      dbo.ParkingLot.Name AS ParkingLotName
FROM         dbo.ParkingArea LEFT OUTER JOIN
                      dbo.ParkingLot ON dbo.ParkingArea.ParkingLotID = dbo.ParkingLot.ID

GO
/****** Object:  View [dbo].[vParkingBlock]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vParkingBlock]
AS
SELECT        dbo.ParkingBlock.ID, dbo.ParkingBlock.ParkingAreaID, dbo.ParkingBlock.Code, dbo.ParkingBlock.Name, dbo.ParkingBlock.Active, dbo.ParkingArea.Name AS AreaName, dbo.ParkingArea.ID AS AreaID, 
                         dbo.ParkingLot.Name AS ParkingLotName, dbo.ParkingLot.ID AS ParkingLotID
FROM            dbo.ParkingBlock INNER JOIN
                         dbo.ParkingArea ON dbo.ParkingBlock.ParkingAreaID = dbo.ParkingArea.ID INNER JOIN
                         dbo.ParkingLot ON dbo.ParkingArea.ParkingLotID = dbo.ParkingLot.ID

GO
/****** Object:  View [dbo].[vParkingCard]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vParkingCard]
AS
SELECT        dbo.ParkingCard.*, dbo.ParkingLot.Name
FROM            dbo.ParkingCard LEFT OUTER JOIN
                         dbo.ParkingLot ON dbo.ParkingCard.ParkingLotID = dbo.ParkingLot.ID

GO
/****** Object:  View [dbo].[vParkingPallet]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vParkingPallet]
AS
SELECT     dbo.ParkingPallet.ParkingBlockID, dbo.ParkingPallet.ID, dbo.ParkingPallet.Code, dbo.ParkingPallet.Name, dbo.ParkingPallet.VehicleTypeID, dbo.ParkingPallet.Active, 
                      dbo.ParkingPallet.Empty, dbo.ParkingBlock.Code AS ParkingBlockCode, dbo.ParkingBlock.Name AS ParkingBlockName, dbo.ParkingArea.Code AS ParkingAreaCode, 
                      dbo.ParkingArea.Name AS ParkingAreaName, dbo.ParkingLot.Code AS ParkingLotCode, dbo.ParkingLot.Name AS ParkingLotName, dbo.ParkingBlock.ParkingAreaID, 
                      dbo.ParkingArea.ParkingLotID
FROM         dbo.ParkingArea LEFT OUTER JOIN
                      dbo.ParkingLot ON dbo.ParkingArea.ParkingLotID = dbo.ParkingLot.ID RIGHT OUTER JOIN
                      dbo.ParkingBlock ON dbo.ParkingArea.ID = dbo.ParkingBlock.ParkingAreaID RIGHT OUTER JOIN
                      dbo.ParkingPallet ON dbo.ParkingBlock.ID = dbo.ParkingPallet.ParkingBlockID

GO
/****** Object:  View [dbo].[vReader]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vReader]
AS
SELECT        dbo.Reader.ID, dbo.Reader.ReaderCode, dbo.Reader.ReaderName, dbo.Reader.COMPort, dbo.Reader.PortMode, dbo.Reader.Active, dbo.Reader.ParkingLotID, dbo.ParkingLot.Name
FROM            dbo.Reader LEFT OUTER JOIN
                         dbo.ParkingLot ON dbo.Reader.ParkingLotID = dbo.ParkingLot.ID

GO
SET IDENTITY_INSERT [dbo].[Camera] ON 

INSERT [dbo].[Camera] ([ID], [CameraCode], [CameraName], [CameraUrl], [IsLPR], [ParkingLotID], [Active]) VALUES (1, N'm3', N't3', N'u3', 1, 1, 0)
INSERT [dbo].[Camera] ([ID], [CameraCode], [CameraName], [CameraUrl], [IsLPR], [ParkingLotID], [Active]) VALUES (3, N'rưert', N'wer', N'ưerwer', 0, 1, 1)
INSERT [dbo].[Camera] ([ID], [CameraCode], [CameraName], [CameraUrl], [IsLPR], [ParkingLotID], [Active]) VALUES (4, N'mmmmmmmmmmmmmmm', N'ttttttttttttttttttttttt', N'uuuuuuuuuuuuuu', 1, 1, 1)
INSERT [dbo].[Camera] ([ID], [CameraCode], [CameraName], [CameraUrl], [IsLPR], [ParkingLotID], [Active]) VALUES (5, N'm2', N't2', N'u2', 1, 1, 0)
INSERT [dbo].[Camera] ([ID], [CameraCode], [CameraName], [CameraUrl], [IsLPR], [ParkingLotID], [Active]) VALUES (6, N'sfsfsfs', N'sdfsfsfd', N'', 1, 1, 0)
INSERT [dbo].[Camera] ([ID], [CameraCode], [CameraName], [CameraUrl], [IsLPR], [ParkingLotID], [Active]) VALUES (7, N'c3', N't3', N'dfgdgdgdgdgdgd', 0, 1, 1)
SET IDENTITY_INSERT [dbo].[Camera] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [ParkingLotID], [Code], [Name], [PhoneNumber], [Email], [Address], [CustomerType], [Active]) VALUES (1, 1, N'M2', N'Block 2', N'2342342342343', N'fgfdgdgfgf', N'gegergerg', 0, 0)
INSERT [dbo].[Customer] ([ID], [ParkingLotID], [Code], [Name], [PhoneNumber], [Email], [Address], [CustomerType], [Active]) VALUES (2, 1, N'b3', N'abc', N'345353', N'fggfh', N'yhfghfhfhfh', 0, 0)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Parking] ON 

INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (21, 6, 8, CAST(N'2017-06-16T13:25:15.823' AS DateTime), CAST(N'2017-06-16T15:44:28.323' AS DateTime), 0, 0, N'30E-32733', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616132515_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(2.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(40.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (22, 10, 6, CAST(N'2017-06-16T13:25:24.053' AS DateTime), CAST(N'2017-06-16T15:47:35.603' AS DateTime), 0, 0, N'', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616132523_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(2.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(40.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (23, 23, 5, CAST(N'2017-06-16T13:25:30.030' AS DateTime), CAST(N'2017-06-16T15:33:48.670' AS DateTime), 0, 0, N'30L-3273', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616132529_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(2.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(40.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (24, 58, 8, CAST(N'2017-06-16T13:25:39.257' AS DateTime), CAST(N'2017-06-16T15:47:40.933' AS DateTime), 0, 0, N'', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616132539_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(2.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(40.0000 AS Decimal(18, 4)), 0)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (25, 56, 6, CAST(N'2017-06-16T13:25:48.593' AS DateTime), CAST(N'2017-06-16T15:34:48.667' AS DateTime), 0, 0, N'30L-3273', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616132548_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(2.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(40.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (26, 86, 5, CAST(N'2017-06-16T14:55:53.913' AS DateTime), CAST(N'2017-06-16T15:49:06.177' AS DateTime), 0, 0, N'30E-32733', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616145553_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (27, 40, 5, CAST(N'2017-06-16T14:56:51.630' AS DateTime), CAST(N'2017-06-16T15:47:45.413' AS DateTime), 0, 0, N'30E-32733', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616145651_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (28, 4, 6, CAST(N'2017-06-16T16:06:34.110' AS DateTime), CAST(N'2017-06-16T16:09:22.110' AS DateTime), 0, 0, N'30E-32733', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616160633_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (29, 6, 8, CAST(N'2017-06-16T16:06:43.020' AS DateTime), CAST(N'2017-06-16T16:09:14.133' AS DateTime), 0, 0, N'30E-32733', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616160642_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (30, 8, 0, CAST(N'2017-06-16T16:33:08.720' AS DateTime), NULL, 0, 0, N'30E-32733', N'', N'', 0, N'D:\100.Factory\2.Winform\BMS Inventory Code\BMS\bin\x86\Debug\Images\170616163308_Cam 1.jpg', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 1)
INSERT [dbo].[Parking] ([ID], [ParkingPalletID], [ParkingCardID], [InTime], [OutTime], [ParkingTypeID], [VehicleTypeID], [InLicensePlate], [OutLicensePlate], [PersonName], [CompanyID], [InImagePath1], [InImagePath2], [OutImagePath1], [OutImagePath2], [InImage1], [InImage2], [OutImage1], [OutImage2], [InLPImage], [OutLPImage], [LostCard], [Comment], [LostTimeUpdate], [TotalTime], [ParkingFee], [LostCardPrice], [TotalPrice], [ReadLicensePlateOk]) VALUES (31, 40, 7, CAST(N'2017-06-16T17:04:00.000' AS DateTime), CAST(N'2017-06-16T17:04:00.000' AS DateTime), 0, 0, N'a1', N'', N'', 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 0, N'', NULL, CAST(0.0000 AS Decimal(18, 4)), CAST(20000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 0)
SET IDENTITY_INSERT [dbo].[Parking] OFF
SET IDENTITY_INSERT [dbo].[ParkingArea] ON 

INSERT [dbo].[ParkingArea] ([ID], [ParkingLotID], [Code], [Name], [Active]) VALUES (8, 2, N'1', N'Khu vực 6 block', 1)
INSERT [dbo].[ParkingArea] ([ID], [ParkingLotID], [Code], [Name], [Active]) VALUES (9, 2, N'2', N'Khu vực 4 block', 1)
SET IDENTITY_INSERT [dbo].[ParkingArea] OFF
SET IDENTITY_INSERT [dbo].[ParkingBlock] ON 

INSERT [dbo].[ParkingBlock] ([ID], [ParkingAreaID], [Code], [Name], [Active]) VALUES (3, 8, N'1', N'BLOCK 01', 1)
INSERT [dbo].[ParkingBlock] ([ID], [ParkingAreaID], [Code], [Name], [Active]) VALUES (4, 8, N'2', N'BLOCK 02', 1)
INSERT [dbo].[ParkingBlock] ([ID], [ParkingAreaID], [Code], [Name], [Active]) VALUES (5, 8, N'3', N'BLOCK 03', 1)
INSERT [dbo].[ParkingBlock] ([ID], [ParkingAreaID], [Code], [Name], [Active]) VALUES (6, 8, N'4', N'BLOCK 04', 1)
INSERT [dbo].[ParkingBlock] ([ID], [ParkingAreaID], [Code], [Name], [Active]) VALUES (7, 8, N'5', N'BLOCK 05', 1)
INSERT [dbo].[ParkingBlock] ([ID], [ParkingAreaID], [Code], [Name], [Active]) VALUES (8, 8, N'6', N'BLOCK 06', 1)
SET IDENTITY_INSERT [dbo].[ParkingBlock] OFF
SET IDENTITY_INSERT [dbo].[ParkingCard] ON 

INSERT [dbo].[ParkingCard] ([ID], [ParkingLotID], [ParkingCardCode], [ParkingCardName], [Active]) VALUES (1, 2, N'4EB383F6', N'1', 1)
INSERT [dbo].[ParkingCard] ([ID], [ParkingLotID], [ParkingCardCode], [ParkingCardName], [Active]) VALUES (2, 2, N'B1516F85', N'2', 1)
INSERT [dbo].[ParkingCard] ([ID], [ParkingLotID], [ParkingCardCode], [ParkingCardName], [Active]) VALUES (3, 2, N'CE7F6CF6', N'3', 1)
INSERT [dbo].[ParkingCard] ([ID], [ParkingLotID], [ParkingCardCode], [ParkingCardName], [Active]) VALUES (4, 2, N'81D3253B', N'4', 1)
INSERT [dbo].[ParkingCard] ([ID], [ParkingLotID], [ParkingCardCode], [ParkingCardName], [Active]) VALUES (5, 2, N'FE4BD1F6', N'5', 1)
INSERT [dbo].[ParkingCard] ([ID], [ParkingLotID], [ParkingCardCode], [ParkingCardName], [Active]) VALUES (6, 2, N'2EFA83F6', N'6', 1)
INSERT [dbo].[ParkingCard] ([ID], [ParkingLotID], [ParkingCardCode], [ParkingCardName], [Active]) VALUES (7, 2, N'9E3A65F6', N'7', 1)
INSERT [dbo].[ParkingCard] ([ID], [ParkingLotID], [ParkingCardCode], [ParkingCardName], [Active]) VALUES (8, 2, N'BE1868F6', N'8', 1)
INSERT [dbo].[ParkingCard] ([ID], [ParkingLotID], [ParkingCardCode], [ParkingCardName], [Active]) VALUES (9, 2, N'CEF084F6', N'9', 1)
SET IDENTITY_INSERT [dbo].[ParkingCard] OFF
SET IDENTITY_INSERT [dbo].[ParkingLot] ON 

INSERT [dbo].[ParkingLot] ([ID], [Code], [Name], [Active], [Address], [PhoneNumber], [TotalSlot], [TotalEmptySlot], [TotalBusySlot]) VALUES (2, N'NH_01', N'Bãi xe Nguyên Hồng', 1, N'', N'123456789', 0, 0, 0)
SET IDENTITY_INSERT [dbo].[ParkingLot] OFF
SET IDENTITY_INSERT [dbo].[ParkingPallet] ON 

INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (1, 3, N'1-1-1', N'1-1-1', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (2, 3, N'1-1-2', N'1-1-2', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (3, 3, N'1-1-3', N'1-1-3', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (4, 3, N'1-1-4', N'1-1-4', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (5, 3, N'1-1-5', N'1-1-5', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (6, 3, N'1-1-6', N'1-1-6', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (7, 3, N'1-1-7', N'1-1-7', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (8, 3, N'1-1-8', N'1-1-8', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (9, 3, N'1-1-9', N'1-1-9', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (10, 3, N'1-1-10', N'1-1-10', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (11, 3, N'1-1-11', N'1-1-11', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (12, 3, N'1-1-12', N'1-1-12', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (13, 3, N'1-1-13', N'1-1-13', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (14, 3, N'1-1-14', N'1-1-14', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (15, 3, N'1-1-15', N'1-1-15', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (16, 3, N'1-1-16', N'1-1-16', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (17, 3, N'1-1-17', N'1-1-17', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (18, 4, N'1-2-1', N'1-2-1', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (19, 4, N'1-2-2', N'1-2-2', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (20, 4, N'1-2-3', N'1-2-3', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (21, 4, N'1-2-4', N'1-2-4', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (22, 4, N'1-2-5', N'1-2-5', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (23, 4, N'1-2-6', N'1-2-6', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (24, 4, N'1-2-7', N'1-2-7', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (25, 4, N'1-2-8', N'1-2-8', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (26, 4, N'1-2-9', N'1-2-9', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (27, 4, N'1-2-10', N'1-2-10', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (28, 4, N'1-2-11', N'1-2-11', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (29, 4, N'1-2-12', N'1-2-12', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (30, 4, N'1-2-13', N'1-2-13', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (31, 4, N'1-2-14', N'1-2-14', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (32, 4, N'1-2-15', N'1-2-15', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (33, 4, N'1-2-16', N'1-2-16', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (34, 4, N'1-2-17', N'1-2-17', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (35, 5, N'1-3-1', N'1-3-1', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (36, 5, N'1-3-2', N'1-3-2', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (37, 5, N'1-3-3', N'1-3-3', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (38, 5, N'1-3-4', N'1-3-4', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (39, 5, N'1-3-5', N'1-3-5', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (40, 5, N'1-3-6', N'1-3-6', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (41, 5, N'1-3-7', N'1-3-7', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (42, 5, N'1-3-8', N'1-3-8', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (43, 5, N'1-3-9', N'1-3-9', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (44, 5, N'1-3-10', N'1-3-10', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (45, 5, N'1-3-11', N'1-3-11', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (46, 5, N'1-3-12', N'1-3-12', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (47, 5, N'1-3-13', N'1-3-13', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (48, 5, N'1-3-14', N'1-3-14', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (49, 5, N'1-3-15', N'1-3-15', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (50, 5, N'1-3-16', N'1-3-16', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (51, 5, N'1-3-17', N'1-3-17', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (52, 6, N'1-4-1', N'1-4-1', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (53, 6, N'1-4-2', N'1-4-2', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (54, 6, N'1-4-3', N'1-4-3', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (55, 6, N'1-4-4', N'1-4-4', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (56, 6, N'1-4-5', N'1-4-5', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (57, 6, N'1-4-6', N'1-4-6', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (58, 6, N'1-4-7', N'1-4-7', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (59, 6, N'1-4-8', N'1-4-8', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (60, 6, N'1-4-9', N'1-4-9', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (61, 6, N'1-4-10', N'1-4-10', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (62, 6, N'1-4-11', N'1-4-11', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (63, 6, N'1-4-12', N'1-4-12', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (64, 6, N'1-4-13', N'1-4-13', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (65, 6, N'1-4-14', N'1-4-14', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (66, 6, N'1-4-15', N'1-4-15', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (67, 6, N'1-4-16', N'1-4-16', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (68, 6, N'1-4-17', N'1-4-17', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (69, 7, N'1-5-1', N'1-5-1', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (70, 7, N'1-5-2', N'1-5-2', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (71, 7, N'1-5-3', N'1-5-3', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (72, 7, N'1-5-4', N'1-5-4', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (73, 7, N'1-5-5', N'1-5-5', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (74, 7, N'1-5-6', N'1-5-6', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (75, 7, N'1-5-7', N'1-5-7', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (76, 7, N'1-5-8', N'1-5-8', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (77, 7, N'1-5-9', N'1-5-9', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (78, 7, N'1-5-10', N'1-5-10', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (79, 7, N'1-5-11', N'1-5-11', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (80, 7, N'1-5-12', N'1-5-12', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (81, 7, N'1-5-13', N'1-5-13', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (82, 7, N'1-5-14', N'1-5-14', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (83, 7, N'1-5-15', N'1-5-15', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (84, 7, N'1-5-16', N'1-5-16', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (85, 7, N'1-5-17', N'1-5-17', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (86, 8, N'1-6-1', N'1-6-1', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (87, 8, N'1-6-2', N'1-6-2', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (88, 8, N'1-6-3', N'1-6-3', 1, 1, 0)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (89, 8, N'1-6-4', N'1-6-4', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (90, 8, N'1-6-5', N'1-6-5', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (91, 8, N'1-6-6', N'1-6-6', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (92, 8, N'1-6-7', N'1-6-7', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (93, 8, N'1-6-8', N'1-6-8', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (94, 8, N'1-6-9', N'1-6-9', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (95, 8, N'1-6-10', N'1-6-10', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (96, 8, N'1-6-11', N'1-6-11', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (97, 8, N'1-6-12', N'1-6-12', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (98, 8, N'1-6-13', N'1-6-13', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (99, 8, N'1-6-14', N'1-6-14', 1, 1, 1)
GO
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (100, 8, N'1-6-15', N'1-6-15', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (101, 8, N'1-6-16', N'1-6-16', 1, 1, 1)
INSERT [dbo].[ParkingPallet] ([ID], [ParkingBlockID], [Code], [Name], [VehicleTypeID], [Active], [Empty]) VALUES (102, 8, N'1-6-17', N'1-6-17', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[ParkingPallet] OFF
SET IDENTITY_INSERT [dbo].[Reader] ON 

INSERT [dbo].[Reader] ([ID], [ReaderCode], [ReaderName], [COMPort], [PortMode], [Active], [ParkingLotID]) VALUES (1, N'REARER1', N'Đầu đọc thẻ 1', 3, N'19200,8,N,1', 1, 1)
INSERT [dbo].[Reader] ([ID], [ReaderCode], [ReaderName], [COMPort], [PortMode], [Active], [ParkingLotID]) VALUES (3, N'READER2', N'Đầu đọc thẻ 2', 5, N'19200,8,N,1', 0, 1)
INSERT [dbo].[Reader] ([ID], [ReaderCode], [ReaderName], [COMPort], [PortMode], [Active], [ParkingLotID]) VALUES (4, N'READER3', N'Đầu đọc thẻ 3', 4, N'19200,8,N,1', 0, 1)
SET IDENTITY_INSERT [dbo].[Reader] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Code], [LoginName], [PasswordHash], [FullName], [BirthOfDate], [Sex], [Qualifications], [BankAccount], [BHYT], [MST], [BHXH], [CMTND], [JobDescription], [Telephone], [HandPhone], [HomeAddress], [Resident], [PostalCode], [DepartmentID], [Status], [Communication], [PassExpireDate], [IsCashier], [CashierNo], [EmailCom], [Email], [StartWorking], [UserGroupID], [MainViewID], [Position], [IsSetupFunction], [ImagePath], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'NV01', N'admin', N'MQA=', N'admin', NULL, 0, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', 1, 0, N'', NULL, 0, 0, N'', N'', NULL, 1, 0, N'', 0, N'', N'', NULL, N'admin', CAST(N'2017-06-14T09:01:59.553' AS DateTime))
INSERT [dbo].[Users] ([ID], [Code], [LoginName], [PasswordHash], [FullName], [BirthOfDate], [Sex], [Qualifications], [BankAccount], [BHYT], [MST], [BHXH], [CMTND], [JobDescription], [Telephone], [HandPhone], [HomeAddress], [Resident], [PostalCode], [DepartmentID], [Status], [Communication], [PassExpireDate], [IsCashier], [CashierNo], [EmailCom], [Email], [StartWorking], [UserGroupID], [MainViewID], [Position], [IsSetupFunction], [ImagePath], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'NV02', N'anh.md', N'MQAyADMANAA1ADYA', N'Mai Đức Anh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[VehicleType] ON 

INSERT [dbo].[VehicleType] ([ID], [ParkingLotID], [Code], [Name], [Active], [Height], [Width], [Length], [Weight]) VALUES (1, 1, N'SE', N'Sedan', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[VehicleType] ([ID], [ParkingLotID], [Code], [Name], [Active], [Height], [Width], [Length], [Weight]) VALUES (2, 1, N'SU', N'Suv', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[VehicleType] OFF
ALTER TABLE [dbo].[Camera] ADD  CONSTRAINT [DF_Camera_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF_Company_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Parking] ADD  CONSTRAINT [DF_Parking_LostCard]  DEFAULT ((0)) FOR [LostCard]
GO
ALTER TABLE [dbo].[ParkingArea] ADD  CONSTRAINT [DF_ParkingArea_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[ParkingBlock] ADD  CONSTRAINT [DF_ParkingBlock_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[ParkingFeeConfig] ADD  CONSTRAINT [DF_ParkingFeeConfig_Is24H]  DEFAULT ((0)) FOR [Blog24H]
GO
ALTER TABLE [dbo].[ParkingGate] ADD  CONSTRAINT [DF_ParkingGate_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[ParkingLine] ADD  CONSTRAINT [DF_ParkingLine_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[ParkingLot] ADD  CONSTRAINT [DF_ParkingLot_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[ParkingType] ADD  CONSTRAINT [DF_ParkingType_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Partner] ADD  CONSTRAINT [DF_Partner_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Reader] ADD  CONSTRAINT [DF_Reader_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Sys_Function] ADD  CONSTRAINT [DF_Sys_Function_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Sys_Group] ADD  CONSTRAINT [DF_Sys_Group_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Sys_User] ADD  CONSTRAINT [DF_Sys_User_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsSetupFunction]  DEFAULT ((0)) FOR [IsSetupFunction]
GO
ALTER TABLE [dbo].[VehicleType] ADD  CONSTRAINT [DF_VehicleType_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[ParkingGate]  WITH CHECK ADD  CONSTRAINT [FK_ParkingGate_ParkingLot] FOREIGN KEY([ParkingLotID])
REFERENCES [dbo].[ParkingLot] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParkingGate] CHECK CONSTRAINT [FK_ParkingGate_ParkingLot]
GO
ALTER TABLE [dbo].[ParkingLine]  WITH CHECK ADD  CONSTRAINT [FK_ParkingLine_ParkingGate] FOREIGN KEY([ParkingGateID])
REFERENCES [dbo].[ParkingGate] ([ID])
GO
ALTER TABLE [dbo].[ParkingLine] CHECK CONSTRAINT [FK_ParkingLine_ParkingGate]
GO
/****** Object:  StoredProcedure [dbo].[spGetDateSystem]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nguyễn Văn Thao
-- Create date: 15/05/2014
-- Description:	Lay ngay gio he thong
-- =============================================
Create PROCEDURE [dbo].[spGetDateSystem]
AS
BEGIN
	select getdate() as SystemDate
END

GO
/****** Object:  StoredProcedure [dbo].[spGetEmptyPallet]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetEmptyPallet]	
@ParkingAreaID int = 0
AS
BEGIN
	select *
	,M1_Su = (select count(ID) from ParkingPallet where ParkingBlockID = a.ID and VehicleTypeID = 1)
	,M1_Se = (select count(ID) from ParkingPallet where ParkingBlockID = a.ID and VehicleTypeID = 2)
	 from ParkingBlock a where ParkingAreaID = @ParkingAreaID or @ParkingAreaID= 0
END

GO
/****** Object:  StoredProcedure [dbo].[spPermissionAndShortcutKey]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nguyễn Văn Thao
-- Create date: 16/05/2014
-- Description:	Lấy danh sách các quyền và phím tắt của người dùng tương ứng với quyền
-- =============================================
CREATE PROCEDURE [dbo].[spPermissionAndShortcutKey]
	@UserID int = 1
AS
BEGIN
	-- lấy ra các quyền của người dùng
	;WITH tmpFormAndFunction AS
	(
		SELECT b.ID, b.Code, b.ShiftKey, b.CtrlKey, b.AltKey, b.ShortcutKey
		FROM UserRightDistribution a with (nolock) 
			JOIN FormAndFunction b with (nolock) ON a.FormAndFunctionID = b.ID 
		WHERE a.UserID = @UserID 
			AND a.FormAndFunctionID NOT IN (SELECT t.FormAndFunctionID FROM UserGroupRightDistribution t with (nolock) JOIN Users u with (nolock) ON t.UserGroupID = u.UserGroupID WHERE u.ID = @UserID)
			
		UNION ALL
		
		SELECT b.ID, b.Code,b.ShiftKey, b.CtrlKey, b.AltKey, b.ShortcutKey
		FROM UserGroupRightDistribution a with (nolock)
			JOIN FormAndFunction b with (nolock) ON a.FormAndFunctionID = b.ID 
			JOIN Users c with (nolock) ON a.UserGroupID = c.UserGroupID 
			LEFT JOIN FormAndFunctionGroup d with (nolock) ON b.FormAndFunctionGroupID = d.ID
		WHERE c.ID = @UserID
			AND a.FormAndFunctionID NOT IN (SELECT u.FormAndFunctionID FROM UserRightDistribution u with (nolock) WHERE u.UserID = @UserID)
	)
	
	-- lấy ra các phím tắt trong quyền
	-- Note: không thay đổi THỨ TỰ và GIÁ TRỊ của a.ShortcutKey + a.ShiftKey + a.CtrltKey + a.AltKey AS ShorcutKey để đúng key nhập từ bàn phím
	SELECT a.Code, 
		a.ShortcutKey + a.ShiftKey + a.CtrltKey + a.AltKey AS ShortcutKey,
		CASE WHEN LEN(a.ShortcutKey) > 10 THEN '' ELSE a.strShiftKey + a.strCtrltKey + a.strAltKey + a.ShortcutKey END AS strShortcutKey 
	FROM
	(
		SELECT CASE WHEN tmp.ShiftKey = 1 THEN ', Shift' ELSE '' END AS ShiftKey,
				CASE WHEN tmp.ShiftKey = 1 THEN 'Shift + ' ELSE '' END AS strShiftKey,
				CASE WHEN tmp.CtrlKey = 1 THEN ', Control' ELSE '' END AS CtrltKey,
				CASE WHEN tmp.CtrlKey = 1 THEN 'Ctrl + ' ELSE '' END AS strCtrltKey,
				CASE WHEN tmp.AltKey = 1 THEN ', Alt' ELSE '' END AS AltKey,
				CASE WHEN tmp.AltKey = 1 THEN ' Alt + ' ELSE '' END AS strAltKey,
				ISNULL(tmp.ShortcutKey,'') ShortcutKey,
				tmp.Code
		FROM tmpFormAndFunction tmp
	) a
	
	UNION ALL -- lấy thêm cho quyền của menu chính ăn theo Group
	
	SELECT b.Code,'' AS ShortcutKey, '' AS strShortcutKey
    FROM FormAndFunctionGroup b with (nolock)
        LEFT JOIN FormAndFunctionGroup c with (nolock) ON b.ParentID = c.ID
    WHERE ISNULL(b.Code,'') <> ''
	
END


GO
/****** Object:  StoredProcedure [dbo].[spSearchAllForTrans]    Script Date: 16/06/2017 6:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nguyễn Văn Thao
-- Create date: 15-05-2014
-- Description:	<Search use for all table>
-- =============================================
create PROCEDURE [dbo].[spSearchAllForTrans]
	@sqlCommand nvarchar(max)
as
begin 	
	EXEC(@sqlCommand)
end
  
  --Select ID, Name,ParentID from FormAndFunctionGroup with(nolock) order by Name

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Trạng thái hoạt động 0: hoạt động, 1: ngừng hoạt động' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Camera"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 239
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ParkingLot"
            Begin Extent = 
               Top = 21
               Left = 327
               Bottom = 270
               Right = 497
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 3225
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCamera'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCamera'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[22] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ParkingArea"
            Begin Extent = 
               Top = 71
               Left = 707
               Bottom = 179
               Right = 858
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingLot"
            Begin Extent = 
               Top = 162
               Left = 494
               Bottom = 348
               Right = 646
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingBlock"
            Begin Extent = 
               Top = 5
               Left = 489
               Bottom = 152
               Right = 640
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingPallet"
            Begin Extent = 
               Top = 9
               Left = 271
               Bottom = 131
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Parking"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 329
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 14
         End
         Begin Table = "ParkingCard"
            Begin Extent = 
               Top = 161
               Left = 266
               Bottom = 288
               Right = 431
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column =' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParking'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' 1950
         Alias = 3090
         Table = 2655
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParking'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParking'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[32] 4[29] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ParkingArea"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 189
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingLot"
            Begin Extent = 
               Top = 13
               Left = 314
               Bottom = 211
               Right = 471
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3060
         Alias = 1875
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParkingArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParkingArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ParkingBlock"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 228
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingArea"
            Begin Extent = 
               Top = 12
               Left = 300
               Bottom = 209
               Right = 470
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingLot"
            Begin Extent = 
               Top = 6
               Left = 508
               Bottom = 215
               Right = 678
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParkingBlock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParkingBlock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ParkingCard"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 244
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingLot"
            Begin Extent = 
               Top = 24
               Left = 408
               Bottom = 154
               Right = 578
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParkingCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParkingCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[48] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ParkingPallet"
            Begin Extent = 
               Top = 27
               Left = 54
               Bottom = 189
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingBlock"
            Begin Extent = 
               Top = 56
               Left = 291
               Bottom = 188
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingArea"
            Begin Extent = 
               Top = 40
               Left = 552
               Bottom = 167
               Right = 703
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ParkingLot"
            Begin Extent = 
               Top = 32
               Left = 806
               Bottom = 140
               Right = 958
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 2025
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParkingPallet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vParkingPallet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ParkingLot"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 231
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Reader"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 227
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vReader'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vReader'
GO
USE [master]
GO
ALTER DATABASE [TPA.PLS] SET  READ_WRITE 
GO
