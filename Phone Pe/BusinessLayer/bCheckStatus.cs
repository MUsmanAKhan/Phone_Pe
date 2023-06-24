using Phone_Pe.DataAccessLayer;
using Phone_Pe.Models;
using Phone_Pe.Utility;

namespace Phone_Pe.BusinessLayer
{
    public class bCheckStatus
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly dbCheckStatus _dbCheckStatus;
        private readonly PhonePeAPIRequester _requester;
        private readonly string _saltKey;
        public bCheckStatus(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
            _dbCheckStatus = new dbCheckStatus(configuration);
            _requester = new PhonePeAPIRequester(configuration, logger);
            _saltKey = configuration.GetValue<string>("MerchantSettings:SaltKey");
        }
        public async Task<CheckStatusResponse> CheckStatus(string MerchantTransactionId)
        {
            try
            {
                string MerchantId = _configuration.GetValue<string>("MerchantSettings:MerchantId");
                string requestHeader = "/pg/v1/status/" + MerchantId + "/" + MerchantTransactionId + _saltKey;
                HashConverter computeHash = new HashConverter();
                var headerHash = computeHash.Sha256HashEncode(requestHeader) + "###1";

                var result = await _requester.CheckStatusAsync(headerHash, MerchantId, MerchantTransactionId);
                if (result.data != null && result.data.merchantId != null)
                {
                    //Save to DB
                    _dbCheckStatus.CheckStatus(result);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("bCheckStatus.CheckStatus - " + ex.Message.ToString());
                return new() { code = "500", success = "false", message = "Something went wrong!" };
            }
        }
    }
}
