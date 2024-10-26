USE [master]
GO
/****** Object:  Database [KoiStoreDB]    Script Date: 26-Oct-24 4:53:56 PM ******/
CREATE DATABASE [KoiStoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KoiStoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\KoiStoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KoiStoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\KoiStoreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [KoiStoreDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KoiStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KoiStoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KoiStoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KoiStoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KoiStoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KoiStoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [KoiStoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KoiStoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KoiStoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KoiStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KoiStoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KoiStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KoiStoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KoiStoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KoiStoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KoiStoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KoiStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KoiStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KoiStoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KoiStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KoiStoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KoiStoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KoiStoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KoiStoreDB] SET RECOVERY FULL 
GO
ALTER DATABASE [KoiStoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [KoiStoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KoiStoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KoiStoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KoiStoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KoiStoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KoiStoreDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'KoiStoreDB', N'ON'
GO
ALTER DATABASE [KoiStoreDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [KoiStoreDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [KoiStoreDB]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Feedback_id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [int] NULL,
	[Order_detail_id] [int] NULL,
	[Description] [varchar](250) NULL,
	[Create_at] [datetime] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[Feedback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiFarm]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiFarm](
	[Farm_id] [int] IDENTITY(1,1) NOT NULL,
	[Farm_name] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Description] [varchar](250) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_KoiFarm] PRIMARY KEY CLUSTERED 
(
	[Farm_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiProfile]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiProfile](
	[Koi_id] [int] NOT NULL,
	[Type_id] [int] NULL,
	[Farm_id] [int] NULL,
	[Koi_name] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[Size] [float] NULL,
	[Price] [float] NULL,
	[Description] [varchar](250) NULL,
	[Image] [varchar](250) NULL,
	[Create_at] [datetime] NULL,
	[Update_at] [datetime] NULL,
	[Rating_average_value] [float] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_KoiProfile] PRIMARY KEY CLUSTERED 
(
	[Koi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiType]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiType](
	[Type_id] [int] IDENTITY(1,1) NOT NULL,
	[Type_name] [varchar](50) NULL,
	[Description] [varchar](250) NULL,
	[Create_at] [datetime] NULL,
	[Update_at] [datetime] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_KoiType] PRIMARY KEY CLUSTERED 
(
	[Type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Order_id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [int] NULL,
	[Create_at] [datetime] NULL,
	[Total] [float] NULL,
	[Delivery_address] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Order_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[Order_id] [int] NULL,
	[User_id] [int] NULL,
	[Koi_id] [int] NULL,
	[Quantity] [int] NULL,
	[Order_detail_type] [varchar](50) NULL,
	[Total] [float] NULL,
	[Create_at] [datetime] NULL,
	[Update_at] [datetime] NULL,
	[Start_at] [datetime] NULL,
	[End_at] [datetime] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Order_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[Rate_id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [int] NULL,
	[Order_detail_id] [int] NULL,
	[Rating_value] [float] NULL,
	[Description] [varchar](250) NULL,
	[Create_at] [datetime] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[Rate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Role_id] [int] IDENTITY(1,1) NOT NULL,
	[Rolename] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role_id] [int] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 26-Oct-24 4:53:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[Profile_id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [int] NULL,
	[Firstname] [varchar](50) NULL,
	[Lastname] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phonenumber] [varchar](10) NULL,
	[Address] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[DateofBirth] [varchar](50) NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[Profile_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_OrderDetail] FOREIGN KEY([Order_detail_id])
REFERENCES [dbo].[OrderDetail] ([Order_detail_id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_OrderDetail]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_User] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([User_id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_User]
GO
ALTER TABLE [dbo].[KoiProfile]  WITH CHECK ADD  CONSTRAINT [FK_KoiProfile_KoiFarm] FOREIGN KEY([Farm_id])
REFERENCES [dbo].[KoiFarm] ([Farm_id])
GO
ALTER TABLE [dbo].[KoiProfile] CHECK CONSTRAINT [FK_KoiProfile_KoiFarm]
GO
ALTER TABLE [dbo].[KoiProfile]  WITH CHECK ADD  CONSTRAINT [FK_KoiProfile_KoiType] FOREIGN KEY([Type_id])
REFERENCES [dbo].[KoiType] ([Type_id])
GO
ALTER TABLE [dbo].[KoiProfile] CHECK CONSTRAINT [FK_KoiProfile_KoiType]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([User_id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_KoiProfile] FOREIGN KEY([Koi_id])
REFERENCES [dbo].[KoiProfile] ([Koi_id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_KoiProfile]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([Order_id])
REFERENCES [dbo].[Order] ([Order_id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_User] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([User_id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_User]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_OrderDetail] FOREIGN KEY([Order_detail_id])
REFERENCES [dbo].[OrderDetail] ([Order_detail_id])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_OrderDetail]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_User] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([User_id])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([Role_id])
REFERENCES [dbo].[Role] ([Role_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_User] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([User_id])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_User]
GO
USE [master]
GO
ALTER DATABASE [KoiStoreDB] SET  READ_WRITE 
GO
