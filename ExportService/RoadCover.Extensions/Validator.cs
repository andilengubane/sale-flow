using System;
using System.Xml;
using BusinessLogic;

namespace ExportService.RoadCover.Extensions
{
    public class Validator
    {
        private static DateTime IDtoDOB(string idNumber)
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

        public static bool ValidateExportResults(string source, string schemeResult, ref Sales exportSale, ref PersonalDetails saleToExport)
        {
            bool retval = false;
            try
            {
                XmlDocument theDoc = new XmlDocument();
                theDoc.LoadXml(schemeResult);
                XmlNodeList theNode = theDoc.SelectNodes("NewDataSet/status/Message");
                if (theNode.Count > 0)
                {
                    if (theNode[0].InnerText.Split(char.Parse("|"))[0] == "OK")
                    {
                        retval = true;
                    }
                    else
                    {
                        retval = !FailAction(source, theNode[0].InnerText.Split(char.Parse("|"))[1], ref exportSale, ref saleToExport);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;
        }

        private static bool FailAction(string source, string error, ref Sales exportSale, ref PersonalDetails saleToExport)
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
