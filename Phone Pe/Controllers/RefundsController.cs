using Microsoft.AspNetCore.Mvc;
using Phone_Pe.BusinessLayer;
using Phone_Pe.Models;

namespace Phone_Pe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundsController : ControllerBase
    {
        private readonly bRefunds _bRefunds;
        public RefundsController(ILogger<RefundsController> logger, IConfiguration configuration)
        {
            _bRefunds = new bRefunds(configuration, logger);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PostRefund(RefundRequest refundRequest)
        {
            RefundResponse response = new RefundResponse();
            var t1 = Task.Run(() => _bRefunds.PostRefund(refundRequest));
            await Task.WhenAll(t1);
            response = t1.Status == TaskStatus.RanToCompletion ? t1.Result : response;
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
    }
}
