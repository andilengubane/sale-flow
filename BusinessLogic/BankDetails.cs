using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic
{
    /// <summary>
    /// Main object for handling banking details data.
    /// </summary>
    public class BankDetails
    {
        private bool _found = false;

        public int BankDetailsID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
        public string BranchCode { get; set; }
        public string BankBranch { get; set; }
        public int FirstDebitMonth { get; set; }
        public int FirstDebitDay { get; set; }
        public string PrimarySecondaryAccount { get; set; }
        public int SaleID { get; set; }
        public string BankAccountHolder { get; set; }
        public string SalaryDay { get; set; }

        public bool Found
        {
            get
            { return _found; }
        }

        public BankDetails()
        { }

        /// <summary>
        /// Pulls bank details data from the database for a specific sale ID
        /// </summary>
        /// <param name="saleId">An <see cref="int"/> value containing the sale ID to process.</param>
        /// <returns>An instance of <see cref="BankDetails"/> containing the data returned from the database for the provided sale ID.</returns>
        public static BankDetails GetBankDetails(int saleId)
        {
            BankDetails retVal = new BankDetails();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@SaleId", saleId)
            };

            string sql = "spGetSaleBankDetails";

            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }

        /// <summary>
        /// Takes a set of parameters, and creates a new entry in the BankDetails database table.
        /// </summary>
        /// <param name="accountNumber">A <see cref="string"/> containing the bank account number.</param>
        /// <param name="accountName">A <see cref="string"/> containing the bank account holder name.</param>
        /// <param name="bankName">A <see cref="string"/> containing the name of the bank.</param>
        /// <param name="accountType">A <see cref="string"/> containing the account type of the bank account.</param>
        /// <param name="branchCode">A <see cref="string"/> containing the bank branch code (usually the Universal code).</param>
        /// <param name="firstDebitMonth">An <see cref="int"/> value containing the month number (1 - 12) of the first debit date.</param>
        /// <param name="firstDebitDay">An <see cref="int"/> value containing the day number (1 - 28/29/30/31 depending on month and leap year) of the first debit date.</param>
        /// <param name="PrimarySecondaryAccount">A <see cref="string"/> containing if the account is a primary or secondary account.</param>
        /// <param name="saleId">An <see cref="int"/> value containing the sale ID of the sale being processed.</param>
        /// <returns>An <see cref="int"/> value containing the unique ID from the newly inserted BankDetails row.</returns>
        public static int CreateBankDetails(string accountNumber, string accountName, string bankName, string accountType, string branchCode, int firstDebitMonth, int firstDebitDay,
            string PrimarySecondaryAccount, int saleId)
        {
            int retval = 0;

            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
                {
                new SqlParameter("@AccountNumber", accountNumber),
                new SqlParameter("@AccountName", accountName),
                new SqlParameter("@BankName", bankName),
                new SqlParameter("@AccountType", accountType),
                new SqlParameter("@BranchCode", branchCode),
                new SqlParameter("@FirstDebitMonth", firstDebitMonth),
                new SqlParameter("@FirstDebitDay", firstDebitDay),
                new SqlParameter("@PrimarySecondaryAccount", PrimarySecondaryAccount),
                new SqlParameter("@SaleID", saleId)
                };

                string sql = "spSaveBankDetails";

                retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retval;
        }

        /// <summary>
        /// Takes a set of parameters, and saves an entry in the BankDetails database table.
        /// </summary>
        /// <param name="accountNumber">A <see cref="string"/> containing the bank account number.</param>
        /// <param name="accountName">A <see cref="string"/> containing the bank account holder name.</param>
        /// <param name="bankName">A <see cref="string"/> containing the name of the bank.</param>
        /// <param name="accountType">A <see cref="string"/> containing the account type of the bank account.</param>
        /// <param name="branchCode">A <see cref="string"/> containing the bank branch code (usually the Universal code).</param>
        /// <param name="firstDebitMonth">An <see cref="int"/> value containing the month number (1 - 12) of the first debit date.</param>
        /// <param name="firstDebitDay">An <see cref="int"/> value containing the day number (1 - 28/29/30/31 depending on month and leap year) of the first debit date.</param>
        /// <param name="PrimarySecondaryAccount">A <see cref="string"/> containing if the account is a primary or secondary account.</param>
        /// <param name="saleId">An <see cref="int"/> value containing the sale ID of the sale being processed.</param>
        /// <returns>An <see cref="int"/> value containing the unique ID of the saved BankDetails row.</returns>
        public static int SaveBankDetails(long accountNumber, string accountName, string bankName, string accountType, string branchCode, int firstDebitMonth, int firstDebitDay,
            string PrimarySecondaryAccount, int saleId)
        {
            int retval = 0;
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
                {
                    new SqlParameter("@AccountNumber", accountNumber),
                    new SqlParameter("@AccountName", accountName),
                    new SqlParameter("@BankName", bankName),
                    new SqlParameter("@AccountType", accountType),
                    new SqlParameter("@BranchCode", branchCode),
                    new SqlParameter("@FirstDebitMonth", firstDebitMonth),
                    new SqlParameter("@FirstDebitDay", firstDebitDay),
                    new SqlParameter("@PrimarySecondaryAccount", PrimarySecondaryAccount),
                    new SqlParameter("@SaleID", saleId)
                };

                string sql = "spSaveBankDetails";

                retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retval;
        }

        /// <summary>
        /// Mini-factory method that takes a database row, and creates a 
        /// new BankDetails object from the data held within the database row.
        /// </summary>
        /// <param name="inputRow">A <see cref="DataRow"/> object containing data from the BankDetails database table.</param>
        /// <returns>A <see cref="BankDetails"/> object containing the data from the database mapped into the object fields.</returns>
        private static BankDetails MakeObject(DataRow inputRow)
        {
            BankDetails retValue = new BankDetails();

            retValue.BankDetailsID = (int)inputRow["ID"];
            retValue.AccountNumber = (string)inputRow["AccountNumber"];
            retValue.AccountName = (string)inputRow["AccountName"];
            retValue.BankName = (string)inputRow["BankName"];
            retValue.AccountType = (string)inputRow["AccountType"];
            retValue.BranchCode = (string)inputRow["BranchCode"];
            retValue.FirstDebitMonth = (int)inputRow["FirstDebitMonth"];
            retValue.FirstDebitDay = (int)inputRow["FirstDebitDay"];
            retValue.PrimarySecondaryAccount = (string)inputRow["PrimarySecondaryAccount"];
            retValue.SaleID = (int)inputRow["SaleID"];

            retValue._found = true;

            return retValue;
        }
    }
}
