namespace Phone_Pe.Models
{
    public class CheckStatusResponse
    {
        public string? success { get; set; }
        public string? code { get; set; }
        public string? message { get; set; }
        public CheckStatusData? data { get; set; }
    }
    public class CheckStatusData
    {
        public string? merchantId { get; set; }
        public string? merchantTransactionId { get; set; }
        public string? transactionId { get; set; }
        public long amount { get; set; }
        public string? state { get; set; }
        public string? responseCode { get; set; }
        public CheckStatusInstrument? paymentInstrument { get; set; } = new CheckStatusInstrument();
    }
    public class CheckStatusInstrument
    {
        public string? type { get; set; }
        public string? utr { get; set; }
        public string? pgTransactionId { get; set; }
        public string? pgServiceTransactionId { get; set; }
        public string? bankTransactionId { get; set; }
        public string? bankId { get; set; }
        public string? cardType { get; set; }
        public string? pgAuthorizationCode { get; set; }
        public string? arn { get; set; }
        public string? brn { get; set; }
    }
}
