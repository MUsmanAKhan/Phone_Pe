namespace Phone_Pe.Models
{
    public class RefundResponse
    {
        public string? success { get; set; }
        public string? code { get; set; }
        public string? message { get; set; }
        public RefundResponseData? data { get; set; }
    }
    public class RefundResponseData
    {
        public string? merchantId { get; set; }
        public string? merchantTransactionId { get; set; }
        public string? transactionId { get; set; }
        public long amount { get; set; }
        public string? state { get; set; }
        public string? responseCode { get; set; }
    }
}

