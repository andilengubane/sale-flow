using System;
using Helper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Bank
    {
        public int ID { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }

        /// <summary>
        /// Retrieves a bank record from the database using the passed bank ID.
        /// </summary>
        /// <param name="bankID">An <see cref="int"/> value containing the unique bank ID </param>
        /// <returns>A <see cref="Bank"/> object containing the data returned by the database.</returns>
        public static Bank GetBankByID(int bankID)
        {
            Bank retVal = new Bank();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@ID", bankID)
            };

            string sql = "spGetBankByID";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }

            return retVal;
        }

        /// <summary>
        /// A mini-factory method that generates an object using the data in the passed database row object.
        /// </summary>
        /// <param name="dataRow">A <see cref="DataRow"/> object containing the data to use when generating the new object.</param>
        /// <returns>A <see cref="Bank"/> object populated with the data in the <see cref="DataRow"/> object.</returns>
        private static Bank MakeObject(DataRow inputRow)
        {
            Bank retValue = new Bank();

            retValue.ID = (int)inputRow["ID"];
            retValue.BankName = (string)inputRow["BankName"];
            retValue.BranchName = (string)inputRow["BranchName"];
            retValue.BranchCode = (string)inputRow["BranchCode"];

            return retValue;
        }
    }
}
