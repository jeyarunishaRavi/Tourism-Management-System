USE [tourismdb]
GO
/****** Object:  Table [dbo].[Booking_Details]    Script Date: 13-10-2026 11:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Booking_Details](
	[bid] [int] NULL,
	[oid] [varchar](50) NULL,
	[cid] [varchar](50) NULL,
	[pid] [varchar](50) NULL,
	[date] [varchar](50) NULL,
	[persons] [int] NULL,
	[amount] [decimal](18, 0) NULL,
	[bookingdate] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer_details]    Script Date: 13-10-2026 11:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer_details](
	[cid] [int] NULL,
	[uid] [int] NULL,
	[name] [varchar](50) NULL,
	[contact] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[address] [varchar](max) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Destination]    Script Date: 13-10-2026 11:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Destination](
	[DestinationID] [int] NULL,
	[DestinationName] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[District] [varchar](100) NULL,
	[Description] [varchar](500) NULL,
	[EntryFee] [decimal](10, 2) NULL,
	[Photo] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hotels]    Script Date: 13-10-2026 11:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hotels](
	[hid] [int] NULL,
	[HotelName] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[District] [varchar](100) NULL,
	[Description] [varchar](500) NULL,
	[MinRoomRent] [decimal](10, 2) NULL,
	[Photo] [varchar](max) NULL,
	[DestinationName] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login_details]    Script Date: 13-10-2026 11:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login_details](
	[uid] [int] NULL,
	[username] [varchar](30) NULL,
	[password] [varchar](30) NULL,
	[usertype] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[operator_details]    Script Date: 13-10-2026 11:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[operator_details](
	[oid] [int] NULL,
	[uid] [int] NULL,
	[company_name] [varchar](max) NULL,
	[address] [varchar](max) NULL,
	[contact] [varchar](12) NULL,
	[email] [varchar](50) NULL,
	[operator_name] [varchar](50) NULL,
	[operator_email] [varchar](50) NULL,
	[status] [varchar](50) NULL,
	[logo] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[package_Details]    Script Date: 13-10-2026 11:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[package_Details](
	[pid] [int] NULL,
	[oid] [varchar](50) NULL,
	[packagename] [varchar](max) NULL,
	[DestinationName] [varchar](max) NULL,
	[Details] [varchar](max) NULL,
	[Amount] [decimal](18, 0) NULL,
	[poster] [varchar](max) NULL,
	[hotelname] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Booking_Details] ([bid], [oid], [cid], [pid], [date], [persons], [amount], [bookingdate]) VALUES (101, N'101', N'101', N'101', N'15-10-2026', 10, CAST(25000 AS Decimal(18, 0)), N'15-10-2026')
GO
INSERT [dbo].[Booking_Details] ([bid], [oid], [cid], [pid], [date], [persons], [amount], [bookingdate]) VALUES (102, N'101', N'101', N'101', N'13 October 2026', 50, CAST(125000 AS Decimal(18, 0)), N'13-10-2026')
GO
INSERT [dbo].[Customer_details] ([cid], [uid], [name], [contact], [email], [address], [username], [password]) VALUES (101, 102, N'jershin', N'9995812756', N'jershin@gmail.com', N'kanyakumari', N'jershin', N'pwd')
GO
INSERT [dbo].[Destination] ([DestinationID], [DestinationName], [State], [District], [Description], [EntryFee], [Photo]) VALUES (101, N'ooty', N'tamilnadu', N'ooty', N'hill station', CAST(100.00 AS Decimal(10, 2)), N'101')
GO
INSERT [dbo].[Destination] ([DestinationID], [DestinationName], [State], [District], [Description], [EntryFee], [Photo]) VALUES (102, N'kovalam', N'kerala', N'trivandrum', N'beach', CAST(0.00 AS Decimal(10, 2)), N'102.jpg')
GO
INSERT [dbo].[Destination] ([DestinationID], [DestinationName], [State], [District], [Description], [EntryFee], [Photo]) VALUES (103, N'leimore beach', N'tamilnadu', N'kanyakumari', N'beach in kanyakumari', CAST(50.00 AS Decimal(10, 2)), N'103.jpg')
GO
INSERT [dbo].[hotels] ([hid], [HotelName], [State], [District], [Description], [MinRoomRent], [Photo], [DestinationName]) VALUES (101, N'taj', N'tamilnadu', N'ooty', N'5 star hotel', CAST(1000.00 AS Decimal(10, 2)), N'101.jpg', N'ooty')
GO
INSERT [dbo].[hotels] ([hid], [HotelName], [State], [District], [Description], [MinRoomRent], [Photo], [DestinationName]) VALUES (102, N'raviz', N'kerala', N'trivandrum', N'5 star', CAST(3000.00 AS Decimal(10, 2)), N'102.jpg', N'kovalam')
GO
INSERT [dbo].[Login_details] ([uid], [username], [password], [usertype]) VALUES (101, N'jose', N'pwd', N'operator')
GO
INSERT [dbo].[Login_details] ([uid], [username], [password], [usertype]) VALUES (102, N'jershin', N'pwd', N'customer')
GO
INSERT [dbo].[operator_details] ([oid], [uid], [company_name], [address], [contact], [email], [operator_name], [operator_email], [status], [logo]) VALUES (101, 101, N'omega tours', N'nagercoil', N'9995812876', N'omega@gmail.com', N'jose', N'9846156989', N'Active', N'')
GO
INSERT [dbo].[package_Details] ([pid], [oid], [packagename], [DestinationName], [Details], [Amount], [poster], [hotelname]) VALUES (101, N'101', N'ooty 2 day package', N'taj', N'3 day 2 nights sight seeing included', CAST(2500 AS Decimal(18, 0)), N'101.jpg', N'taj')
GO
INSERT [dbo].[package_Details] ([pid], [oid], [packagename], [DestinationName], [Details], [Amount], [poster], [hotelname]) VALUES (102, N'101', N'south package', N'raviz', N'3 day 2 nights', CAST(5000 AS Decimal(18, 0)), N'102.png', N'raviz')
GO
INSERT [dbo].[package_Details] ([pid], [oid], [packagename], [DestinationName], [Details], [Amount], [poster], [hotelname]) VALUES (103, N'101', N'new package', N'taj', N'3 days 2 nights', CAST(1500 AS Decimal(18, 0)), N'103.jpg', N'taj')
GO
ALTER TABLE [dbo].[Destination] ADD  DEFAULT ((0)) FOR [EntryFee]
GO
