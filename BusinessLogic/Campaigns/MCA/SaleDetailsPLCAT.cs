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
    public class SaleDetailsPLCAT
    {
        public int SalesID { get; set; }
        public bool IsRetained { get; set; }
        public string MultiChoiceID { get; set; }
        public int ProductID { get; set; }
        public bool ExceptionAddress { get; set; }
        public string NotInterestedMWEB { get; set; }
        public string StreetNumber { get; set; }
        public string UnitNumber { get; set; }
        public string BuildingName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string Landmark { get; set; }
        public string Comments { get; set; }
        public string HouseHoldExpenses { get; set; }
        public string DebtCommitments { get; set; }
        public string SaleAwaitingDocuments { get; set; }
        public string Income { get; set; }
        public string NonFinancialAccount { get; set; }
        public string ReferralSale { get; set; }
        public string SalesOrderNumberGenerate { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string SaleType { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }

        private bool _found = false;

        public static SaleDetailsPLCAT GetSaleDetails(int saleID)
        {
            SaleDetailsPLCAT retVal = new SaleDetailsPLCAT();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@salesID", saleID)
            };

            string sql = "select * from Sales_Details_MCAPLCAT where SalesID = @salesID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        public static int CreateSaleDetail(int SalesID, bool IsRetained, string MultiChoiceID, int ProductID, bool ExceptionAddress, string NotInterestedMWEB, string StreetNumber, string UnitNumber, string BuildingName, string Suburb, string City, string Code,
               string Landmark, string Comments, string HouseHoldExpenses, string DebtCommitments, string SaleAwaitingDocuments, string Income, string NonFinancialAccount, string ReferralSale, string SalesOrderNumberGenerate, bool IsActive, DateTime DateCreated, DateTime DateUpdated,
               string CreatedBy, string UpdatedBy, string SaleType)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SalesID", SalesID),
                new SqlParameter("@IsRetained", IsRetained),
                new SqlParameter("@MultiChoiceID", MultiChoiceID),
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@ExceptionAddress", ExceptionAddress),
                new SqlParameter("@NotInterestedMWEB", NotInterestedMWEB),
                new SqlParameter("@StreetNumber", StreetNumber),
                new SqlParameter("@UnitNumber", UnitNumber),
                new SqlParameter("@BuildingName", BuildingName),
                new SqlParameter("@Suburb", Suburb),
                new SqlParameter("@City", City),
                new SqlParameter("@Code", Code),
                new SqlParameter("@Landmark", Landmark),
                new SqlParameter("@Comments", Comments),
                new SqlParameter("@HouseHoldExpenses", HouseHoldExpenses),
                new SqlParameter("@DebtCommitments", DebtCommitments),
                new SqlParameter("@SaleAwaitingDocuments", SaleAwaitingDocuments),
                new SqlParameter("@Income", Income),
                new SqlParameter("@NonFinancialAccount", NonFinancialAccount),
                new SqlParameter("@ReferralSale", ReferralSale),
                new SqlParameter("@SalesOrderNumberGenerate", SalesOrderNumberGenerate),
                new SqlParameter("@IsActive", IsActive),
                new SqlParameter("@DateCreated",DateCreated),
                new SqlParameter("@DateUpdated",DateUpdated),
                new SqlParameter("@CreatedBy",CreatedBy),
                new SqlParameter("@UpdatedBy",UpdatedBy),
                new SqlParameter("@SaleType", SaleType)
            };

            string sql = "spCreateSales_Details_MCAPLCAT";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        private static SaleDetailsPLCAT MakeObject(DataRow inputRow)
        {
            SaleDetailsPLCAT retValue = new SaleDetailsPLCAT();

            retValue.SalesID = (int)inputRow["SalesID"];
            retValue.IsRetained = (bool)inputRow["IsRetained"];
            retValue.MultiChoiceID = (string)inputRow["MultiChoiceID"];
            retValue.ProductID = (int)inputRow["ProductID"];
            retValue.ExceptionAddress = (bool)inputRow["ExceptionAddress"];
            retValue.NotInterestedMWEB = (string)inputRow["NotInterestedMWEB"];
            retValue.StreetNumber = (string)inputRow["StreetNumber"];
            retValue.UnitNumber = (string)inputRow["UnitNumber"];

            retValue.BuildingName = (string)inputRow["BuildingName"];
            retValue.Suburb = (string)inputRow["Suburb"];
            retValue.City = (string)inputRow["City"];
            retValue.Code = (string)inputRow["Code"];
            retValue.Landmark = (string)inputRow["Landmark"];

            retValue.Comments = (string)inputRow["Comments"];
            retValue.HouseHoldExpenses = (string)inputRow["HouseHoldExpenses"];
            retValue.DebtCommitments = (string)inputRow["DebtCommitments"];
            retValue.SaleAwaitingDocuments = (string)inputRow["SaleAwaitingDocuments"];
            retValue.Income = (string)inputRow["Income"];

            retValue.NonFinancialAccount = (string)inputRow["NonFinancialAccount"];
            retValue.ReferralSale = (string)inputRow["ReferralSale"];
            retValue.SalesOrderNumberGenerate = (string)inputRow["SalesOrderNumberGenerate"];
            retValue.IsActive = (bool)inputRow["IsActive"];

            retValue._found = true;
            return retValue;
        }
    }
}
