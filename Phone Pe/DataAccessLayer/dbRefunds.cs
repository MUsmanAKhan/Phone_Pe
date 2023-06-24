using DataAccessLayer.DataAccess;
using Phone_Pe.Controllers;
using System.Data.SqlClient;
using System.Data;
using Phone_Pe.Models;

namespace Phone_Pe.DataAccessLayer
{
    public class dbRefunds
    {
        private readonly DBAccess DB;

        public dbRefunds(IConfiguration configuration)
        {
            DB = new DBAccess(configuration);
        }
        public DataTable PostRefund(RefundResponse obj)
        {
            DB.Parameters.Add(new SqlParameter("@Action", "insert"));
            DB.Parameters.Add(new SqlParameter("@RefundId", "0"));
            DB.Parameters.Add(new SqlParameter("@Success", obj.success));
            DB.Parameters.Add(new SqlParameter("@Code", obj.code));
            DB.Parameters.Add(new SqlParameter("@Message", obj.message));
            DB.Parameters.Add(new SqlParameter("@MerchantId", obj.data.merchantId));
            DB.Parameters.Add(new SqlParameter("@MerchantTransactionId", obj.data.merchantTransactionId));
            DB.Parameters.Add(new SqlParameter("@TransactionId", obj.data.transactionId));
            DB.Parameters.Add(new SqlParameter("@Amount", obj.data.amount));
            DB.Parameters.Add(new SqlParameter("@State", obj.data.state));
            DB.Parameters.Add(new SqlParameter("@ResponseCode", obj.data.responseCode));
            return DB.ExecuteDataTable("usp_CRUD_Refunds");
        }
    }
}
