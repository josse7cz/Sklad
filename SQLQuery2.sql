USE [master]
GO
/****** Object:  Database [SkladDB]    Script Date: 4.11.2021 22:22:57 ******/
CREATE DATABASE [SkladDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SkladDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SkladDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SkladDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SkladDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SkladDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SkladDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SkladDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SkladDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SkladDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SkladDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SkladDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SkladDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SkladDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SkladDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SkladDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SkladDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SkladDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SkladDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SkladDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SkladDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SkladDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SkladDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SkladDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SkladDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SkladDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SkladDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SkladDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SkladDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SkladDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SkladDB] SET  MULTI_USER 
GO
ALTER DATABASE [SkladDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SkladDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SkladDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SkladDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SkladDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SkladDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SkladDB] SET QUERY_STORE = OFF
GO
USE [SkladDB]
GO
/****** Object:  User [leos]    Script Date: 4.11.2021 22:22:57 ******/
CREATE USER [leos] FOR LOGIN [leos] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[item]    Script Date: 4.11.2021 22:22:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[producer] [varchar](150) NOT NULL,
	[yearProduct] [int] NOT NULL,
	[price] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[description] [varchar](150) NULL,
	[imagename] [varchar](150) NULL,
	[category_id] [int] NOT NULL,
 CONSTRAINT [PK_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[item_category]    Script Date: 4.11.2021 22:22:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[item_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categoryname] [varchar](50) NULL,
	[categorydescription] [varchar](200) NULL,
 CONSTRAINT [PK_item_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sell_role]    Script Date: 4.11.2021 22:22:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sell_role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[identificator] [varchar](50) NOT NULL,
	[role_description] [varchar](50) NULL,
 CONSTRAINT [PK_sell_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sell_user]    Script Date: 4.11.2021 22:22:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sell_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_sell_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[item] ON 
GO
INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (9, N'La VAnmos', N'MAN', 2020, 15500000, 1, N'<p style="text-align: center;">Petelica</p>', N'43bfb3de-6348-4f02-affd-56dfcf7fe20d.jpg', 4)
GO
INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (10, N'Octavia', N'Škoda', 2012, 150000, 1, N'<p>Prvn&iacute; dobr&yacute; auto co nejede</p>', N'90729d0b-085c-4f28-8660-2b20dc077911.jpg', 1)
GO
INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (12, N'E62', N'BMW', 2019, 2000000, 1, N'<h1>best car fot life</h1>', N'e57e2e2c-f3c4-4084-ac04-e074c5b4fafb.jpg', 3)
GO
SET IDENTITY_INSERT [dbo].[item] OFF
GO
SET IDENTITY_INSERT [dbo].[item_category] ON 
GO
INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (1, N'osobní', N'Osobní automobily')
GO
INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (2, N'nákladní', N'Nákladní automobily')
GO
INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (3, N'sportovní', N'Sportovní automobily')
GO
INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (4, N'super', N'supercars')
GO
INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (5, N'šlapadlo', N'vlastní pohon')
GO
SET IDENTITY_INSERT [dbo].[item_category] OFF
GO
SET IDENTITY_INSERT [dbo].[sell_role] ON 
GO
INSERT [dbo].[sell_role] ([role_id], [identificator], [role_description]) VALUES (1, N'seller', N'Prodavač')
GO
INSERT [dbo].[sell_role] ([role_id], [identificator], [role_description]) VALUES (2, N'customer', N'Zákazník')
GO
INSERT [dbo].[sell_role] ([role_id], [identificator], [role_description]) VALUES (3, N'admin', N'Admin')
GO
SET IDENTITY_INSERT [dbo].[sell_role] OFF
GO
SET IDENTITY_INSERT [dbo].[sell_user] ON 
GO
INSERT [dbo].[sell_user] ([user_id], [name], [surname], [login], [password], [role_id]) VALUES (1, N'Petr', N'Janda', N'pepa', N'pepa', 1)
GO
INSERT [dbo].[sell_user] ([user_id], [name], [surname], [login], [password], [role_id]) VALUES (2, N'Josef', N'Novotný', N'josef', N'josef', 2)
GO
INSERT [dbo].[sell_user] ([user_id], [name], [surname], [login], [password], [role_id]) VALUES (3, N'admin', N'admin', N'admin', N'admin', 3)
GO
SET IDENTITY_INSERT [dbo].[sell_user] OFF
GO
ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_item_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[item_category] ([id])
GO
ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_item_category]
GO
ALTER TABLE [dbo].[sell_user]  WITH CHECK ADD  CONSTRAINT [FK_sell_user_sell_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[sell_role] ([role_id])
GO
ALTER TABLE [dbo].[sell_user] CHECK CONSTRAINT [FK_sell_user_sell_role]
GO
USE [master]
GO
ALTER DATABASE [SkladDB] SET  READ_WRITE 
GO
