using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic.Campaigns.MCA
{
    public class InstallationsRequirements
    {
        public int InstallationsRequirementsID { get; set; }
        public string Title { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }
        private bool _found = false;

        private static InstallationsRequirements MakeObject(DataRow inputRow)
        {
            InstallationsRequirements retValue = new InstallationsRequirements();

            retValue.InstallationsRequirementsID = (int)inputRow["InstallationsRequirementsID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }

        public static List<InstallationsRequirements> GetAllInstallationsRequirements()
        {
            List<InstallationsRequirements> retVal = new List<InstallationsRequirements>();
            string sql = "select * from MCA_InstallationsRequirements where IsActive = 1";
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
