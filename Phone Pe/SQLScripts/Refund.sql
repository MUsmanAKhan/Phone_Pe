USE [PhonePeDB]
GO

/****** Object:  Table [dbo].[Refund]    Script Date: 6/24/2023 8:06:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Refund](
	[RefundId] [int] IDENTITY(1,1) NOT NULL,
	[Success] [nvarchar](10) NULL,
	[Code] [nvarchar](30) NULL,
	[Message] [nvarchar](200) NULL,
	[MerchantId] [nvarchar](30) NULL,
	[MerchantTransactionId] [nvarchar](30) NULL,
	[TransactionId] [nvarchar](30) NULL,
	[Amount] [bigint] NULL,
	[State] [nvarchar](50) NULL,
	[ResponseCode] [nvarchar](30) NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_Refund] PRIMARY KEY CLUSTERED 
(
	[RefundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


