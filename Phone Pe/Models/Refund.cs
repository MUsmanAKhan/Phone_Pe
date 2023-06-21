namespace Phone_Pe.Models
{
    public class Refund : Merchant
    {
        public Refund(IConfiguration configuration) : base(configuration)
        {
        }
        public string originalTransactionId { get; set; }
        public string merchantTransactionId { get; set; }
        public long amount { get; set; }
    }
}
