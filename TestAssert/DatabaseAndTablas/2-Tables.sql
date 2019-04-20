USE [TestAssert]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 20/04/2019 12:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flight](
	[IdFlight] [int] IDENTITY(1,1) NOT NULL,
	[SourceCity] [varchar](100) NOT NULL,
	[DestinationCity] [varchar](100) NOT NULL,
	[DepartureDateTime] [datetime] NOT NULL,
	[PlaneNumber] [varchar](10) NOT NULL,
	[PilotName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFlight] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserFlight]    Script Date: 20/04/2019 12:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserFlight](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[DocumentType] [varchar](3) NOT NULL,
	[DocumentNumber] [int] NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserFlightRegister]    Script Date: 20/04/2019 12:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFlightRegister](
	[IdUserFlightRegister] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdFlight] [int] NOT NULL,
 CONSTRAINT [PK_UserFlightRegister] PRIMARY KEY CLUSTERED 
(
	[IdUserFlightRegister] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[UserFlightRegister]  WITH CHECK ADD  CONSTRAINT [FK__UserFligh__IdFli__145C0A3F] FOREIGN KEY([IdFlight])
REFERENCES [dbo].[Flight] ([IdFlight])
GO
ALTER TABLE [dbo].[UserFlightRegister] CHECK CONSTRAINT [FK__UserFligh__IdFli__145C0A3F]
GO
ALTER TABLE [dbo].[UserFlightRegister]  WITH CHECK ADD  CONSTRAINT [FK__UserFligh__IdUse__1367E606] FOREIGN KEY([IdUser])
REFERENCES [dbo].[UserFlight] ([IdUser])
GO
ALTER TABLE [dbo].[UserFlightRegister] CHECK CONSTRAINT [FK__UserFligh__IdUse__1367E606]
GO
