using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace BusinessLogic.Campaigns
{
    public class rcnedd : Sales
    {
        //private string campaignID = "RCNEDD";

        public static List<KeyValuePair<string, string>> GetBenefits()
        {
            List<KeyValuePair<string, string>> retVal = new List<KeyValuePair<string, string>>();

            retVal.Add(new KeyValuePair<string, string>("Select", "0"));
            retVal.Add(new KeyValuePair<string, string>("R 20 000", "20000"));
            retVal.Add(new KeyValuePair<string, string>("R 30 000", "30000"));
            retVal.Add(new KeyValuePair<string, string>("R 40 000", "40000"));
            retVal.Add(new KeyValuePair<string, string>("R 50 000", "50000"));
            retVal.Add(new KeyValuePair<string, string>("R 60 000", "60000"));
            retVal.Add(new KeyValuePair<string, string>("R 70 000", "70000"));
            retVal.Add(new KeyValuePair<string, string>("R 80 000", "80000"));
            retVal.Add(new KeyValuePair<string, string>("R 90 000", "90000"));
            retVal.Add(new KeyValuePair<string, string>("R 100 000", "100000"));

            return retVal;
        }
    }
}
