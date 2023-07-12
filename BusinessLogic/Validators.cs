using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Helper;
namespace BusinessLogic
{
    public class Validators
    {
        /// <summary>
        /// returns the earliest date based on the "day" specified... 
        /// useful for getting next debit order day, if invalid the next first day of the month
        /// </summary>
        /// <param name="inputDay"></param>
        /// <returns></returns>
        public static DateTime MakeDateFromDay(int inputDay)
        {
            DateTime outDate = DateTime.MinValue;
            if (DateTime.TryParse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + inputDay.ToString() , out outDate))
            {
                if (outDate.Date <= DateTime.Now.Date)
                {
                    outDate = outDate.AddMonths(1);
                }
            }
            else
            {
                outDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
                outDate = MakeDateFromDay(outDate.Day);
            }
            return outDate;
        }
        /// <summary>
        /// Returns a Date of Birth from your RSA ID Number
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        private static DateTime IDtoDOB(string idNumber)
        {
            DateTime retDate = new DateTime();
            int dd;
            int mm;
            int YY;

            if (int.TryParse(idNumber.Substring(0, 2), out YY))
            {
                if (int.TryParse(idNumber.Substring(2, 2), out mm))
                {
                    if (int.TryParse(idNumber.Substring(4, 2), out dd))
                    {
                        int year20 = 2000 + YY;
                        int year19 = 1900 + YY;

                        if (year20 >= DateTime.Now.Year)
                        {
                            YY = year19;
                        }
                        else
                        {
                            YY = year20;
                        }
                        retDate = new DateTime(YY, mm, dd);
                    }
                }
            }
            return retDate;
        }
        /// <summary>
        /// this will check if the system database is accessible
        /// </summary>
        /// <returns></returns>
        public static bool IsDBAvailable()
        {
            bool retVal = false;
            try
            {
                DateTime now = Convert.ToDateTime(DataAccess.ExecuteSimpleScalar("select getDate();"));
                retVal = true;
            }
            catch { }

            return retVal;
        }
        /// <summary>
        /// hides banking details and only shows last 4 characters, ignores hyphen "-" symbols
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public static string MaskBankDetails(string inputText)
        {
            StringBuilder retVal = new StringBuilder();
            if(inputText.Trim().Length>4)
            {
                int charToHide = inputText.Trim().Length - 4;
                int startIndex = inputText.Trim().Length - 4;
                for(int i=0; i< charToHide; i++)
                {
                    if(inputText.Trim().Substring(i,1) == "-")
                    {
                        retVal.Append("-");
                    }
                    else
                    {
                        retVal.Append("X");
                    }
                }
                retVal.Append( inputText.Trim().Substring(startIndex));
            }
            else
            {
                retVal.Append(inputText.Trim());
            }
            return retVal.ToString();
        }
        /// <summary>
        /// use this function to set a dropdownlist box selected item by its text value
        /// </summary>
        /// <param name="theText"></param>
        /// <param name="comboBox"></param>
        public static void SetDropDownBoxText(string theText, ref System.Web.UI.WebControls.DropDownList comboBox)
        {
            for(int i=0; i< comboBox.Items.Count; i++)
            {
                if(comboBox.Items[i].Text == theText)
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
