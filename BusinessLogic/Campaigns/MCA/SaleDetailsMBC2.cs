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
    public class SaleDetailsMBC2
    {
        public int SalesID { get; set; }
        public string DebitOrderFailReason { get; set; }
        public string OldProducts { get; set; }
        public string Upgrade { get; set; }
        public string NewPackage { get; set; }
        public string RetentionOffer { get; set; }
        public string DPPOffer { get; set; }
        public string DebitOrder { get; set; }
        public string R50OnceOffDiscountOffered { get; set; }
        public string R50OnceOffDiscountAccepted { get; set; }
        public string FinancialAccountNumber { get; set; }
        public string SalaryDateAligned { get; set; }
        public string DCCInsurance { get; set; }
        public string ConnectID { get; set; }
        public string BoxOffice { get; set; }
        public string CustomerOnlyInterestedInLocingService { get; set; }
        public string MoneyToPay { get; set; }
        public string MoneyPaid { get; set; }
        public string DatePromisedToPay { get; set; }
        public string Products { get; set; }
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

        public static SaleDetailsMBC2 GetSaleDetails(int saleID)
        {
            SaleDetailsMBC2 retVal = new SaleDetailsMBC2();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@salesID", saleID)
            };

            string sql = "select * from Sales_Details_MCAMBC2 where SalesID = @salesID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        public static int CreateSaleDetail(int SalesID, string DebitOrderFailReason, string OldProducts, string Upgrade, string NewPackage, string RetentionOffer, string DPPOffer, string DebitOrder, string R50OnceOffDiscountOffered, string R50OnceOffDiscountAccepted, string FinancialAccountNumber, string SalaryDateAligned, string DCCInsurance, string ConnectID, string BoxOffice, string CustomerOnlyInterestedInLocingService, string MoneyToPay, string MoneyPaid, string DatePromisedToPay, string Products, DateTime DateCreated, DateTime DateUpdated, string CreatedBy, string UpdatedBy)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SalesID", SalesID),
                new SqlParameter("@DebitOrderFailReason", DebitOrderFailReason),
                new SqlParameter("@OldProducts", OldProducts),
                new SqlParameter("@Upgrade", Upgrade),
                new SqlParameter("@NewPackage", NewPackage),
                new SqlParameter("@RetentionOffer", RetentionOffer),
                new SqlParameter("@DPPOffer", DPPOffer),
                new SqlParameter("@DebitOrder", DebitOrder),
                new SqlParameter("@R50OnceOffDiscountOffered", R50OnceOffDiscountOffered),
                new SqlParameter("@R50OnceOffDiscountAccepted", R50OnceOffDiscountAccepted),
                new SqlParameter("@FinancialAccountNumber", FinancialAccountNumber),
                new SqlParameter("@SalaryDateAligned", SalaryDateAligned),
                new SqlParameter("@DCCInsurance", DCCInsurance),
                new SqlParameter("@ConnectID", ConnectID),
                new SqlParameter("@BoxOffice", BoxOffice),
                new SqlParameter("@CustomerOnlyInterestedInLocingService", CustomerOnlyInterestedInLocingService),
                new SqlParameter("@MoneyToPay", MoneyToPay),
                new SqlParameter("@MoneyPaid", MoneyPaid),
                new SqlParameter("@DatePromisedToPay", DatePromisedToPay),
                new SqlParameter("@Products", Products),
                new SqlParameter("@DateCreated", DateCreated),
                new SqlParameter("@DateUpdated", DateUpdated),
                new SqlParameter("@CreatedBy", CreatedBy),
                new SqlParameter("@UpdatedBy", UpdatedBy)
            };

            string sql = "spCreateSales_Details_MCAMBC2";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        private static SaleDetailsMBC2 MakeObject(DataRow inputRow)
        {
            SaleDetailsMBC2 retValue = new SaleDetailsMBC2();

            retValue.SalesID = (int)inputRow["SalesID"];
            retValue.DebitOrderFailReason = (string)inputRow["DebitOrderFailReason"];
            retValue.OldProducts = (string)inputRow["OldProducts"];
            retValue.Upgrade = (string)inputRow["Upgrade"];
            retValue.NewPackage = (string)inputRow["NewPackage"];
            retValue.RetentionOffer = (string)inputRow["RetentionOffer"];
            retValue.DPPOffer = (string)inputRow["DPPOffer"];
            retValue.DebitOrder = (string)inputRow["DebitOrder"];
            retValue.R50OnceOffDiscountOffered = (string)inputRow["R50OnceOffDiscountOffered"];
            retValue.R50OnceOffDiscountAccepted = (string)inputRow["R50OnceOffDiscountAccepted"];
            retValue.FinancialAccountNumber = (string)inputRow["FinancialAccountNumber"];
            retValue.SalaryDateAligned = (string)inputRow["SalaryDateAligned"];
            retValue.DCCInsurance = (string)inputRow["DCCInsurance"];
            retValue.ConnectID = (string)inputRow["ConnectID"];
            retValue.BoxOffice = (string)inputRow["BoxOffice"];
            retValue.CustomerOnlyInterestedInLocingService = (string)inputRow["CustomerOnlyInterestedInLocingService"];
            retValue.MoneyToPay = (string)inputRow["MoneyToPay"];
            retValue.MoneyPaid = (string)inputRow["MoneyPaid"];
            retValue.DatePromisedToPay = (string)inputRow["DatePromisedToPay"];
            retValue.Products = (string)inputRow["Products"];

            retValue._found = true;
            return retValue;
        }
    }
}
