using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic
{
    public class RevolvingFacilities
    {
        public int FacilitiesID { get; set; }
        public string Facilities { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }
        private bool _found = false;

        private static RevolvingFacilities MakeObject(DataRow inputRow)
        {
            RevolvingFacilities retValue = new RevolvingFacilities();

            retValue.FacilitiesID = (int)inputRow["FacilitiesID"];
            retValue.Facilities = (string)inputRow["Facilities"];
            retValue._found = true;

            return retValue;
        }

        public static List<RevolvingFacilities> GetOverdraft()
        {
            List<RevolvingFacilities> retVal = new List<RevolvingFacilities>();
            string sql = "select * from RevolvingFacility where FacilitiesID = 1";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }
        public static List<RevolvingFacilities> GetBusiness()
        {
            List<RevolvingFacilities> retVal = new List<RevolvingFacilities>();
            string sql = "select * from RevolvingFacility where FacilitiesID = 1";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }
        public static List<RevolvingFacilities> GetRevolving()
        {
            List<RevolvingFacilities> retVal = new List<RevolvingFacilities>();
            string sql = "select * from RevolvingFacility where FacilitiesID = 1";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }
        public static List<RevolvingFacilities> GetCredit()
        {
            List<RevolvingFacilities> retVal = new List<RevolvingFacilities>();
            string sql = "select * from RevolvingFacility where FacilitiesID = 1";
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
