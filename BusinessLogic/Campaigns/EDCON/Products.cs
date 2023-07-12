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
    public class Products
    {
        public int ProductID { get; set; }
        public int ProductTypesID { get; set; }
        public string Title { get; set; }
        public string BI { get; set; }
        public bool Found { get { return _found; } }
        public bool _found = false;

        public static Products GetProductBI(int ProductTypesID)
        {
            Products retVal = new Products();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@ID", ProductTypesID)
            };

            string sql = "select * from Products where ProductTypesID = @ID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        public static List<Products> GetProductsByProductType(int ProductTypesID)
        {
            List<Products> retVal = new List<Products>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@ID", ProductTypesID)
            };

            string sql = "select * from Products where ProductTypesID = @ID";

            DataTable results = DataAccess.ExecuteDataReader(sql, parm);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            results = null;

            return retVal;
        }
        private static Products MakeObject(DataRow inputRow)
        {
            Products retValue = new Products();

            retValue.ProductID = (int)inputRow["ProductID"];
            retValue.ProductTypesID = (int)inputRow["ProductTypesID"];
            retValue.Title = (string)inputRow["Title"];
            retValue.BI = (string)inputRow["BI"];

            retValue._found = true;

            return retValue;
        }
    }
}
