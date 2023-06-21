namespace Phone_Pe.Models
{
    public class Collect : Merchant
    {
        public Collect(IConfiguration configuration) : base(configuration)
        {
        }
        public string merchantTransactionId { get; set; }
        public long amount { get; set; }
        public CollectPaymentInstrument paymentInstrument { get; set; } = new CollectPaymentInstrument();
    }
    public class CollectPaymentInstrument
    {
        public string type { get; set; } = "UPI_COLLECT";
        public string vpa { get; set; }
    }
}
