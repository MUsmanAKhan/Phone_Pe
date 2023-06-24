USE [PhonePeDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_CRUD_Refunds]    Script Date: 6/24/2023 8:08:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE Procedure  [dbo].[usp_CRUD_Refunds]    
(
@RefundId int,
@Success nvarchar(10) = NULL,
@Code nvarchar(30) = NULL,
@Message nvarchar(200) = NULL,
@MerchantId nvarchar(30) = NULL,
@MerchantTransactionId nvarchar(30) = NULL,
@TransactionId nvarchar(30) = NULL,
@Amount bigint = NULL,
@State nvarchar(50) = NULL,
@ResponseCode nvarchar(30) = NULL,
@Action varchar(50)
)
AS 
BEGIN
   SET NOCOUNT ON;
	IF(@Action='insert')
      BEGIN
         INSERT INTO Refund(Success,Code,[Message],MerchantId,MerchantTransactionId,TransactionId,Amount,[State],ResponseCode,CreatedOn)
	     VALUES(@Success,@Code,@Message,@MerchantId,@MerchantTransactionId,@TransactionId,@Amount,@State,@ResponseCode,GETDATE())
	     SELECT @@IDENTITY AS RefundId
	  END
	--IF(@Action='update')
	--  BEGIN
		
	--  END
	 SET NOCOUNT OFF;
end    
  
  
GO


