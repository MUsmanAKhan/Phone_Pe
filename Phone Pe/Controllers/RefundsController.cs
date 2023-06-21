using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phone_Pe.Models;
using Phone_Pe.Utility;

namespace Phone_Pe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundsController : ControllerBase
    {
        private readonly ILogger<RefundsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PhonePeAPIRequester _requester;
        private readonly string _saltKey;
        public RefundsController(ILogger<RefundsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _requester = new PhonePeAPIRequester(configuration);
            _saltKey = configuration.GetValue<string>("MerchantSettings:SaltKey");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PostRefund(RefundRequest refundRequest)
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
            return Ok(result);
        }
    }
}
