using Microsoft.AspNetCore.Mvc;
using Phone_Pe.BusinessLayer;
using Phone_Pe.Models;

namespace Phone_Pe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckStatusController : ControllerBase
    {
        private readonly bCheckStatus _bCheckStatus;

        public CheckStatusController(ILogger<CheckStatusController> logger, IConfiguration configuration)
        {
            _bCheckStatus = new bCheckStatus(configuration, logger);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> CheckStatus(string MerchantTransactionId)
        {
            CheckStatusResponse response = new CheckStatusResponse();
            var t1 = Task.Run(() => _bCheckStatus.CheckStatus(MerchantTransactionId));
            await Task.WhenAll(t1);
            response = t1.Status == TaskStatus.RanToCompletion ? t1.Result : response;
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
    }
}
