using System;
using System.Xml;
using Utils.Logger;
using System.Configuration;


namespace ExportService.RoadCover.Extensions
{
    public class ServiceValidator
    {
        internal static RC_NED.AuthHeader GetImportServiceHeader()
        {
            RC_NED.AuthHeader retVal = new RC_NED.AuthHeader();
            retVal.DataBase = ConfigurationManager.AppSettings["rcNedDatabase"];
            retVal.Username = ConfigurationManager.AppSettings["rcNedUsername"];
            retVal.Password = ConfigurationManager.AppSettings["rcNedPassword"];
            retVal.LoginUser = ConfigurationManager.AppSettings["rcNedLoginUser"];
            return retVal;
        }

        public static bool IstServiceReady()
        {
            bool retVal = false;
            try
            {
                RC_NED.Service10SoapClient soapClient = new RC_NED.Service10SoapClient();
                string x = soapClient.fIsDBOpen(GetImportServiceHeader());
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(x);
                if (doc.SelectSingleNode("//results/STATUS") != null)
                {
                    if (doc.SelectSingleNode("//results/STATUS").InnerText.Contains("TRUE"))
                    {
                        retVal = true;
                    }
                }
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }
            return retVal;
        }
    }
}
