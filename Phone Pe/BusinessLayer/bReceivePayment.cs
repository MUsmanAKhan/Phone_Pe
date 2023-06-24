using Phone_Pe.DataAccessLayer;
using Phone_Pe.Models;
using Phone_Pe.Utility;

namespace Phone_Pe.BusinessLayer
{
    public class bReceivePayment
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly dbReceivePayment _dbReceivePayment;
        private readonly PhonePeAPIRequester _requester;
        private readonly string _saltKey;
        public bReceivePayment(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
            _dbReceivePayment = new dbReceivePayment(configuration);
            _requester = new PhonePeAPIRequester(configuration, logger);
            _saltKey = configuration.GetValue<string>("MerchantSettings:SaltKey");
        }

        public async Task<OpenIntentResponse> PostCollect(CollectRequest collectRequest)
        {
            try
            {
                Collect collect = new(_configuration)
                {
                    merchantTransactionId = collectRequest.MerchantTransactionId,
                    amount = collectRequest.Amount,
                    paymentInstrument = new() { vpa = collectRequest.Vpa }
                };

                string requestJSON = Newtonsoft.Json.JsonConvert.SerializeObject(collect);
                Base64Converter base64Converter = new Base64Converter();
                string requestBody = base64Converter.Base64Encode(requestJSON);
                string requestHeader = requestBody + "/pg/v1/pay" + _saltKey;

                HashConverter computeHash = new HashConverter();
                var headerHash = computeHash.Sha256HashEncode(requestHeader) + "###1";

                var result = await _requester.RequestPaymentAsync(headerHash, requestBody);

                if (result.data != null && result.data.merchantId != null)
                {
                    //Save to DB
                    _dbReceivePayment.PostOpenIntent(result);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("bReceivePayment.PostCollect - " + ex.Message.ToString());
                return new() { code = "500", success = "false", message = "Something went wrong!" };
            }

        }
        public async Task<OpenIntentResponse> PostQR(QRRequest qRRequest)
        {
            try
            {
                QR qR = new(_configuration)
                {
                    merchantTransactionId = qRRequest.MerchantTransactionId,
                    amount = qRRequest.Amount
                };

                string requestJSON = Newtonsoft.Json.JsonConvert.SerializeObject(qR);
                Base64Converter base64Converter = new Base64Converter();
                string requestBody = base64Converter.Base64Encode(requestJSON);
                string requestHeader = requestBody + "/pg/v1/pay" + _saltKey;

                HashConverter computeHash = new HashConverter();
                var headerHash = computeHash.Sha256HashEncode(requestHeader) + "###1";

                var result = await _requester.RequestPaymentAsync(headerHash, requestBody);

                if (result.data != null && result.data.merchantId != null)
                {
                    //Save to DB
                    _dbReceivePayment.PostOpenIntent(result);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("bReceivePayment.PostQR - " + ex.Message.ToString());
                return new() { code = "500", success = "false", message = "Something went wrong!" };
            }

        }
        public async Task<OpenIntentResponse> PostIntent(IntentRequest intentRequest)
        {
            try
            {
                OpenIntent openIntent = new(_configuration)
                {
                    merchantTransactionId = intentRequest.MerchantTransactionId,
                    amount = intentRequest.Amount
                };

                string requestJSON = Newtonsoft.Json.JsonConvert.SerializeObject(openIntent);
                Base64Converter base64Converter = new Base64Converter();
                string requestBody = base64Converter.Base64Encode(requestJSON);
                string requestHeader = requestBody + "/pg/v1/pay" + _saltKey;

                HashConverter computeHash = new HashConverter();
                var headerHash = computeHash.Sha256HashEncode(requestHeader) + "###1";

                var result = await _requester.RequestPaymentAsync(headerHash, requestBody);

                if (result.data != null && result.data.merchantId != null)
                {
                    //Save to DB
                    _dbReceivePayment.PostOpenIntent(result);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("bReceivePayment.PostIntent - " + ex.Message.ToString());
                return new() { code = "500", success = "false", message = "Something went wrong!" };
            }

        }
    }
}
