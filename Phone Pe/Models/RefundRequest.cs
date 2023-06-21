namespace Phone_Pe.Models
{
    public class RefundRequest
    {
        public string OriginalTransactionId { get; set; }
        public string MerchantTransactionId { get; set; }
        public long Amount { get; set; }
    }
}
