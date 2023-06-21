namespace Phone_Pe.Models
{
    public class OpenIntent : Merchant
    {
        public OpenIntent(IConfiguration configuration) : base(configuration)
        {
            redirectUrl = configuration.GetValue<string>("MerchantSettings:RedirectUrl");
            redirectMode = configuration.GetValue<string>("MerchantSettings:RedirectMode");
        }
        public string merchantTransactionId { get; set; }
        public long amount { get; set; }
        public string redirectMode { get; set; }
        public string redirectUrl { get; set; }
        public OpenIntentPaymentInstrument paymentInstrument { get; set; } = new OpenIntentPaymentInstrument();
    }

    public class OpenIntentPaymentInstrument
    {
        public string type { get; set; } = "PAY_PAGE";
    }
}
