using System;
using Utils.Logger;
using BusinessLogic;
using ExportService.FNB.Extention;

namespace ExportService.DoExport.Extension.WebService
{
    public class DoExportFNBADU
    {
        public static bool DoExport(Sales exportSale)
        {
            bool retVal = false;

            PersonalDetails personalDetails = new PersonalDetails();

            if (exportSale.Found)
            {
                String failMessage = String.Empty;
                try
                {
                    Users theAgent = Users.GetUserByID(exportSale.ID);
                    if (theAgent.Found)
                    {
                        FNB_AD.ExportPassthroughWSClient wsClient = new FNB_AD.ExportPassthroughWSClient();

                        string exportRecord = ExportXML.MakeExportXML(ref theAgent, ref personalDetails);
                        string exportResponse = wsClient.ExportSale(exportRecord);

                        if (ValidateExportResult.ExportResults("FNBAD", exportResponse, ref exportSale, ref personalDetails))
                        {
                            //TODO : flag a sale that has passed.
                            //retVal = saleToExport.PassSale("System", "Sale exported successfully.", DateTime.Now, exportSale.CampaignID);
                            //exportSale.MarkAsCompleted();
                        }
                    }
                    else
                    {
                        //FailAction("FNBAD", "FNB Agent not found", ref exportSale, ref saleToExport);
                    }
                }
                catch (Exception ex)
                {
                    //Log a fail event on the windows event viewer 
                    evLogger.LogEvent("Campaign Name " + ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
                }
            }

            exportSale = null;

            return retVal;
        }
    }
}
