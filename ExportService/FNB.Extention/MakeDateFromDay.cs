using System;

namespace ExportService.FNB.Extention
{
    public class MakeDateFromDay
    {
        public static string MakeDateFromDayExport(string inputDay)
        {
            DateTime outDate = DateTime.MinValue;
            if (DateTime.TryParse(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + inputDay, out outDate))
            {
                if (outDate.Day < 9)
                {
                    outDate = outDate.AddMonths(1);
                }

                if (outDate.Date <= DateTime.Now.Date)
                {
                    outDate = outDate.AddMonths(1);
                }
            }
            else
            {
                outDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
            }
            return outDate.ToString("yyyyMMdd");
        }
    }
}
