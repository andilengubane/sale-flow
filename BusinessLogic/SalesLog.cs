using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic
{
    public class SalesLog
    {
        public int ID { get; set; }
        public int SalesID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Comment { get; set; }

        bool _found = false;
        public bool Found { get { return _found; } }

        public static int CreateSalesLog(int salesID, string modifiedBy, string comment)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@salesID", salesID),
                new SqlParameter("@modifiedDate", DateTime.Now),
                new SqlParameter("@modifiedBy", modifiedBy),
                new SqlParameter("@comment", comment)
            };

            string sql = "spCreateSalesLog";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        public static SalesLog GetSalesLog(int salesLogID, string campaignId)
        {
            SalesLog retVal = new SalesLog();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@salesLogID", salesLogID),
                new SqlParameter("@campaignID", campaignId)
            };

            string sql = "select * from Sales_Log where ID = @salesLogID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }

        public static SalesLog GetCurrentSalesLog(int saleID)
        {
            SalesLog retVal = new SalesLog();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@saleID", saleID)
            };

            string sql = "spGetCurrentSaleStatusRecord";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);

            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }

        public static List<SalesLog> GetAllSalesLog(int saleID)
        {
            List<SalesLog> retVal = new List<SalesLog>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@salesID", saleID)
            };

            string sql = "select * from Sales_Log where Sale_ID = @salesID order by ID desc;";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            for( int i=0; i< results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            return retVal;
        }

        private static SalesLog MakeObject(DataRow inputRow)
        {
            SalesLog retValue = new SalesLog();

            retValue.ID = (int)inputRow["ID"];
            retValue.SalesID = (int)inputRow["Sale_ID"];
            retValue.ModifiedDate = (DateTime)inputRow["UpdateTime"];
            retValue.UpdatedBy = (string)inputRow["UpdateBy"];
            retValue.Comment = (string)inputRow["Comment"];
            retValue._found = true;

            return retValue;
        }
    }
}
