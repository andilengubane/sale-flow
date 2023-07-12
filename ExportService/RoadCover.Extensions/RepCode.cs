using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportService.RoadCover.Extensions
{
    public class RepCode
    {
        public static string GetRepCode(string strNotes)
        {
            string retVal = string.Empty;
            switch (strNotes)
            {
                case "DEBICHECK SALES -NED014(2018 - DECEMBER 2018 |":
                    retVal = "NED014";
                    break;
                case "DEBICHECK SALES - NED016 (2019)|":
                    retVal = "NED016";
                    break;
                case "DEBICHECK SALES - NED018 (2019)|":
                    retVal = "NED018";
                    break;
                case "DEBICHECK SALES - NED019 (2019)|":
                    retVal = "NED019";
                    break;
                case "NED005 (2018) - APRIL 2018|":
                    retVal = "NED005";
                    break;
                case "NED006 (2018) - MAY 2018|":
                    retVal = "NED006";
                    break;
                case "NED007 (2018) - JUNE 2018|":
                    retVal = "NED007";
                    break;
                case "NED008 (2018) - JULY 2018|":
                    retVal = "NED008";
                    break;
                case "NED009 (2018) - AUGUST 2018|":
                    retVal = "NED009";
                    break;
                case "NED010 (2018) - SEPTEMBER 2018|":
                    retVal = "NED010";
                    break;
                case "NED011 (2018) - OCTOBER 2018|":
                    retVal = "NED011";
                    break;
                case "NED012 (2018) - NOVEMBER 2018|":
                    retVal = "NED012";
                    break;
                case "NED013 (2018) - DECEMBER 2018|":
                    retVal = "NED013";
                    break;
            }
            return retVal;
        }
    }
}
