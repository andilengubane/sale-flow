using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic.Campaigns.EDCON
{
    public class SaleType
    {
        public int SaleTypesEDCONID { get; set; }
        public string Title { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }
        private bool _found = false;

        private static SaleType MakeObject(DataRow inputRow)
        {
            SaleType retValue = new SaleType();

            retValue.SaleTypesEDCONID = (int)inputRow["SaleTypesEDCONID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }

        public static List<SaleType> GetAllSaleTypes()
        {
            List<SaleType> retVal = new List<SaleType>();
            string sql = "select * from SaleTypesEDCON where IsActive = 1";
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
