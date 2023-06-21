namespace Phone_Pe.Models
{
    public class CollectRequest
    {
        public string MerchantTransactionId { get; set; }
        public long Amount { get; set; }
        public string Vpa { get; set; }

    }
}
