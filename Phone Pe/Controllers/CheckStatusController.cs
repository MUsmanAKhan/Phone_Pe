using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phone_Pe.Models;
using Phone_Pe.Utility;

namespace Phone_Pe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckStatusController : ControllerBase
    {
        private readonly ILogger<CheckStatusController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PhonePeAPIRequester _requester;
        private readonly string _saltKey;
        public CheckStatusController(ILogger<CheckStatusController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _requester = new PhonePeAPIRequester(configuration);
            _saltKey = configuration.GetValue<string>("MerchantSettings:SaltKey");
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> CheckStatus(string MerchantTransactionId)
        {
            string MerchantId = _configuration.GetValue<string>("MerchantSettings:MerchantId");
            string requestHeader = "/pg/v1/status/" + MerchantId + "/" + MerchantTransactionId + _saltKey;
            HashConverter computeHash = new HashConverter();
            var headerHash = computeHash.Sha256HashEncode(requestHeader) + "###1";

            var result = await _requester.CheckStatusAsync(headerHash, MerchantId, MerchantTransactionId);

            return Ok(result);
        }
    }
}
