using Microsoft.AspNetCore.Mvc;
using Phone_Pe.BusinessLayer;
using Phone_Pe.Models;

namespace Phone_Pe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceivePaymentController : ControllerBase
    {
        private readonly bReceivePayment _bReceivePayment;

        public ReceivePaymentController(ILogger<ReceivePaymentController> logger, IConfiguration configuration)
        {
            _bReceivePayment = new bReceivePayment(configuration, logger);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostCollect(CollectRequest collectRequest)
        {
            OpenIntentResponse response = new OpenIntentResponse();
            var t1 = Task.Run(() => _bReceivePayment.PostCollect(collectRequest));
            await Task.WhenAll(t1);
            response = t1.Status == TaskStatus.RanToCompletion ? t1.Result : response;
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PostQR(QRRequest qRRequest)
        {
            OpenIntentResponse response = new OpenIntentResponse();
            var t1 = Task.Run(() => _bReceivePayment.PostQR(qRRequest));
            await Task.WhenAll(t1);
            response = t1.Status == TaskStatus.RanToCompletion ? t1.Result : response;
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PostIntent(IntentRequest intentRequest)
        {
            OpenIntentResponse response = new OpenIntentResponse();
            var t1 = Task.Run(() => _bReceivePayment.PostIntent(intentRequest));
            await Task.WhenAll(t1);
            response = t1.Status == TaskStatus.RanToCompletion ? t1.Result : response;
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
    }
}
