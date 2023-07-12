
using BusinessLogic;

namespace ExportService.FNB.Extention
{
    public class FailAction
    {
        public static bool FailActionExport(string source, string error, ref Sales exportSale, ref PersonalDetails saleToExport)
        {
            bool returnVal = false;

            ErrorService.ErrorSearchSoapClient errorClient = new ErrorService.ErrorSearchSoapClient();
            ErrorService.GetActionResponse handler = errorClient.GetActions(error, source);
            returnVal = !handler.Ignore;

            if (!handler.Ignore)
            {
                if (handler.IsIT)
                {
                    //saleToExport.RejectSale(DateTime.Now, exportSale.CampaignID, "SubRetry1", handler.Result);
                    //ClientDetails_WorkflowAction wMessage = saleToExport.WorkFlowActionCURRENT;
                    //ClientDetails_WorkflowActionMessages.CreateWorkflowActionMessages(handler.Result, "System", wMessage.ID, exportSale.CampaignName);
                    //exportSale.MarkAsFailed();
                }
                else
                {
                    //saleToExport.RejectSale(DateTime.Now, exportSale.CampaignID, "VET-RETRY", handler.Result);
                    //ClientDetails_WorkflowAction wMessage = saleToExport.WorkFlowActionCURRENT;
                    //ClientDetails_WorkflowActionMessages.CreateWorkflowActionMessages(handler.Result, "System", wMessage.ID, exportSale.CampaignName);
                    //exportSale.MarkAsFailed();
                }
            }
            errorClient.Close();

            return returnVal;
        }
    }
}
