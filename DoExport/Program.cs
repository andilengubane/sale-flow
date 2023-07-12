using BusinessLogic;
using ExportService;

namespace DoExport
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] campaignsToExport = Campaign.GetCampaignsToExport();

            for (int i = 0; i < campaignsToExport.Length; i++)
            {
                switch (campaignsToExport[i])
                {
                    case "RCABSA4":
                        RCABSA4.DoExport();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
