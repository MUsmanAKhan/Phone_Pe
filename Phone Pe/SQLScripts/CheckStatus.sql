USE [PhonePeDB]
GO

/****** Object:  Table [dbo].[CheckStatus]    Script Date: 6/24/2023 8:05:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CheckStatus](
	[CheckStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Success] [nvarchar](10) NULL,
	[Code] [nvarchar](30) NULL,
	[Message] [nvarchar](200) NULL,
	[MerchantId] [nvarchar](30) NULL,
	[MerchantTransactionId] [nvarchar](30) NULL,
	[TransactionId] [nvarchar](30) NULL,
	[Amount] [bigint] NULL,
	[State] [nvarchar](50) NULL,
	[ResponseCode] [nvarchar](30) NULL,
	[Type] [nvarchar](10) NULL,
	[Utr] [nvarchar](30) NULL,
	[PgTransactionId] [nvarchar](30) NULL,
	[PgServiceTransactionId] [nvarchar](30) NULL,
	[BankTransactionId] [nvarchar](30) NULL,
	[BankId] [nvarchar](30) NULL,
	[CardType] [nvarchar](30) NULL,
	[PgAuthorizationCode] [nvarchar](30) NULL,
	[Arn] [nvarchar](30) NULL,
	[Brn] [nvarchar](30) NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_CheckStatus] PRIMARY KEY CLUSTERED 
(
	[CheckStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


