using Phone_Pe.DataAccessLayer;
using Phone_Pe.Models;
using Phone_Pe.Utility;

namespace Phone_Pe.BusinessLayer
{
    public class bRefunds
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly dbRefunds _dbRefunds;
        private readonly PhonePeAPIRequester _requester;
        private readonly string _saltKey;
        public bRefunds(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
            _dbRefunds = new dbRefunds(configuration);
            _requester = new PhonePeAPIRequester(configuration, logger);
            _saltKey = configuration.GetValue<string>("MerchantSettings:SaltKey");
        }
        public async Task<RefundResponse> PostRefund(RefundRequest refundRequest)
        {
            try
            {
                Refund refund = new(_configuration)
                {
                    originalTransactionId = refundRequest.OriginalTransactionId,
                    merchantTransactionId = refundRequest.MerchantTransactionId,
                    amount = refundRequest.Amount
                };

                string requestJSON = Newtonsoft.Json.JsonConvert.SerializeObject(refund);
                Base64Converter base64Converter = new Base64Converter();
                string requestBody = base64Converter.Base64Encode(requestJSON);
                string requestHeader = requestBody + "/pg/v1/refund" + _saltKey;

                HashConverter computeHash = new HashConverter();
                var headerHash = computeHash.Sha256HashEncode(requestHeader) + "###1";

                var result = await _requester.RequestRefundAsync(headerHash, requestBody);
                if (result.data != null && result.data.merchantId != null)
                {
                    //Save to DB
                    _dbRefunds.PostRefund(result);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("bRefunds.PostRefund - " + ex.Message.ToString());
                return new() { code = "500", success = "false", message = "Something went wrong!" };
            }
        }
    }
}
