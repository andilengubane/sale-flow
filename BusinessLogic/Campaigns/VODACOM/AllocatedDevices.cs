using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;
using Utils.Logger;

namespace BusinessLogic.Campaigns.VODACOM
{
    public class AllocatedDevices
    {
        public int DevicesID { get; set; }
        public int SalesID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }

        private bool _found = false;


        public static int CreateAllocatedDevices(int DevicesID, int SalesID, DateTime DateCreated, DateTime DateUpdated, string UpdatedBy, bool IsActive)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@DevicesID", DevicesID),
                new SqlParameter("@SalesID", SalesID),
                new SqlParameter("@DateCreated", DateCreated),
                new SqlParameter("@DateUpdated", DateUpdated),
                new SqlParameter("@UpdatedBy", UpdatedBy),
                new SqlParameter("@IsActive", IsActive)
            };

            string sql = "spCreateAllocatedDevices";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        public static AllocatedDevices GetAllocatedDevices(int salesID)
        {
            AllocatedDevices retVal = new AllocatedDevices();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@salesID", salesID)
            };

            string sql = "select * from Devices where SalesID = @salesID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        private static AllocatedDevices MakeObject(DataRow inputRow)
        {
            AllocatedDevices retValue = new AllocatedDevices();
            retValue.DevicesID = (int)inputRow["DevicesID"];
            retValue.SalesID = (int)inputRow["SalesID"];
            retValue.DateCreated = (DateTime)inputRow["DateCreated"];
            retValue.DateUpdated = (DateTime)inputRow["DateUpdated"];
            retValue.UpdatedBy = (string)inputRow["UpdatedBy"];
            retValue.IsActive = (bool)inputRow["IsActive"];

            retValue._found = true;
            return retValue;
        }
    }
}
