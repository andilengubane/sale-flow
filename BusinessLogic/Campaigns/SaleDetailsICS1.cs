using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;
using Utils.Logger;

namespace BusinessLogic.Campaigns
{
	public class SaleDetailsICS1
	{
		public int SalesID { get; set; }
		public string Notes { get; set; }
		public string IDNumber { get; set; }
		public string Email { get; set; }
		public string CompanyName { get; set; }
		public string EmploymentStatus { get; set; }
		public string MarketingConsent { get; set; }
		public string FirstPayment { get; set; }
		public string Installment { get; set; }
		public string Comment { get; set; }
		public string BankName { get; set; }
		public string AccountType { get; set; }
		public string PaymentFrequency { get; set; }
		public string AccountNumber { get; set; }
		public DateTime DebitDate { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string Suburb { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
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

		public static SaleDetailsICS1 GetSaleDetails(int saleID)
		{
			SaleDetailsICS1 retVal = new SaleDetailsICS1();

			List<SqlParameter> parms = new List<SqlParameter>()
			{
				new SqlParameter("@salesID", saleID)
			};

			string sql = "select * from Sales_Detail_ICS1 where SalesID = @salesID";
			DataTable results = DataAccess.ExecuteDataReader(sql, parms);
			if (results.Rows.Count > 0)
			{
				retVal = MakeObject(results.Rows[0]);
			}
			return retVal;
		}
		public static int CreateSaleDetail(int SalesID, string Notes, string IDNumber, string Email, string CompanyName, string EmploymentStatus, string MarketingConsent, string FirstPayment, string Installment, string Comment, string BankName, string AccountType, string PaymentFrequency, string AccountNumber, DateTime DebitDate, string AddressLine1, string AddressLine2, string Suburb, string City, string PostalCode, DateTime DateCreated, DateTime DateUpdated, string CreatedBy, string UpdatedBy)
		{
			int retval = 0;

			List<SqlParameter> parm = new List<SqlParameter>()
			{
				new SqlParameter("@SalesID", SalesID),
				new SqlParameter("@Notes", Notes),
				new SqlParameter("@IDNumber", IDNumber),
				new SqlParameter("@Email", Email),
				new SqlParameter("@CompanyName",CompanyName),
				new SqlParameter("@EmploymentStatus",EmploymentStatus),
				new SqlParameter("@MarketingConsent",MarketingConsent),
				new SqlParameter("@FirstPayment",FirstPayment),
				new SqlParameter("@Installment",Installment),
				new SqlParameter("@Comment",Comment),
				new SqlParameter("@BankName",BankName),
				new SqlParameter("@AccountType",AccountType),
				new SqlParameter("@PaymentFrequency",PaymentFrequency),
				new SqlParameter("@AccountNumber",AccountNumber),
				new SqlParameter("@DebitDate",DebitDate),
				new SqlParameter("@AddressLine1",AddressLine1),
				new SqlParameter("@AddressLine2",AddressLine2),
				new SqlParameter("@Suburb",Suburb),
				new SqlParameter("@City",City),
				new SqlParameter("@PostalCode",PostalCode),
				new SqlParameter("@DateCreated",DateCreated),
				new SqlParameter("@DateUpdated",DateUpdated),
				new SqlParameter("@CreatedBy",CreatedBy),
				new SqlParameter("@UpdatedBy",UpdatedBy)
			};

			string sql = "spCreateSales_Details_ICS1";

			retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

			return retval;
		}
		private static SaleDetailsICS1 MakeObject(DataRow inputRow)
		{
			SaleDetailsICS1 retValue = new SaleDetailsICS1();

			retValue.SalesID = (int)inputRow["SalesID"];
			retValue.IDNumber = (string)inputRow["Notes"];
			retValue.Email = (string)inputRow["IDNumber"];
			retValue.Notes = (string)inputRow["Email"];
			retValue.CompanyName = (string)inputRow["CompanyName"];
			retValue.EmploymentStatus = (string)inputRow["EmploymentStatus"];
			retValue.MarketingConsent = (string)inputRow["MarketingConsent"];
			retValue.FirstPayment = (string)inputRow["FirstPayment"];
			retValue.Installment = (string)inputRow["Installment"];
			retValue.Comment = (string)inputRow["Comment"];
			retValue.BankName = (string)inputRow["BankName"];
			retValue.AccountType = (string)inputRow["AccountType"];
			retValue.PaymentFrequency = (string)inputRow["PaymentFrequency"];
			retValue.AccountNumber = (string)inputRow["AccountNumber"];
			retValue.DebitDate = (DateTime)inputRow["DebitDate"];
			retValue.AddressLine1 = (string)inputRow["AddressLine1"];
			retValue.AddressLine2 = (string)inputRow["AddressLine2"];
			retValue.Suburb = (string)inputRow["Suburb"];
			retValue.City = (string)inputRow["City"];
			retValue.PostalCode = (string)inputRow["PostalCode"];

			retValue._found = true;
			return retValue;
		}
	}
}
