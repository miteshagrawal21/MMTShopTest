# MMTShopTest
# MMT Shop Test
# Below is the script to create database, tables, stored precedures and inserting test data into the tables
#----------------------------------------------------------------------------------------------------------

--MMTShop


--==========================
--Scirpt to Create DATABASE
--==========================

USE [master]
GO

/****** Object:  Database [MMTShop]    Script Date: 15/07/2021 19:36:49 ******/
CREATE DATABASE [MMTShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MMTShop', FILENAME = N'C:\Users\mitesh\MMTShop.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MMTShop_log', FILENAME = N'C:\Users\mitesh\MMTShop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [MMTShop] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MMTShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MMTShop] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MMTShop] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MMTShop] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MMTShop] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MMTShop] SET ARITHABORT OFF 
GO

ALTER DATABASE [MMTShop] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MMTShop] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MMTShop] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MMTShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MMTShop] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MMTShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MMTShop] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MMTShop] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MMTShop] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MMTShop] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MMTShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MMTShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MMTShop] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MMTShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MMTShop] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MMTShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MMTShop] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MMTShop] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [MMTShop] SET  MULTI_USER 
GO

ALTER DATABASE [MMTShop] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MMTShop] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MMTShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MMTShop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [MMTShop] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MMTShop] SET  READ_WRITE 
GO



--=============
--Producst Table
--=============
USE [MMTShop]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 14/07/2021 18:48:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--====================================
--Insert Records into Products Table
--====================================
Insert into Products Values('1000abc','Sofa','Living room sofa',924.50)
Insert into Products Values('1000abc','Bed','Divan King size bed',1104.99)

Insert into Products Values('2100dsef','Lawnmower','Spear & Jackson 44cm Cordless 2 Batteries - 36V',225.00)
Insert into Products Values('2100dsef','Hedge trimmers','Challenge 55cm Corded Hedge Trimmer - 550W',30.50)

Insert into Products Values('3010fdb','Laptop','Lenovo G50 Inter Core i5',535.50)
Insert into Products Values('3010fdb','Television','Samsung smart tv 40 inch',1050.49)

Insert into Products Values('4030xfe','Fitness Tracker','Apple Watch S3 2018 GPS 38mm White',199.00)
Insert into Products Values('4030xfe','Trademill','Dynamax RunningPad Folding Treadmill',499.99)

Insert into Products Values('5100pre','Play house','Chad Valley Magic Unicorn Playhouse',50.00)
Insert into Products Values('5100pre','Trampoline','Sportspower 8ft Outdoor Kids Trampoline with Enclosure',130.00)


--=============
--Category Table
--=============

USE [MMTShop]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 14/07/2021 18:49:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[SKU] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--====================================
--Insert Records into Category Table
--====================================

Insert into Category Values('Home','1000abc')
Insert into Category Values('Garden','2100dsef')
Insert into Category Values('Electronics','3010fdb')
Insert into Category Values('Fitness','4030xfe')
Insert into Category Values('Toys','5100pre')


--===================
--PromotionMaster Table
--===================

USE [MMTShop]
GO

/****** Object:  Table [dbo].[PromotionMaster]    Script Date: 14/07/2021 18:50:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PromotionMaster](
	[PromotionId] [int] IDENTITY(1,1) NOT NULL,
	[PromotionType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PromotionMaster] PRIMARY KEY CLUSTERED 
(
	[PromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--=========================================
--Insert Records into PromotionMaster Table
--=========================================
Insert into PromotionMaster Values('Featured products')



--===================
--Promotions Table
--===================

USE [MMTShop]
GO

/****** Object:  Table [dbo].[Promotions]    Script Date: 14/07/2021 18:52:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Promotions](
	[PromoId] [int] NOT NULL,
	[PromotionTypeId] [int] NOT NULL
) ON [PRIMARY]

GO



--====================================
--Insert Records into Promotions Table
--====================================
Insert into Promotions Values(1,1)
Insert into Promotions Values(2,1)
Insert into Promotions Values(3,1)



--===========================
--Stored Procedures creation
--===========================

--AvailableCategory
--=================
USE [MMTShop]
GO
/****** Object:  StoredProcedure [dbo].[AvailableCategory]    Script Date: 15/07/2021 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[AvailableCategory]
As
Begin
SELECT CategoryName FROM Category
End


--FeaturedProducts
--=================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[FeaturedProducts]
As
Begin
	Select Id
	  ,SKU
      ,Name
      ,[Description]
      ,Price
	From Products 
	Where  SUBSTRING(SKU,1,1) IN 
	(
		Select PromoId from Promotions
	)
End


--spProductsByCategory
--====================

USE [MMTShop]
GO
/****** Object:  StoredProcedure [dbo].[spProductsByCategory]    Script Date: 15/07/2021 19:34:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spProductsByCategory]
@CategoryId int
As
Begin
	Select Id
	  ,SKU
      ,Name
      ,[Description]
      ,Price
	From Products 
	Where  SUBSTRING(SKU,1,1) = @CategoryId
End
--==========================================================================


      
	  

