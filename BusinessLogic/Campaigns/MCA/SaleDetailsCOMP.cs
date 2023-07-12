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
    public class SaleDetailsCOMP
    {
        public int SalesID { get; set; }
        public string PaymentMethod { get; set; }
        public string WillCustomerBuyHardwareFromRetailer { get; set; }
        public string EscalatedToFieldServicesForInstallation { get; set; }
        public string CaptureCustomersResidentialAddress { get; set; }
        public string OldPackage { get; set; }
        public string Upgrade { get; set; }
        public string NewPackage { get; set; }
        public string NewAddonPackage { get; set; }
        public string Notes { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string DPPOffer { get; set; }
        public string DebitOrder { get; set; }
        public string DCCInsurance { get; set; }
        public string USSD { get; set; }
        public string PriceIncrease { get; set; }
        public string WasAdhocLoaded { get; set; }
        public string DSTVNowOffered { get; set; }
        public string AdvisedOnCatchupAndCatchUpPlus { get; set; }
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

        public static SaleDetailsCOMP GetSaleDetails(int saleID)
        {
            SaleDetailsCOMP retVal = new SaleDetailsCOMP();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@salesID", saleID)
            };

            string sql = "select * from Sales_Details_MCACOMP where SalesID = @salesID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        public static int CreateSaleDetail(int SalesID, string PaymentMethod, string WillCustomerBuyHardwareFromRetailer, string EscalatedToFieldServicesForInstallation, string CaptureCustomersResidentialAddress, string OldPackage, string Upgrade, string NewPackage, string NewAddonPackage, string Notes, string Address1, string Address2, string Suburb, string City, string Code, string DPPOffer,string DebitOrder, string DCCInsurance, string USSD, string PriceIncrease, string WasAdhocLoaded, string DSTVNowOffered, string AdvisedOnCatchupAndCatchUpPlus, string CustomerOnlyInterestedInLockingServices, string MoneyToPay, string MoneyPaid, string DatePromisedToPay, DateTime DateCreated, DateTime DateUpdated, string CreatedBy, string UpdatedBy)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SalesID", SalesID),
                new SqlParameter("@PaymentMethod", PaymentMethod),
                new SqlParameter("@WillCustomerBuyHardwareFromRetailer", WillCustomerBuyHardwareFromRetailer),
                new SqlParameter("@EscalatedToFieldServicesForInstallation", EscalatedToFieldServicesForInstallation),
                new SqlParameter("@CaptureCustomersResidentialAddress", CaptureCustomersResidentialAddress),
                new SqlParameter("@OldPackage", OldPackage),
                new SqlParameter("@Upgrade", Upgrade),
                new SqlParameter("@NewPackage", NewPackage),
                new SqlParameter("@NewAddonPackage", NewAddonPackage),
                new SqlParameter("@Notes", Notes),
                new SqlParameter("@Address1", Address1),
                new SqlParameter("@Address2", Address2),
                new SqlParameter("@Suburb", Suburb),
                new SqlParameter("@City", City),
                new SqlParameter("@Code", Code),
                new SqlParameter("@DPPOffer", DPPOffer),
                new SqlParameter("@DebitOrder", DebitOrder),
                new SqlParameter("@DCCInsurance", DCCInsurance),
                new SqlParameter("@USSD", USSD),
                new SqlParameter("@PriceIncrease", PriceIncrease),
                new SqlParameter("@WasAdhocLoaded", WasAdhocLoaded),
                new SqlParameter("@DSTVNowOffered", DSTVNowOffered),
                new SqlParameter("@AdvisedOnCatchupAndCatchUpPlus", AdvisedOnCatchupAndCatchUpPlus),
                new SqlParameter("@CustomerOnlyInterestedInLockingServices", CustomerOnlyInterestedInLockingServices),
                new SqlParameter("@MoneyToPay", MoneyToPay),
                new SqlParameter("@MoneyPaid", MoneyPaid),
                new SqlParameter("@DatePromisedToPay", DatePromisedToPay),
                new SqlParameter("@DateCreated", DateCreated),
                new SqlParameter("@DateUpdated", DateUpdated),
                new SqlParameter("@CreatedBy", CreatedBy),
                new SqlParameter("@UpdatedBy", UpdatedBy)
            };

            string sql = "spCreateSales_Details_MCACOMP";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        private static SaleDetailsCOMP MakeObject(DataRow inputRow)
        {
            SaleDetailsCOMP retValue = new SaleDetailsCOMP();

            retValue.SalesID = (int)inputRow["SalesID"];
            retValue.PaymentMethod = (string)inputRow["PaymentMethod"];
            retValue.WillCustomerBuyHardwareFromRetailer = (string)inputRow["WillCustomerBuyHardwareFromRetailer"];
            retValue.EscalatedToFieldServicesForInstallation = (string)inputRow["EscalatedToFieldServicesForInstallation"];
            retValue.CaptureCustomersResidentialAddress = (string)inputRow["CaptureCustomersResidentialAddress"];
            retValue.OldPackage = (string)inputRow["OldPackage"];
            retValue.Upgrade = (string)inputRow["Upgrade"];
            retValue.NewPackage = (string)inputRow["NewPackage"];
            retValue.NewAddonPackage = (string)inputRow["NewAddonPackage"];
            retValue.Notes = (string)inputRow["Notes"];
            retValue.Address1 = (string)inputRow["Address1"];
            retValue.Address2 = (string)inputRow["Address2"];
            retValue.Suburb = (string)inputRow["Suburb"];
            retValue.City = (string)inputRow["City"];
            retValue.Code = (string)inputRow["Code"];
            retValue.DPPOffer = (string)inputRow["DPPOffer"];
            retValue.DebitOrder = (string)inputRow["DebitOrder"];
            retValue.DCCInsurance = (string)inputRow["DCCInsurance"];
            retValue.USSD = (string)inputRow["USSD"];
            retValue.PriceIncrease = (string)inputRow["PriceIncrease"];
            retValue.WasAdhocLoaded = (string)inputRow["WasAdhocLoaded"];
            retValue.DSTVNowOffered = (string)inputRow["DSTVNowOffered"];
            retValue.AdvisedOnCatchupAndCatchUpPlus = (string)inputRow["AdvisedOnCatchupAndCatchUpPlus"];
            retValue.CustomerOnlyInterestedInLockingServices = (string)inputRow["CustomerOnlyInterestedInLockingServices"];
            retValue.MoneyToPay = (string)inputRow["MoneyToPay"];
            retValue.MoneyPaid = (string)inputRow["MoneyPaid"];
            retValue.DatePromisedToPay = (string)inputRow["DatePromisedToPay"];

            retValue._found = true;
            return retValue;
        }
    }
}
