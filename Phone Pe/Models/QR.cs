namespace Phone_Pe.Models
{
    public class QR : Merchant
    {
        public QR(IConfiguration configuration) : base(configuration)
        {
        }
        public string merchantTransactionId { get; set; }
        public long amount { get; set; }
        public QRPaymentInstrument paymentInstrument { get; set; } = new QRPaymentInstrument();
    }
    public class QRPaymentInstrument
    {
        public string type { get; set; } = "UPI_QR";
    }
}
