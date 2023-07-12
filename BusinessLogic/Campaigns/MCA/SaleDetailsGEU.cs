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
    public class SaleDetailsGEU
    {
        public int SalesID { get; set; }
        public string Notes { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string DPPOffer { get; set; }
        public string DebitOrder { get; set; }
        public string DCCInsurance { get; set; }
        public string CustomerOnlyInterestedInLockingServices { get; set; }
        public string MoneyToPay { get; set; }
        public string MoneyPaid { get; set; }
        public string DatePromisedToPay { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public bool Found
        {
            get
            { return _found; }
        }

        private bool _found = false;

        public static SaleDetailsGEU GetSaleDetails(int saleID)
        {
            SaleDetailsGEU retVal = new SaleDetailsGEU();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@salesID", saleID)
            };

            string sql = "select * from Sales_Details_MCAGEU where SalesID = @salesID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }

        public static int CreateSaleDetail(int SalesID, string Notes, string Address1, string Address2, string Suburb, string City, string Code, string DPPOffer, string DebitOrder, string DCCInsurance, string CustomerOnlyInterestedInLockingServices, string MoneyToPay, string MoneyPaid, string DatePromisedToPay, DateTime DateCreated, DateTime DateUpdated, string CreatedBy, string UpdatedBy)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SalesID", SalesID),
                new SqlParameter("@Notes", Notes),
                new SqlParameter("@Address1", Address1),
                new SqlParameter("@Address2", Address2),
                new SqlParameter("@Suburb", Suburb),
                new SqlParameter("@City", City),
                new SqlParameter("@Code", Code),
                new SqlParameter("@DPPOffer", DPPOffer),
                new SqlParameter("@DebitOrder", DebitOrder),
                new SqlParameter("@DCCInsurance", DCCInsurance),
                new SqlParameter("@CustomerOnlyInterestedInLockingServices", CustomerOnlyInterestedInLockingServices),
                new SqlParameter("@MoneyToPay", MoneyToPay),
                new SqlParameter("@MoneyPaid", MoneyPaid),
                new SqlParameter("@DatePromisedToPay", DatePromisedToPay),
                new SqlParameter("@DateCreated", DateCreated),
                new SqlParameter("@DateUpdated", DateUpdated),
                new SqlParameter("@CreatedBy", CreatedBy),
                new SqlParameter("@UpdatedBy", UpdatedBy)
            };

            string sql = "spCreateSales_Details_MCAGEU";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        private static SaleDetailsGEU MakeObject(DataRow inputRow)
        {
            SaleDetailsGEU retValue = new SaleDetailsGEU();

            retValue.SalesID = (int)inputRow["SalesID"];
            retValue.Notes = (string)inputRow["Notes"];
            retValue.Address1 = (string)inputRow["Address1"];
            retValue.Address2 = (string)inputRow["Address2"];
            retValue.Suburb = (string)inputRow["Suburb"];
            retValue.City = (string)inputRow["City"];
            retValue.Code = (string)inputRow["Code"];
            retValue.DPPOffer = (string)inputRow["DPPOffer"];
            retValue.DebitOrder = (string)inputRow["DebitOrder"];
            retValue.DCCInsurance = (string)inputRow["DCCInsurance"];
            retValue.CustomerOnlyInterestedInLockingServices = (string)inputRow["CustomerOnlyInterestedInLockingServices"];
            retValue.MoneyToPay = (string)inputRow["MoneyToPay"];
            retValue.MoneyPaid = (string)inputRow["MoneyPaid"];
            retValue.DatePromisedToPay = (string)inputRow["DatePromisedToPay"];

            retValue._found = true;
            return retValue;
        }

    }
}
