using Microsoft.AspNetCore.Mvc;
using Phone_Pe.Models;
using Phone_Pe.Utility;
using System.Security.AccessControl;

namespace Phone_Pe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceivePaymentController : ControllerBase
    {
        private readonly ILogger<ReceivePaymentController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PhonePeAPIRequester _requester;
        private readonly string _saltKey;
        public ReceivePaymentController(ILogger<ReceivePaymentController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _requester = new PhonePeAPIRequester(configuration);
            _saltKey = configuration.GetValue<string>("MerchantSettings:SaltKey");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostCollect(CollectRequest collectRequest)
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
            string requestHeader = requestBody + "/pg/v1/pay"+ _saltKey;

            HashConverter computeHash = new HashConverter();
            var headerHash = computeHash.Sha256HashEncode(requestHeader) + "###1";

            var result = await _requester.RequestPaymentAsync(headerHash, requestBody);

            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PostQR(QRRequest qRRequest)
        {
            QR qR = new(_configuration)
            {
                merchantTransactionId = qRRequest.MerchantTransactionId,
                amount = qRRequest.Amount
            };

            string requestJSON = Newtonsoft.Json.JsonConvert.SerializeObject(qR);
            Base64Converter base64Converter = new Base64Converter();
            string requestBody = base64Converter.Base64Encode(requestJSON);
            string requestHeader = requestBody + "/pg/v1/pay"+ _saltKey;

            HashConverter computeHash = new HashConverter();
            var headerHash = computeHash.Sha256HashEncode(requestHeader) + "###1";

            var result = await _requester.RequestPaymentAsync(headerHash, requestBody);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PostIntent(IntentRequest intentRequest)
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
            return Ok(result);
        }
    }
}
