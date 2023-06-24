USE [PhonePeDB]
GO

/****** Object:  Table [dbo].[OpenIntent]    Script Date: 6/24/2023 8:06:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OpenIntent](
	[OpenIntentId] [int] IDENTITY(1,1) NOT NULL,
	[Success] [nvarchar](10) NULL,
	[Code] [nvarchar](30) NULL,
	[Message] [nvarchar](200) NULL,
	[MerchantId] [nvarchar](30) NULL,
	[MerchantTransactionId] [nvarchar](30) NULL,
	[Type] [nvarchar](20) NULL,
	[QrData] [nvarchar](max) NULL,
	[QrIntentUrl] [nvarchar](500) NULL,
	[PayPageURL] [nvarchar](500) NULL,
	[PayPageMethod] [nvarchar](20) NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_OpenIntent] PRIMARY KEY CLUSTERED 
(
	[OpenIntentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


