using System;
using System.Text;
using BusinessLogic;
using System.Xml.Linq;
using System.Collections.Generic;
using ExportService.FNB.Extention.FNB.Services;

namespace ExportService.FNB.Extention
{
    public class ExportMakeExportXML
    {
        public static string MakeExportXML(ref Users theAgent, ref PersonalDetails personalDetails, ref Sales exportSale)
        {
            List<Campaign> campaign = Campaign.GetCampaignsByCampaignName("FNBADU");
            int campaignId = campaign[0].CampaignID;

            Sales salelist = Sales.GetSale(campaignId);
            int saleID = salelist.ID;

            List<Sales> salesExport = Sales.GetAllSaleByCampaignID(campaign[0].CampaignID);

            PersonalDetails personalDetailsModel = PersonalDetails.GetPersonalDetails(salesExport[0].ID);
            BankDetails bankDetails = BankDetails.GetBankDetails(salesExport[0].ID);

            Users usersModel = Users.GetUserByID(salesExport[0].UserID);


            //TODO
            //List<KeyValuePair<string, string>> archiveData = GetFNBADUArchiveValues(salesExport[0].ID.ToString());

            StringBuilder xml = new StringBuilder();

            xml.AppendLine("<?xml version=\"1.0\" ?>");
            xml.AppendLine("<customer>");
            xml.AppendLine(new XElement("campaignNo", campaign[0].CampaignID).ToString());                 //"FNB_CAMPAIGN_ID"
            xml.AppendLine(new XElement("leadsno", salesExport[0].LeadID ).ToString());                    //"FNB_LEAD_ID" ?? ""
            xml.AppendLine(new XElement("capturedDate", salesExport[0].CaptureDate.ToString("yyyyMMdd")).ToString());
            xml.AppendLine(new XElement("grossIncome", personalDetailsModel.GrossIncome).ToString());      //"PH_GROSS_INCOME"
            xml.AppendLine(new XElement("debitAmount", "TOTAL_PREMIUM_HIDDEN" ?? "").ToString());
            xml.AppendLine(new XElement("duedate", MakeDateFromDay.MakeDateFromDayExport(Convert.ToString(bankDetails.FirstDebitDay) ?? "")).ToString()); //"DEBIT_ORDER_DATE"
            xml.AppendLine(new XElement("paydate", "DEBIT_ORDER_DATE" ?? "").ToString());

            #region policy holder local

            string action = "PH_LIFE_ACTION" ?? "";
            switch (action)
            {
                case "":
                case null:
                    break;
                default:
                    action = "NC";
                    break;
            }

            string dob = Convert.ToString(personalDetails.DateOfBirth);

            if (action == "" || dob == "")
            {
                return "";
            }

            if (action == "DE" || action == "NC")
            {
                if (action == "NC") action = "";

                string ph_cover = "PH_BENEFIT" ?? "";
                string ph_seq =  "PH_SEQ" ?? "";

                if (action == "DE" && ph_seq == "")
                {
                    ph_seq =  "PH" ?? "";
                }

                xml.AppendLine("<member>");

                if (action == "")
                {
                    xml.AppendLine("<action/>");
                }
                else
                {
                    xml.AppendLine(new XElement("action", action).ToString());
                }

                xml.AppendLine(new XElement("relationship", "ph").ToString());
                xml.AppendLine(new XElement("name",  personalDetails.Title ?? "" + " " + personalDetails.FirstName ?? "" + " " +  personalDetails.Surname ?? "").ToString());
                xml.AppendLine(new XElement("middleName", personalDetails.SecondName ?? "").ToString());
                xml.AppendLine(new XElement("birthdate", Convert.ToString(personalDetails.DateOfBirth).Replace("-", "").Replace("/", "")).ToString());
                xml.AppendLine(new XElement("idNumber", personalDetails.IDNumber ?? "").ToString());
                xml.AppendLine(new XElement("gender",  personalDetails.Gender ?? "").ToString());
                xml.AppendLine(new XElement("coverAmount", "PH_BENEFIT" ?? "").ToString());
                xml.AppendLine(new XElement("seq", ph_seq).ToString());

                xml.AppendLine("</member>");
            }
            else if (action == "AD" || action == "CH")
            {
                string ph_cover = "PH_BENEFIT" ?? "";
                string ph_seq =  "PH_SEQ" ?? "";

                if (ph_seq == "")
                {
                    ph_seq =  "PH" ?? "";
                }

                xml.AppendLine("<member>");

                xml.AppendLine(new XElement("action", action).ToString());
                xml.AppendLine(new XElement("relationship", "ph").ToString());
                xml.AppendLine(new XElement("name", personalDetails.Title ?? "" + " " + personalDetails.FirstName ?? "" + " " + personalDetails.Surname ?? "").ToString());
                xml.AppendLine(new XElement("middleName", personalDetails.SecondName ?? "").ToString());
                xml.AppendLine(new XElement("birthdate", Convert.ToString(personalDetails.DateOfBirth).Replace("-", "").Replace("/", "")).ToString());
                xml.AppendLine(new XElement("idNumber", personalDetails.IDNumber ?? "").ToString());
                xml.AppendLine(new XElement("gender", personalDetails.Gender ?? "").ToString());
                xml.AppendLine(new XElement("coverAmount",  "PH_BENEFIT" ?? "").ToString());
                xml.AppendLine(new XElement("seq", ph_seq).ToString());

                xml.AppendLine("</member>");
            }
            else
            {
                FailAction.FailActionExport("FNBADU", "Policy Holder details not", ref exportSale, ref personalDetails);
            }
            #endregion

            #region beneficiary

            ExportMakeBeneficiaryXML.MakeBeneficiaryXML(ref xml, ref exportSale, ref personalDetails);

            #endregion

            #region spouse

            ExportMakeSpouseXML.MakeSpouseXML(ref xml);

            #endregion

            #region children

            ExportMakeChildrenXML.MakeChildrenXML(ref xml);

            #endregion

            xml.AppendLine("</customer>");
            return xml.ToString();
        }

    }
}
