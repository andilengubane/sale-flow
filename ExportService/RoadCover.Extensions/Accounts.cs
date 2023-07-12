using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportService.RoadCover.Extensions
{
    public class Accounts
    {
        public static string DecodeAccountType(string bankAccountType)
        {
            string retVal = string.Empty;
            switch (bankAccountType)
            {
                case "Cheque Account":
                case "Cheque":
                    retVal = "1";
                    break;
                case "Savings Account":
                case "Savings":
                    retVal = "2";
                    break;
                case "Transmission Account":
                case "Transmission":
                    retVal = "3";
                    break;
                case "Current Account":
                case "Current":
                    retVal = "1";
                    break;
            }
            return retVal;
        }
    }
}
