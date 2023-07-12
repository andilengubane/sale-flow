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
    public class DeviceTypes
    {
        public string Title { get; set; }
        public string Premium { get; set; }
        public bool IsActive { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }

        private bool _found = false;

        public static int CreateDeviceType(string Title, string Premium, bool IsActive)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@Title", Title),
                new SqlParameter("@Premium", Premium),
                new SqlParameter("@IsActive", IsActive)
            };

            string sql = "spCreateDeviceType";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        public static List<DeviceTypes> GetAllPackages()
        {
            List<DeviceTypes> retVal = new List<DeviceTypes>();
            string sql = "select * from DeviceType where IsActive = 1";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }
        private static DeviceTypes MakeObject(DataRow inputRow)
        {
            DeviceTypes retValue = new DeviceTypes();
            retValue.Title = (string)inputRow["Title"];
            retValue.Premium = (string)inputRow["Premium"];
            retValue.IsActive = (bool)inputRow["IsActive"];

            retValue._found = true;
            return retValue;
        }
    }
}
