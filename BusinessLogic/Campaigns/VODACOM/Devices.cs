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
    public class Devices
    {
        public string Title { get; set; }
        public string DeviceTypeID { get; set; }
        public bool IsActive { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }

        private bool _found = false;

        public static int CreateDevices(string Title, string DeviceTypeID, bool IsActive)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@Title", Title),
                new SqlParameter("@DeviceTypeID", DeviceTypeID),
                new SqlParameter("@IsActive", IsActive)
            };

            string sql = "spCreateDevices";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        public static Devices GetDevices(int deviceTypeID)
        {
            Devices retVal = new Devices();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@deviceTypeID", deviceTypeID)
            };

            string sql = "select * from Devices where DeviceTypeID = @deviceTypeID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        private static Devices MakeObject(DataRow inputRow)
        {
            Devices retValue = new Devices();
            retValue.Title = (string)inputRow["Title"];
            retValue.DeviceTypeID = (string)inputRow["DeviceTypeID"];
            retValue.IsActive = (bool)inputRow["IsActive"];

            retValue._found = true;
            return retValue;
        }
    }
}
