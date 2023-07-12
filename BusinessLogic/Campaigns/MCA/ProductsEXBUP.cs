using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;
using Utils.Logger;

namespace BusinessLogic.Campaigns.MCA
{
    public class ProductsEXBUP
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public bool Found { get { return _found; } }
        public bool _found = false;

        public static List<ProductsEXBUP> GetProducts()
        {
            List<ProductsEXBUP> retVal = new List<ProductsEXBUP>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@IsActive", true)
            };

            string sql = "select * from Products_MCAEXBUP where IsActive = @IsActive";

            DataTable results = DataAccess.ExecuteDataReader(sql, parm);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            results = null;

            return retVal;
        }
        private static ProductsEXBUP MakeObject(DataRow inputRow)
        {
            ProductsEXBUP retValue = new ProductsEXBUP();

            retValue.ProductID = (int)inputRow["ProductID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }
    }
}
