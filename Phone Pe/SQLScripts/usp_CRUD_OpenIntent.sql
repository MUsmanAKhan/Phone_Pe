USE [PhonePeDB]
GO

/****** Object:  StoredProcedure [dbo].[usp_CRUD_OpenIntent]    Script Date: 6/24/2023 8:07:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE Procedure  [dbo].[usp_CRUD_OpenIntent]    
(
@OpenIntentId int,
@Success nvarchar(10) = NULL,
@Code nvarchar(30) = NULL,
@Message nvarchar(200) = NULL,
@MerchantId nvarchar(30) = NULL,
@MerchantTransactionId nvarchar(30) = NULL,
@Type nvarchar(20) = NULL,
@QrData nvarchar(MAX) = NULL,
@QrIntentUrl nvarchar(500) = NULL,
@PayPageURL nvarchar(500) = NULL,
@PayPageMethod nvarchar(20) = NULL,
@Action varchar(50)
)
AS 
BEGIN
   SET NOCOUNT ON;
	IF(@Action='insert')
      BEGIN
         INSERT INTO OpenIntent(Success,Code,[Message],MerchantId,MerchantTransactionId,[Type],QrData,QrIntentUrl,PayPageURL,PayPageMethod,CreatedOn)
	     VALUES(@Success,@Code,@Message,@MerchantId,@MerchantTransactionId,@Type,@QrData,@QrIntentUrl,@PayPageURL,@PayPageMethod,GETDATE())
	     SELECT @@IDENTITY AS OpenIntentId
	  END
	--IF(@Action='update')
	--  BEGIN
		
	--  END
	 SET NOCOUNT OFF;
end    
  
  
GO


