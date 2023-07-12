using System;

namespace ExportService.FNB.Extention
{
    public class DecodeAccountType
    {
        public static string DecodeAccountTypeExport(string bankAccountType)
        {
            string retVal = String.Empty;
            switch (bankAccountType)
            {
                case "Cheque":
                case "Current Account":
                    retVal = "1";
                    break;
                case "Savings":
                    retVal = "2";
                    break;
                case "Transmission":
                    retVal = "3";
                    break;
            }

            return retVal;
        }
    }
}
