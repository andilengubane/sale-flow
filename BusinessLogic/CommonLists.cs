using System;
using System.Collections.Generic;
using System.Data;
using Helper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CommonLists
    {
        public static List<KeyValuePair<string, string>> GetDebitOrderDays()
        {
            List<KeyValuePair<string, string>> retVal = new List<KeyValuePair<string, string>>();

            DateTime today = DateTime.Today;

            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

            int day = 1;

            while(day <= daysInMonth)
            {
                retVal.Add(new KeyValuePair<string, string>(day.ToString("0#"), day.ToString()));
                day++;
            }

            return retVal;
        }

        public static List<KeyValuePair<string, string>> GetGender()
        {
            List<KeyValuePair<string, string>> retVal = new List<KeyValuePair<string, string>>();

            retVal.Add(new KeyValuePair<string, string>("Female", "Female"));
            retVal.Add(new KeyValuePair<string, string>("Male", "Male"));
            retVal.Add(new KeyValuePair<string, string>("Female", "F"));
            retVal.Add(new KeyValuePair<string, string>("Male", "M"));

            return retVal;
        }

        public static List<KeyValuePair<string, string>> GetNationality()
        {
            List<KeyValuePair<string, string>> retVal = new List<KeyValuePair<string, string>>();

            retVal.Add(new KeyValuePair<string, string>("South African", "South African"));
            retVal.Add(new KeyValuePair<string, string>("Other", "Other"));

            return retVal;
        }

        public static List<KeyValuePair<string, string>> GetDisposition()
        {
            List<KeyValuePair<string, string>> retVal = new List<KeyValuePair<string, string>>();

            retVal.Add(new KeyValuePair<string, string>("Sale", "Sale"));
            retVal.Add(new KeyValuePair<string, string>("Incomplete", "Incomplete"));

            return retVal;
        }

        /// <summary>
        /// Returns a list of provinces for use in drop down lists
        /// </summary>
        /// <returns>
        /// A List of <see cref="Province"/> objects that will be bound to the necessary drop-down list.
        /// </returns>
        public static List<Province> GetProvinces()
        {
            List<Province> output = new List<Province>();

            DataTable provinceData = DataAccess.ExecuteSimpleSpDataReader("spGetProvinces");

            foreach (DataRow row in provinceData.Rows)
            {
                Province p = new Province()
                {
                    Id = (int)row[0],
                    Name = row[1].ToString()                    
                };

                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// Returns a list of titles for use in drop down lists
        /// </summary>
        /// <returns>
        /// A List of <see cref="Title"/> objects that will be bound to the necessary drop-down list.
        /// </returns>
        public static List<Title> GetTitle()
        {
            List<Title> output = new List<Title>();
            DataTable titleData = DataAccess.ExecuteSimpleSpDataReader("spGetTitles");
            foreach (DataRow row in titleData.Rows)
            {
                Title title = new Title()
                {
                    ID = (int)row[0],
                    Name = row[1].ToString()
                };

                output.Add(title);
            }
            return output;
        }

        /// <summary>
        /// Returns a list of bank objects for use in drop down lists
        /// </summary>
        /// <returns>
        /// A List of <see cref="Bank"/> objects that will be bound to the necessary drop-down list.
        /// </returns>
        public static List<Bank> GetBanks()
        {
            List<Bank> output = new List<Bank>();
            DataTable bankData = DataAccess.ExecuteSimpleSpDataReader("spGetBanks");
            foreach (DataRow row in bankData.Rows)
            {
                Bank bank = new Bank()
                {
                    ID = (int)row[0],
                    BankName = row[1].ToString(),
                    BranchName = row[2].ToString(),
                    BranchCode = row[3].ToString()
                };

                output.Add(bank);
            }
            return output;
        }
    }
}
