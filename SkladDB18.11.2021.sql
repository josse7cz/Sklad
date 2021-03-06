USE [SkladDB]
GO
/****** Object:  User [leos]    Script Date: 18.11.2021 20:07:19 ******/
CREATE USER [leos] FOR LOGIN [leos] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[item]    Script Date: 18.11.2021 20:07:19 ******/
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
/****** Object:  Table [dbo].[item_category]    Script Date: 18.11.2021 20:07:19 ******/
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
/****** Object:  Table [dbo].[receipt]    Script Date: 18.11.2021 20:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[receipt](
	[receipt_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
 CONSTRAINT [PK_receipt] PRIMARY KEY CLUSTERED 
(
	[receipt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sell_role]    Script Date: 18.11.2021 20:07:19 ******/
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
/****** Object:  Table [dbo].[sell_user]    Script Date: 18.11.2021 20:07:19 ******/
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

INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (9, N'Los ros', N'MAN', 2020, 15500000, 1, N'<p style="text-align: center;">Petelica</p>', N'43bfb3de-6348-4f02-affd-56dfcf7fe20d.jpg', 4)
INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (10, N'Octavia', N'Škoda', 2012, 150000, 1, N'<p>Prvn&iacute; dobr&yacute; auto co nejede</p>', N'90729d0b-085c-4f28-8660-2b20dc077911.jpg', 1)
INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (13, N'nevím', N'auto', 2000, 2000000, 1, N'<p>Old car</p>', N'aff52409-7833-497b-a7b5-aeee25f0cf6f.jpg', 1)
INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (23, N'wqe', N'qwe', 2000, 2, 1, NULL, NULL, 1)
INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (24, N'E62', N'BMW', 2012, 120000, 1, NULL, N'a8e6d57f-8e58-4acd-847f-cdc87c302f73.jpg', 3)
INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (25, N'E30', N'Bmw', 2012, 200000, 1, NULL, N'1eaad6d5-7668-40ca-9d98-96f2f1c6f2a8.jpg', 1)
INSERT [dbo].[item] ([id], [name], [producer], [yearProduct], [price], [quantity], [description], [imagename], [category_id]) VALUES (26, N'E62', N'BMWs', 2000, 200000, 1, N'<p><strong>Perfektn&iacute; vůz</strong></p>', N'14bfc13f-c242-4215-99ea-edc514fafbb7.jpg', 4)
SET IDENTITY_INSERT [dbo].[item] OFF
GO
SET IDENTITY_INSERT [dbo].[item_category] ON 

INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (1, N'osobní', N'Osobní automobily')
INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (2, N'nákladní', N'Nákladní automobily')
INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (3, N'sportovní', N'Sportovní automobily')
INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (4, N'super', N'supercars')
INSERT [dbo].[item_category] ([id], [categoryname], [categorydescription]) VALUES (5, N'šlapadlo', N'vlastní pohon')
SET IDENTITY_INSERT [dbo].[item_category] OFF
GO
SET IDENTITY_INSERT [dbo].[receipt] ON 

INSERT [dbo].[receipt] ([receipt_id], [user_id], [item_id]) VALUES (15, 1, 9)
INSERT [dbo].[receipt] ([receipt_id], [user_id], [item_id]) VALUES (16, 2, 23)
INSERT [dbo].[receipt] ([receipt_id], [user_id], [item_id]) VALUES (17, 1, 9)
INSERT [dbo].[receipt] ([receipt_id], [user_id], [item_id]) VALUES (18, 1, 23)
SET IDENTITY_INSERT [dbo].[receipt] OFF
GO
SET IDENTITY_INSERT [dbo].[sell_role] ON 

INSERT [dbo].[sell_role] ([role_id], [identificator], [role_description]) VALUES (1, N'seller', N'Prodavač')
INSERT [dbo].[sell_role] ([role_id], [identificator], [role_description]) VALUES (2, N'customer', N'Zákazník')
INSERT [dbo].[sell_role] ([role_id], [identificator], [role_description]) VALUES (3, N'admin', N'Admin')
SET IDENTITY_INSERT [dbo].[sell_role] OFF
GO
SET IDENTITY_INSERT [dbo].[sell_user] ON 

INSERT [dbo].[sell_user] ([user_id], [name], [surname], [login], [password], [role_id]) VALUES (1, N'Petr', N'Janda', N'pepa', N'pepa', 1)
INSERT [dbo].[sell_user] ([user_id], [name], [surname], [login], [password], [role_id]) VALUES (2, N'Josef', N'Novotný', N'josef', N'josef', 2)
INSERT [dbo].[sell_user] ([user_id], [name], [surname], [login], [password], [role_id]) VALUES (3, N'admin', N'admin', N'admin', N'admin', 3)
SET IDENTITY_INSERT [dbo].[sell_user] OFF
GO
ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_item_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[item_category] ([id])
GO
ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_item_category]
GO
ALTER TABLE [dbo].[receipt]  WITH CHECK ADD  CONSTRAINT [FK_receipt_item] FOREIGN KEY([item_id])
REFERENCES [dbo].[item] ([id])
GO
ALTER TABLE [dbo].[receipt] CHECK CONSTRAINT [FK_receipt_item]
GO
ALTER TABLE [dbo].[receipt]  WITH CHECK ADD  CONSTRAINT [FK_receipt_sell_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[sell_user] ([user_id])
GO
ALTER TABLE [dbo].[receipt] CHECK CONSTRAINT [FK_receipt_sell_user]
GO
ALTER TABLE [dbo].[sell_user]  WITH CHECK ADD  CONSTRAINT [FK_sell_user_sell_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[sell_role] ([role_id])
GO
ALTER TABLE [dbo].[sell_user] CHECK CONSTRAINT [FK_sell_user_sell_role]
GO
