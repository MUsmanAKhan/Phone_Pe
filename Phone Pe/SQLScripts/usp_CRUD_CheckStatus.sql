USE [PhonePeDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_CRUD_CheckStatus]    Script Date: 6/24/2023 8:07:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE Procedure  [dbo].[usp_CRUD_CheckStatus]
(
@CheckStatusId int,
@Success nvarchar(10) = NULL,
@Code nvarchar(30) = NULL,
@Message nvarchar(200) = NULL,
@MerchantId nvarchar(30) = NULL,
@MerchantTransactionId nvarchar(30) = NULL,
@TransactionId nvarchar(30) = NULL,
@Amount bigint = NULL,
@State nvarchar(50) = NULL,
@ResponseCode nvarchar(30) = NULL,
@Type nvarchar(10) = NULL,
@Utr nvarchar(30) = NULL,
@PgTransactionId nvarchar(30) = NULL,
@PgServiceTransactionId nvarchar(30) = NULL,
@BankTransactionId nvarchar(30) = NULL,
@BankId nvarchar(30) = NULL,
@CardType nvarchar(30) = NULL,
@PgAuthorizationCode nvarchar(30) = NULL,
@Arn nvarchar(30) = NULL,
@Brn nvarchar(30) = NULL,
@Action varchar(50)
)
AS 
BEGIN
   SET NOCOUNT ON;
	IF(@Action='insert')
      BEGIN
         INSERT INTO CheckStatus(Success,Code,Message,MerchantId,MerchantTransactionId,TransactionId,Amount,State,ResponseCode,Type,
		 Utr,PgTransactionId,PgServiceTransactionId,BankTransactionId,BankId,CardType,PgAuthorizationCode,Arn,Brn,CreatedOn)

	     VALUES(@Success,@Code,@Message,@MerchantId,@MerchantTransactionId,@TransactionId,@Amount,@State,@ResponseCode,@Type,@Utr,
		 @PgTransactionId,@PgServiceTransactionId,@BankTransactionId,@BankId,@CardType,@PgAuthorizationCode,@Arn,@Brn,GETDATE())

	     SELECT @@IDENTITY AS CheckStatusId
	  END
	--IF(@Action='update')
	--  BEGIN
		
	--  END
	 SET NOCOUNT OFF;
end    
  
  
GO


