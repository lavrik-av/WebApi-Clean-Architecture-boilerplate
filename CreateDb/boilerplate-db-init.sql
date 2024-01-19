USE [master]
GO
/****** Object:  Database [boilerplate_db]    Script Date: 12/21/2023 5:23:48 PM ******/
CREATE DATABASE [boilerplate_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'boilerplate_db', FILENAME = N'/var/opt/mssql/data/boilerplate_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'boilerplate_db_log', FILENAME = N'/var/opt/mssql/data/boilerplate_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [boilerplate_db] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [boilerplate_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [boilerplate_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [boilerplate_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [boilerplate_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [boilerplate_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [boilerplate_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [boilerplate_db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [boilerplate_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [boilerplate_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [boilerplate_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [boilerplate_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [boilerplate_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [boilerplate_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [boilerplate_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [boilerplate_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [boilerplate_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [boilerplate_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [boilerplate_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [boilerplate_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [boilerplate_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [boilerplate_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [boilerplate_db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [boilerplate_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [boilerplate_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [boilerplate_db] SET  MULTI_USER 
GO
ALTER DATABASE [boilerplate_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [boilerplate_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [boilerplate_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [boilerplate_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [boilerplate_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [boilerplate_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [boilerplate_db] SET QUERY_STORE = ON
GO
ALTER DATABASE [boilerplate_db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [boilerplate_db]
GO

/****** Object:  Table [dbo].[Entities]    Script Date: 12/21/2023 5:23:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entities](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Sku] [nvarchar](450) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Published] [bit] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Entities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EntityMedia]    Script Date: 12/21/2023 5:23:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntityMedia](
	[Id] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[ProductsId] [uniqueidentifier] NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	[ImageType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EntityMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT [dbo].[Entities] ([Id], [Name], [Description], [Sku], [Price], [Published], [Created], [Quantity]) VALUES (N'b564f621-dbec-4cdf-4c2c-08dbec41cd38', N'Test Entity', N'Description for Test Entity', N'SKU-01', CAST(0.99 AS Decimal(18, 2)), 1, CAST(N'2023-09-04T10:32:00.2670000' AS DateTime2), 1)
GO

INSERT [dbo].[Entities] ([Id], [Name], [Description], [Sku], [Price], [Published], [Created], [Quantity]) VALUES (N'f5e57ab5-f97f-4906-0da4-08dbec45717d', N'Test Entity II', N'Description for Test Entity', N'SKU-T', CAST(777.99 AS Decimal(18, 2)), 1, CAST(N'2023-11-23T18:58:54.9961072' AS DateTime2), 5)
GO

ALTER TABLE [dbo].[EntityMedia]  WITH CHECK ADD  CONSTRAINT [FK_EntityMedia_Entities_ProductsId] FOREIGN KEY([ProductsId])
REFERENCES [dbo].[Entities] ([Id])
GO

ALTER TABLE [dbo].[EntityMedia] CHECK CONSTRAINT [FK_EntityMedia_Entities_ProductsId]
GO

USE [master]
GO

ALTER DATABASE [boilerplate_db] SET  READ_WRITE 
GO
