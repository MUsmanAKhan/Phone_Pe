using System.Text;

namespace Phone_Pe.Utility
{
    public class PhonePeAPIRequester
    {
        private readonly string _RequestUri = "";
        public PhonePeAPIRequester(IConfiguration configuration)
        {
            _RequestUri = configuration.GetValue<string>("PhonePeAPIEndPoint");
        }
        internal async Task<string> RequestPaymentAsync(string xVerify, string requestBody)
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
                    if (response.IsSuccessStatusCode) // Check the status
                    {
                        var body = await response.Content.ReadAsStringAsync(); // Read the response
                        return body;

                    }
                    else
                    {
                        var body = "Error: " + response.StatusCode;
                        return body;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        internal async Task<string> CheckStatusAsync(string xVerify, string merchantId, string merchantTransactionId)
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
                    if (response.IsSuccessStatusCode) // Check the status
                    {
                        var body = await response.Content.ReadAsStringAsync(); // Read the response
                        return body;

                    }
                    else
                    {
                        var body = "Error: " + response.StatusCode;
                        return body;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        internal async Task<string> RequestRefundAsync(string xVerify, string requestBody)
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
                    if (response.IsSuccessStatusCode) // Check the status
                    {
                        var body = await response.Content.ReadAsStringAsync(); // Read the response
                        return body;

                    }
                    else
                    {
                        var body = "Error: " + response.StatusCode;
                        return body;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
