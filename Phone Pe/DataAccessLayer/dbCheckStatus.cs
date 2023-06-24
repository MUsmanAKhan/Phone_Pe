using DataAccessLayer.DataAccess;
using Phone_Pe.Models;
using System.Data.SqlClient;
using System.Data;

namespace Phone_Pe.DataAccessLayer
{
    public class dbCheckStatus
    {
        private readonly DBAccess DB;

        public dbCheckStatus(IConfiguration configuration)
        {
            DB = new DBAccess(configuration);
        }
        public DataTable CheckStatus(CheckStatusResponse obj)
        {
            DB.Parameters.Add(new SqlParameter("@Action", "insert"));
            DB.Parameters.Add(new SqlParameter("@CheckStatusId", "0"));
            DB.Parameters.Add(new SqlParameter("@Success", obj.success));
            DB.Parameters.Add(new SqlParameter("@Code", obj.code));
            DB.Parameters.Add(new SqlParameter("@Message", obj.message));
            DB.Parameters.Add(new SqlParameter("@MerchantId", obj.data.merchantId));
            DB.Parameters.Add(new SqlParameter("@MerchantTransactionId", obj.data.merchantTransactionId));
            DB.Parameters.Add(new SqlParameter("@TransactionId", obj.data.transactionId));
            DB.Parameters.Add(new SqlParameter("@Amount", obj.data.amount));
            DB.Parameters.Add(new SqlParameter("@State", obj.data.state));
            DB.Parameters.Add(new SqlParameter("@ResponseCode", obj.data.responseCode));

            DB.Parameters.Add(new SqlParameter("@Arn", obj.data.paymentInstrument.arn));
            DB.Parameters.Add(new SqlParameter("@BankId", obj.data.paymentInstrument.bankId));
            DB.Parameters.Add(new SqlParameter("@BankTransactionId", obj.data.paymentInstrument.bankTransactionId));
            DB.Parameters.Add(new SqlParameter("@Brn", obj.data.paymentInstrument.brn));
            DB.Parameters.Add(new SqlParameter("@CardType", obj.data.paymentInstrument.cardType));
            DB.Parameters.Add(new SqlParameter("@PgAuthorizationCode", obj.data.paymentInstrument.pgAuthorizationCode));
            DB.Parameters.Add(new SqlParameter("@PgServiceTransactionId", obj.data.paymentInstrument.pgServiceTransactionId));
            DB.Parameters.Add(new SqlParameter("@PgTransactionId", obj.data.paymentInstrument.pgTransactionId));
            DB.Parameters.Add(new SqlParameter("@Type", obj.data.paymentInstrument.type));
            DB.Parameters.Add(new SqlParameter("@Utr", obj.data.paymentInstrument.utr));

            return DB.ExecuteDataTable("usp_CRUD_CheckStatus");
        }
    }
}
