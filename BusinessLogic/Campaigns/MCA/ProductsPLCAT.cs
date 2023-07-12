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
    public class ProductsPLCAT
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public bool Found { get { return _found; } }
        public bool _found = false;

        public static List<ProductsPLCAT> GetProducts()
        {
            List<ProductsPLCAT> retVal = new List<ProductsPLCAT>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@IsActive", true)
            };

            string sql = "select * from Products_MCAPLCAT where IsActive = @IsActive";

            DataTable results = DataAccess.ExecuteDataReader(sql, parm);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            results = null;

            return retVal;
        }
        private static ProductsPLCAT MakeObject(DataRow inputRow)
        {
            ProductsPLCAT retValue = new ProductsPLCAT();

            retValue.ProductID = (int)inputRow["ProductID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }
    }
}
