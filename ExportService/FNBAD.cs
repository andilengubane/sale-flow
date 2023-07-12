using BusinessLogic;
using ExportService.DoExport.Extension.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;

namespace ExportService
{
    public class FNBAD
    {
        public static void DoExport()
        {
            List<Campaign> campaign = Campaign.GetCampaignsByCampaignName("FNBAD");
            int campaignId = campaign[0].CampaignID;

            Sales salelist = Sales.GetSale(campaignId);
            List<Sales> salesExport = Sales.GetAllSaleByCampaignID(campaign[0].CampaignID);

            int success = 0;
            int fail = 0;
            int total = salesExport.Count;

            for (int i = 0; i < salesExport.Count; i++)
            {
                if (DoExportFNBAD.DoExport(salesExport[i]))
                {
                    evLogger.LogEvent("CAMPAIGN NAME : " + salesExport[i].CampaignName + " Successful Export " + "\n LeadID=" + salesExport[i].LeadID + "\n SaleID=" + salesExport[i].ID, System.Diagnostics.EventLogEntryType.Information);
                }
                else
                {
                    evLogger.LogEvent("CAMPAIGN NAME : " + salesExport[i].CampaignName + " Failed Export " + "\n LeadID=" + salesExport[i].LeadID + "\n SaleID=" + salesExport[i].ID, System.Diagnostics.EventLogEntryType.Warning);
                }
            }
            evLogger.LogEvent("Campaign Name: FNBAD\n Total: " + total.ToString() + "\n Success: " + success.ToString() + "\n Fail: " + fail.ToString(), System.Diagnostics.EventLogEntryType.SuccessAudit);
        }
    }
}
