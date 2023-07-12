using System;
using System.Text;
using BusinessLogic;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ExportService.FNB.Extention.FNB.Services
{
    public class ExportMakeBeneficiaryXML
    {
        public static void MakeBeneficiaryXML(ref StringBuilder xml, ref Sales exportSale, ref PersonalDetails saleToExport)
        {
            List<Campaign> campaign = Campaign.GetCampaignsByCampaignName("FNBADU");
            int campaignId = campaign[0].CampaignID;

            Sales salelist = Sales.GetSale(campaignId);
            int saleID = salelist.ID;

            List<Sales> salesExport = Sales.GetAllSaleByCampaignID(campaign[0].CampaignID);
            int total = salesExport.Count;

            PersonalDetails personalDetails = PersonalDetails.GetPersonalDetails(salesExport[0].ID);
            BankDetails bankDetails = BankDetails.GetBankDetails(salesExport[0].ID);

            Users users = Users.GetUserByID(salesExport[0].UserID);

            List<SubMemberDetails> subMemberDetailsBeneficiary = SubMemberDetails.GetSubMembersBeneficiaryDetails(campaign[0].CampaignID);


            string action = "BEN_LIFE_ACTION" ?? "";  //GetValueByKey(saleData, "BEN_LIFE_ACTION");
            switch (action)
            {
                case "":
                case null:
                    break;
                default:
                    action = "NC";
                    break;
            }

            string dob = Convert.ToString(subMemberDetailsBeneficiary[0].DateOfBirth) ?? ""; //GetValueByKey(saleData, "BEN_DATE_OF_BIRTH") ?? "";

            if (action == "" || dob == "")
            {
                return;
            }

            string idno = subMemberDetailsBeneficiary[0].IDNumber ?? "";  //GetValueByKey(saleData, "BEN_RSA_ID_NUMBER") ?? "";
            if (idno == "")
            {
                return;
            }

            string seq = "BEN_SEQ" ?? "";   //GetValueByKey(saleData, "BEN_SEQ") ?? "";

            if (action == "DE" || action == "NC")
            {
                if (action == "NC") action = "";

                if (action == "DE" || seq == "")
                {
                    seq = "BEN";  //GetValueByKey(ADU_LIFE_DICT, "BEN");
                }
                else
                {
                    seq =  "BEN_SEQ";  //GetValueByKey(archiveData, "BEN_SEQ");
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

                xml.AppendLine(new XElement("relationship", "be").ToString());
                xml.AppendLine(new XElement("name", subMemberDetailsBeneficiary[0].Title ?? "" + " " + subMemberDetailsBeneficiary[0].FirstName ?? "" + " " + subMemberDetailsBeneficiary[0].Surname ?? "").ToString());  //GetValueByKey(archiveData, "BEN_TITLE") + " " + GetValueByKey(archiveData, "BEN_FIRST_NAME") + " " + GetValueByKey(archiveData, "BEN_SURNAME")).ToString());
                xml.AppendLine(new XElement("middleName", subMemberDetailsBeneficiary[0].SecondName ?? "").ToString());                                                                         //GetValueByKey(archiveData, "BEN_SECOND_NAME")).ToString());
                xml.AppendLine(new XElement("birthdate",  Convert.ToString(subMemberDetailsBeneficiary[0].DateOfBirth).Replace("-", "").Replace("/", "")).ToString());                          //GetValueByKey(archiveData, "BEN_DATE_OF_BIRTH").Replace("-", "").Replace("/", "")).ToString());
                xml.AppendLine(new XElement("idNumber",  (subMemberDetailsBeneficiary[0].Title ?? "")).ToString());                                                                          //GetValueByKey(archiveData, "BEN_RSA_ID_NUMBER")).ToString());
                xml.AppendLine(new XElement("gender", subMemberDetailsBeneficiary[0].Gender ?? "").ToString());                                                                                 //GetValueByKey(archiveData, "BEN_GENDER")).ToString());
                xml.AppendLine(new XElement("seq", seq).ToString());

                xml.AppendLine("</member>");
            }

            else if (action == "AD" || action == "CH")
            {
                if (seq == "")
                {
                    seq =  "BEN" ?? "";  //GetValueByKey(ADU_LIFE_DICT, "BEN");
                }

                xml.AppendLine("<member>");

                xml.AppendLine(new XElement("relationship", "be").ToString());
                xml.AppendLine(new XElement("name", (subMemberDetailsBeneficiary[0].Title ?? "" + " " + subMemberDetailsBeneficiary[0].FirstName ?? "" + " " + subMemberDetailsBeneficiary[0].Surname ?? "")).ToString());  //GetValueByKey(saleData, "BEN_TITLE") + " " + GetValueByKey(saleData, "BEN_FIRST_NAME") + " " + GetValueByKey(saleData, "BEN_SURNAME")).ToString());
                xml.AppendLine(new XElement("middleName", (subMemberDetailsBeneficiary[0].SecondName ?? "")).ToString());                                                                         //GetValueByKey(saleData, "BEN_SECOND_NAME")).ToString());
                xml.AppendLine(new XElement("birthdate", Convert.ToString(subMemberDetailsBeneficiary[0].DateOfBirth).Replace("-", "").Replace("/", "")).ToString());                                              //GetValueByKey(saleData, "BEN_DATE_OF_BIRTH").Replace("-", "").Replace("/", "")).ToString());
                xml.AppendLine(new XElement("idNumber",  Convert.ToString(personalDetails.DateOfBirth) ?? "").ToString());                                                         //GetValueByKey(saleData, "BEN_RSA_ID_NUMBER")).ToString());
                xml.AppendLine(new XElement("gender", subMemberDetailsBeneficiary[0].Gender ?? "").ToString());                                                                                   //GetValueByKey(saleData, "BEN_GENDER")).ToString());
                xml.AppendLine(new XElement("seq", seq).ToString());

                xml.AppendLine("</member>");
            }
            else
            {
                FailAction.FailActionExport("FNBADU", "Beneficiary information missing", ref exportSale, ref saleToExport);
            }
        }
    }
}
