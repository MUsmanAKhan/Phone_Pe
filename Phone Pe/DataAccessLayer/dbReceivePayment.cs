using DataAccessLayer.DataAccess;
using Phone_Pe.Models;
using System.Data.SqlClient;
using System.Data;

namespace Phone_Pe.DataAccessLayer
{
    public class dbReceivePayment
    {
        private readonly DBAccess DB;
        public dbReceivePayment(IConfiguration configuration)
        {
            DB = new DBAccess(configuration);
        }
        public DataTable PostOpenIntent(OpenIntentResponse obj)
        {
            DB.Parameters.Add(new SqlParameter("@Action", "insert"));
            DB.Parameters.Add(new SqlParameter("@OpenIntentId", "0"));
            DB.Parameters.Add(new SqlParameter("@Success", obj.success));
            DB.Parameters.Add(new SqlParameter("@Code", obj.code));
            DB.Parameters.Add(new SqlParameter("@Message", obj.message));
            DB.Parameters.Add(new SqlParameter("@MerchantId", obj.data.merchantId));
            DB.Parameters.Add(new SqlParameter("@MerchantTransactionId", obj.data.merchantTransactionId));
            DB.Parameters.Add(new SqlParameter("@Type", obj.data.instrumentResponse.type));
            DB.Parameters.Add(new SqlParameter("@QrIntentUrl", obj.data.instrumentResponse.intentUrl));
            DB.Parameters.Add(new SqlParameter("@QrData", obj.data.instrumentResponse.qrData));
            DB.Parameters.Add(new SqlParameter("@PayPageURL", obj.data.instrumentResponse.redirectInfo.url));
            DB.Parameters.Add(new SqlParameter("@PayPageMethod", obj.data.instrumentResponse.redirectInfo.method));
            return DB.ExecuteDataTable("usp_CRUD_OpenIntent");
        }
    }
}
