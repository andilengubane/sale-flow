using System;
using System.Text;
using BusinessLogic;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ExportService.FNB.Extention.FNB.Services
{
    public class ExportMakeSpouseXML
    {
        public static void MakeSpouseXML(ref StringBuilder xml)
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

            //TODO : Add type (Child/Spouse/Beneficiary)
            List<SubMemberDetails> subMemberDetailsSpouse = SubMemberDetails.GetSubMembersSpouseDetails(campaign[0].CampaignID);

            string spSurname =  "SP_SURNAME" ?? "";
            if (spSurname == "") return;

            string action = "SP_LIFE_ACTION" ?? "";  //GetValueByKey(saleData,"SP_LIFE_ACTION");
            switch (action)
            {
                case "":
                case null:
                    break;
                default:
                    action = "NC";
                    break;
            }

            string dob = Convert.ToString(subMemberDetailsSpouse[0].DateOfBirth) ?? "";   //GetValueByKey(saleData, "SP_DATE_OF_BIRTH") ?? "";

            if (action == "" || dob == "")
            {
                return;
            }

            string idno =  subMemberDetailsSpouse[0].IDNumber ?? "";  //GetValueByKey(saleData, "SP_RSA_ID_NUMBER") ?? "";
            if (idno == "")
            {
                return;
            }

            string spCover = (int.Parse(("PH_BENEFIT") ?? "0") / 2).ToString();   //(int.Parse(GetValueByKey(saleData, "PH_BENEFIT") ?? "0") / 2).ToString();

            string seq =  "SP_SEQ" ?? "";       //GetValueByKey(saleData, "SP_SEQ") ?? "";

            if (action == "DE" || action == "NC")
            {
                if (action == "NC") action = "";

                if (action == "DE" || seq == "")
                {
                    seq =  "SP" ?? "";         //GetValueByKey(ADU_LIFE_DICT, "SP");
                }
                else
                {
                    seq = "SP_SEQ" ?? "";      //GetValueByKey(archiveData, "SP_SEQ");
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

                xml.AppendLine(new XElement("relationship", "sp").ToString());
                xml.AppendLine(new XElement("name", subMemberDetailsSpouse[0].Title ?? "" + " " + subMemberDetailsSpouse[0].FirstName ?? "" + " " + subMemberDetailsSpouse[0].FirstName ?? "").ToString());  //GetValueByKey(archiveData, "SP_TITLE") + " " + GetValueByKey(archiveData, "SP_FIRST_NAME") + " " + GetValueByKey(archiveData, "SP_SURNAME")).ToString());
                xml.AppendLine(new XElement("middleName", (subMemberDetailsSpouse[0].SecondName ?? "")).ToString());                                                      //GetValueByKey(archiveData, "SP_SECOND_NAME")).ToString());
                xml.AppendLine(new XElement("birthdate",  Convert.ToString(subMemberDetailsSpouse[0].DateOfBirth).Replace("-", "").Replace("/", "")).ToString());         //GetValueByKey(archiveData, "SP_DATE_OF_BIRTH").Replace("-", "").Replace("/", "")).ToString());
                xml.AppendLine(new XElement("idNumber", subMemberDetailsSpouse[0].IDNumber ?? "").ToString());                                                            //GetValueByKey(archiveData, "SP_RSA_ID_NUMBER")).ToString());
                xml.AppendLine(new XElement("gender", subMemberDetailsSpouse[0].Gender ?? "").ToString());                                                              //GetValueByKey(archiveData, "SP_GENDER")).ToString());
                xml.AppendLine(new XElement("seq", seq).ToString());
                xml.AppendLine(new XElement("coverAmount", spCover).ToString());

                xml.AppendLine("</member>");
            }

            if (action == "AD" || action == "CH")
            {
                if (seq == "")
                {
                    seq =  "BEN" ?? "";  //GetValueByKey(ADU_LIFE_DICT, "BEN");
                }

                xml.AppendLine("<member>");

                xml.AppendLine(new XElement("relationship", "be").ToString());
                xml.AppendLine(new XElement("name", subMemberDetailsSpouse[0].Title ?? "" + " " + subMemberDetailsSpouse[0].FirstName ?? "" + " " + subMemberDetailsSpouse[0].FirstName ?? "").ToString());  //GetValueByKey(saleData, "SP_TITLE") + " " + GetValueByKey(saleData, "SP_FIRST_NAME") + " " + GetValueByKey(saleData, "SP_SURNAME")).ToString());
                xml.AppendLine(new XElement("middleName", subMemberDetailsSpouse[0].SecondName ?? "").ToString());                                                  //GetValueByKey(saleData, "SP_SECOND_NAME")).ToString());
                xml.AppendLine(new XElement("birthdate", Convert.ToString(subMemberDetailsSpouse[0].DateOfBirth).Replace("-", "").Replace("/", "")).ToString());    //GetValueByKey(saleData, "SP_DATE_OF_BIRTH").Replace("-", "").Replace("/", "")).ToString());
                xml.AppendLine(new XElement("idNumber", subMemberDetailsSpouse[0].IDNumber ?? "").ToString());                                                      //GetValueByKey(saleData, "SP_RSA_ID_NUMBER")).ToString());
                xml.AppendLine(new XElement("gender", subMemberDetailsSpouse[0].Gender ?? "").ToString());                                                          //GetValueByKey(saleData, "SP_GENDER")).ToString());
                xml.AppendLine(new XElement("seq", seq).ToString());
                xml.AppendLine(new XElement("coverAmount", spCover).ToString());

                xml.AppendLine("</member>");
            }
        }
    }
}
