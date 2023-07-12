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
    public class SaleDetails
    {
            public int SalesID { get; set; }
            public bool IsRetained { get; set; }
            public int OldPackageIDadID { get; set; }
            public int NewPackageID { get; set; }
            public string UpgradeDowngrade { get; set; }
            public int RetentionOfferID { get; set; }
            public int InstallationRequirementsID { get; set; }
            public string Notes { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string Suburb { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public int DPPOfferID { get; set; }
            public string DebitOrder { get; set; }
            public string DCCInsurance { get; set; }
            public string BoxOfficeActivation { get; set; }
            public string ConnectID { get; set; }
            public string PaymentNotifications { get; set; }
            public string PriceIncreaseNotifications { get; set; }
            public string SinceLastDisconnect { get; set; }
            public string ComeBackReason { get; set; }
            public string OtherTVChannels { get; set; }
            public string LeaveReason { get; set; }
            public string MoneyToPay { get; set; }
            public string MoneyPaid { get; set; }
            public DateTime DatePromisedToPay { get; set; }
            public bool IsActive { get; set; }
            public bool Found
            {
                get
                { return _found; }
            }

            private bool _found = false;


            public static SaleDetails GetSaleDetails(int saleID)
            {
            SaleDetails retVal = new SaleDetails();

                List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@salesID", saleID)
            };

                string sql = "select * from Sales_Details_MCA where SalesID = @salesID";
                DataTable results = DataAccess.ExecuteDataReader(sql, parms);
                if (results.Rows.Count > 0)
                {
                    retVal = MakeObject(results.Rows[0]);
                }
                return retVal;
            }

            public static int CreateSaleDetail(int SalesID, bool IsRetained, int OldPackageID, int NewPackageID, string UpgradeDowngrade, int RetentionOfferID, int InstallationRequirementsID, string Notes, string AddressLine1, string AddressLine2, string Suburb, string City, string PostalCode,
                int DPPOfferID, string DebitOrder, string DCCInsurance, string BoxOfficeActivation, string ConnectID, string PaymentNotifications, string PriceIncreaseNotifications, string SinceLastDisconnect, string ComeBackReason, string OtherTVChannels, string LeaveReason, string MoneyToPay, string MoneyPaid,
                DateTime DatePromisedToPay, bool IsActive)
            {
                int retval = 0;

                List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SalesID", SalesID),
                new SqlParameter("@IsRetained", IsRetained),
                new SqlParameter("@OldPackageID", OldPackageID),
                new SqlParameter("@NewPackageID", NewPackageID),
                new SqlParameter("@UpgradeDowngrade", UpgradeDowngrade),
                new SqlParameter("@RetentionOfferID", RetentionOfferID),
                new SqlParameter("@InstallationRequirementsID", InstallationRequirementsID),
                new SqlParameter("@Notes", Notes),
                new SqlParameter("@AddressLine1", AddressLine1),
                new SqlParameter("@AddressLine2", AddressLine2),
                new SqlParameter("@Suburb", Suburb),
                new SqlParameter("@City", City),
                new SqlParameter("@PostalCode", PostalCode),
                new SqlParameter("@DPPOfferID", DPPOfferID),
                new SqlParameter("@DebitOrder", DebitOrder),
                new SqlParameter("@DCCInsurance", DCCInsurance),
                new SqlParameter("@BoxOfficeActivation", BoxOfficeActivation),
                new SqlParameter("@ConnectID", ConnectID),
                new SqlParameter("@PaymentNotifications", PaymentNotifications),
                new SqlParameter("@PriceIncreaseNotifications", PriceIncreaseNotifications),
                new SqlParameter("@SinceLastDisconnect", SinceLastDisconnect),
                new SqlParameter("@ComeBackReason", ComeBackReason),
                new SqlParameter("@OtherTVChannels", OtherTVChannels),
                new SqlParameter("@LeaveReason", LeaveReason),
                new SqlParameter("@MoneyToPay", MoneyToPay),
                new SqlParameter("@MoneyPaid", MoneyPaid),
                new SqlParameter("@DatePromisedToPay", DatePromisedToPay),
                new SqlParameter("@IsActive", IsActive)
            };

                string sql = "spCreateSales_Details_MCA";

                retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

                return retval;
            }
            private static SaleDetails MakeObject(DataRow inputRow)
            {
            SaleDetails retValue = new SaleDetails();

                retValue.SalesID = (int)inputRow["SalesID"];
                retValue.IsRetained = (bool)inputRow["IsRetained"];
                retValue.OldPackageIDadID = (int)inputRow["OldPackageIDadID"];
                retValue.NewPackageID = (int)inputRow["NewPackageID"];
                retValue.UpgradeDowngrade = (string)inputRow["UpgradeDowngrade"];
                retValue.RetentionOfferID = (int)inputRow["RetentionOfferID"];
                retValue.InstallationRequirementsID = (int)inputRow["InstallationRequirementsID"];

                retValue.Notes = (string)inputRow["Notes"];
                retValue.AddressLine1 = (string)inputRow["AddressLine1"];
                retValue.AddressLine2 = (string)inputRow["AddressLine2"];
                retValue.Suburb = (string)inputRow["Suburb"];
                retValue.City = (string)inputRow["City"];
                retValue.PostalCode = (string)inputRow["PostalCode"];
                retValue.DPPOfferID = (int)inputRow["DPPOfferID"];

                retValue.DebitOrder = (string)inputRow["DebitOrder"];
                retValue.DCCInsurance = (string)inputRow["DCCInsurance"];
                retValue.BoxOfficeActivation = (string)inputRow["BoxOfficeActivation"];
                retValue.ConnectID = (string)inputRow["ConnectID"];
                retValue.PaymentNotifications = (string)inputRow["PaymentNotifications"];
                retValue.PriceIncreaseNotifications = (string)inputRow["PriceIncreaseNotifications"];
                retValue.SinceLastDisconnect = (string)inputRow["SinceLastDisconnect"];
                retValue.ComeBackReason = (string)inputRow["ComeBackReason"];
                retValue.OtherTVChannels = (string)inputRow["OtherTVChannels"];
                retValue.MoneyToPay = (string)inputRow["MoneyToPay"];
                retValue.MoneyPaid = (string)inputRow["MoneyPaid"];
                retValue.DatePromisedToPay = (DateTime)inputRow["DatePromisedToPay"];
                retValue.IsActive = (bool)inputRow["IsActive"];

                retValue._found = true;
                return retValue;
            }
        }
    }

