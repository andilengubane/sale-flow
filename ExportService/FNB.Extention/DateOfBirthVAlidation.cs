using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportService.FNB.Extention
{
    public class DateOfBirthVAlidation
    {
        public static DateTime IDtoDOB(string idNumber)
        {
            DateTime retDate = new DateTime();
            int dd;
            int mm;
            int YY;
            try
            {
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
            }
            catch
            {
                retDate = DateTime.Now.Date.AddYears(-150);
            }
            return retDate;
        }
    }
}
