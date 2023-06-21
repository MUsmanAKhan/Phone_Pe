namespace Phone_Pe.Models
{
    public class Merchant
    {
        public Merchant(IConfiguration configuration)
        {
            merchantId = configuration.GetValue<string>("MerchantSettings:MerchantId");
            merchantUserId = configuration.GetValue<string>("MerchantSettings:MerchantUserId");
            callbackUrl = configuration.GetValue<string>("MerchantSettings:CallbackUrl");
            mobileNumber = configuration.GetValue<string>("MerchantSettings:MobileNumber");
        }
        public string merchantId { get; set; }
        public string merchantUserId { get; set; }
        public string callbackUrl { get; set; }
        public string mobileNumber { get; set; }
    }
}
