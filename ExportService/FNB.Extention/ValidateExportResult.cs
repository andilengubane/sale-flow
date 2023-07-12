using System;
using System.Xml;
using BusinessLogic;


namespace ExportService.FNB.Extention
{
    public class ValidateExportResult
    {
        public static bool ExportResults(string source, string schemeResult, ref Sales exportSale, ref PersonalDetails saleToExport)
        {
            bool retval = false;
            try
            {
                XmlDocument theDoc = new XmlDocument();
                theDoc.LoadXml(schemeResult);
                XmlNodeList theNode = theDoc.SelectNodes("response/commonData/resultmsg");
                if (theNode.Count > 0)
                {
                    if (theNode[0].InnerText == "SUCCESSFUL")
                    {
                        retval = true;
                    }
                    else
                    {
                        retval = !FailAction.FailActionExport(source, theNode[0].InnerText, ref exportSale, ref saleToExport);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;
        }
    }
}
