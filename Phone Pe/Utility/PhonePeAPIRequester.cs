using Newtonsoft.Json;
using Phone_Pe.Models;
using System.Text;

namespace Phone_Pe.Utility
{
    public class PhonePeAPIRequester
    {
        private readonly string _RequestUri = "";
        private readonly ILogger _logger;
        public PhonePeAPIRequester(IConfiguration configuration, ILogger logger)
        {
            _RequestUri = configuration.GetValue<string>("PhonePeAPIEndPoint");
            _logger = logger;
        }
        internal async Task<OpenIntentResponse> RequestPaymentAsync(string xVerify, string requestBody)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(_RequestUri + "/pay"),
                    Headers =
                {
                    { "accept", "application/json" },
                    { "X-VERIFY", xVerify },
                },
                    Content = new StringContent("{\"request\":\"" + requestBody + "\"}", Encoding.UTF8, "application/json")
                };
                using (var response = await client.SendAsync(request))
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var status = JsonConvert.DeserializeObject<OpenIntentResponse>(body);
                    return status;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("PhonePeAPIRequester.RequestPaymentAsync - " + ex.Message);
                return new() { code = "500", success = "false", message = "Something went wrong!" };
            }
        }

        internal async Task<CheckStatusResponse> CheckStatusAsync(string xVerify, string merchantId, string merchantTransactionId)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(_RequestUri + "/status/" + merchantId + "/" + merchantTransactionId),
                    Headers =
                {
                    { "accept", "application/json" },
                    { "X-VERIFY", xVerify },
                    { "X-MERCHANT-ID", merchantId },
                },
                };
                using (var response = await client.SendAsync(request))
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var status = JsonConvert.DeserializeObject<CheckStatusResponse>(body);
                    return status;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("PhonePeAPIRequester.CheckStatusAsync - " + ex.Message);
                return new() { code = "500", success = "false", message = "Something went wrong!" };
            }
        }
        internal async Task<RefundResponse> RequestRefundAsync(string xVerify, string requestBody)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(_RequestUri + "/refund"),
                    Headers =
                {
                    { "accept", "application/json" },
                    { "X-VERIFY", xVerify },
                },
                    Content = new StringContent("{\"request\":\"" + requestBody + "\"}", Encoding.UTF8, "application/json")
                };
                using (var response = await client.SendAsync(request))
                {
                    //if (response.IsSuccessStatusCode)
                    //{
                    var body = await response.Content.ReadAsStringAsync();
                    var status = JsonConvert.DeserializeObject<RefundResponse>(body);
                    return status;

                    //}
                    //else
                    //{
                    //    //var body = "Error: " + response.StatusCode;
                    //    //return body;

                    //    var body = await response.Content.ReadAsStringAsync();
                    //    var status = JsonConvert.DeserializeObject<RefundResponse>(body);
                    //    return status;
                    //}
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("PhonePeAPIRequester.RequestRefundAsync - " + ex.Message);
                return new() { code = "500", success = "false", message = "Something went wrong!" };
            }
        }
    }
}
