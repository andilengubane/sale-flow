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
    public class Batch
    {
        public int ID { get; set; }
        public DateTime BatchDate { get; set; }
        public bool IsDeleted { get; set;}
        bool _found = false;
        public bool Found { get { return _found; } set { _found = value; } }
        public string ExtRefID { get; set; }
        public int LeadCount { get { return Sales.GetSaleTotalByBatchID(this.ID); } }
        public static int SaveBatch(DateTime batchDate, bool isDeleted, string extRefID)
        {
            return SaveBatch(batchDate, isDeleted, extRefID, 0);
        }
        public static int SaveBatch(DateTime batchDate, bool isDeleted, string extRefID, int batchID)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@batchDate", batchDate),
                new SqlParameter("@isDeleted", isDeleted),
                new SqlParameter("@extRefID", extRefID),
                new SqlParameter("@ID", batchID)
            };

            string sql = "spSaveBatch";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        private static Batch MakeObject(DataRow inputRow)
        {
            Batch retValue = new Batch();

            retValue.ID = (int)inputRow["BatchID"];
            retValue.IsDeleted = (bool)inputRow["IsDeleted"];
            retValue.BatchDate = (DateTime)inputRow["BatchDate"];
            retValue.ExtRefID = (string)inputRow["ExtRefID"];
            retValue._found = true;

            return retValue;
        }
        public static Batch GetBatchByExternalRefID(string extRefID)
        {
            Batch retVal = new Batch();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@ExtRefID", extRefID)
            };

            string sql = "select * from [Batch] where ExtRefID = @ExtRefID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            results.Dispose();
            return retVal;
        }
        public static List<Batch> GetBatchByDate(DateTime batchDate)
        {
            List<Batch> retVal = new List<Batch>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@batchDate", batchDate)
            };

            string sql = "select * from [Batch] where cast(BatchDate as date) = cast(@batchDate as date)";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }
        public static List<Batch> GetBatchByDeletedStatus(bool isDeleted)
        {
            List<Batch> retVal = new List<Batch>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@IsDeleted", isDeleted)
            };

            string sql = "select * from [Batch] where IsDeleted = @IsDeleted";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            for(int i=0; i< results.Rows.Count; i++)
            {
                retVal.Add( MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }
        public static List<Batch> GetAllActiveBatch()
        {
            List<Batch> retVal = new List<Batch>();

            string sql = "Select * from [Batch] where IsDeleted = 0 order by 1 desc;";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }
    }
}
