namespace Phone_Pe.Models
{
    public class OpenIntentResponse
    {
        public string? success { get; set; }
        public string? code { get; set; }
        public string? message { get; set; }
        public OpenIntentData? data { get; set; }
    }
    public class OpenIntentData
    {
        public string? merchantId { get; set; }
        public string? merchantTransactionId { get; set; }
        public InstrumentResponse? instrumentResponse { get; set; } = new InstrumentResponse();
    }
    public class InstrumentResponse
    {
        public string? type { get; set; }
        public string? qrData { get; set; }
        public string? intentUrl { get; set; }
        public RedirectInfo? redirectInfo { get; set; } = new RedirectInfo();
    }
    public class RedirectInfo
    {
        public string? url { get; set; }
        public string? method { get; set; }
    }
}
