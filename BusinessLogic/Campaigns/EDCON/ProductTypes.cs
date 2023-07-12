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
    public class ProductTypes
    {
        public int ProductTypesID { get; set; }
        public string Title { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }
        private bool _found = false;

        private static ProductTypes MakeObject(DataRow inputRow)
        {
            ProductTypes retValue = new ProductTypes();

            retValue.ProductTypesID = (int)inputRow["ProductTypesID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }

        public static List<ProductTypes> GetAllProductTypes()
        {
            List<ProductTypes> retVal = new List<ProductTypes>();
            string sql = "select * from ProductTypes where IsActive = 1";
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
