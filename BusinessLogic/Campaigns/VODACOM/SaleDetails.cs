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
    public class SaleDetails
    {
        public int SalesID { get; set; }
        public string MSISDN { get; set; }
        public string AltNo1 { get; set; }
        public string AltNo2 { get; set; }
        public string SubsID { get; set; }
        public string Conn { get; set; }
        public string Device1 { get; set; }
        public string Device2 { get; set; }
        public string InsuranceCover { get; set; }
        public DateTime DateRef { get; set; }
        public string ReccuringBundle { get; set; }
        public bool IsActive { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }

        private bool _found = false;
        public static int CreateSaleDetail(int SalesID, string MSISDN, int AltNo1, int AltNo2, string SubsID, string Conn, string Device1, string Device2, string InsuranceCover, DateTime DateRef, string ReccuringBundle, bool IsActive)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SalesID", SalesID),
                new SqlParameter("@MSISDN", MSISDN),
                new SqlParameter("@AltNo1", AltNo1),
                new SqlParameter("@AltNo2", AltNo2),
                new SqlParameter("@SubsID", SubsID),
                new SqlParameter("@Conn", Conn),
                new SqlParameter("@Device1", Device1),
                new SqlParameter("@Device2", Device2),
                new SqlParameter("@InsuranceCover", InsuranceCover),
                new SqlParameter("@DateRef", DateRef),
                new SqlParameter("@ReccuringBundle", ReccuringBundle),
                new SqlParameter("@IsActive", IsActive)
            };

            string sql = "spCreateSales_Details_MCA";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        public static SaleDetails GetSaleDetails(int saleID)
        {
            SaleDetails retVal = new SaleDetails();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@salesID", saleID)
            };

            string sql = "select * from Sales_Details_Vodacom where SalesID = @salesID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        private static SaleDetails MakeObject(DataRow inputRow)
        {
            SaleDetails retValue = new SaleDetails();

            retValue.SalesID = (int)inputRow["SalesID"];
            retValue.MSISDN = (string)inputRow["MSISDN"];
            retValue.AltNo1 = (string)inputRow["AltNo1"];
            retValue.AltNo2 = (string)inputRow["AltNo2"];
            retValue.SubsID = (string)inputRow["SubsID"];
            retValue.Conn = (string)inputRow["Conn"];
            retValue.Device1 = (string)inputRow["Device1"];

            retValue.Device2 = (string)inputRow["Device2"];
            retValue.InsuranceCover = (string)inputRow["InsuranceCover"];
            retValue.DateRef = (DateTime)inputRow["DateRef"];
            retValue.ReccuringBundle = (string)inputRow["ReccuringBundle"];
            retValue.IsActive = (bool)inputRow["IsActive"];

            retValue._found = true;
            return retValue;
        }

    }
}
