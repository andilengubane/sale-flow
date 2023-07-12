using System.Text;
using BusinessLogic;
using System.Xml.Linq;
using System.Collections.Generic;
using System;

namespace ExportService.FNB.Extention
{
    public class ExportMakeChildrenXML
    {
        public static void MakeChildrenXML(ref StringBuilder xml)
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
            List<SubMemberDetails> subMemberDetailsChild = SubMemberDetails.GetSubMembersChildDetails(campaign[0].CampaignID);  

            for (int i = 1; i < 7; i++)
            {
                string action = i.ToString() + "_LIFE_ACTION" ?? "";   // GetValueByKey(saleData, i.ToString() + "_LIFE_ACTION");
                switch (action)
                {
                    case "":
                    case null:
                        break;
                    default:
                        action = "NC";
                        break;
                }

                string dob = Convert.ToString(subMemberDetailsChild[0].DateOfBirth);                    //GetValueByKey(saleData, i.ToString() + "_DATE_OF_BIRTH") ?? "";

                if (action == "" || dob == "")
                {
                    return;
                }

                string spCover = (int.Parse(( "PH_BENEFIT") ?? "0") / 2).ToString();  //(int.Parse(GetValueByKey(saleData, "PH_BENEFIT") ?? "0") / 2).ToString();

                string seq =  i.ToString() + "_SEQ" ?? "";                            //GetValueByKey(saleData, i.ToString() + "_SEQ") ?? "";

                if (action == "DE")
                {
                    if (action == "DE" || seq == "")
                    {
                        seq =  "CH" + i.ToString();                                  //GetValueByKey(ADU_LIFE_DICT, "CH" + i.ToString());
                    }
                    else
                    {
                        seq = i.ToString() + "_SEQ" ?? "";                          //GetValueByKey(archiveData, i.ToString() + "_SEQ");
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

                    xml.AppendLine(new XElement("relationship", "ch").ToString());
                    xml.AppendLine(new XElement("name",  i.ToString() + subMemberDetailsChild[0].FirstName ?? "") + " " + i.ToString() + subMemberDetailsChild[0].Surname ?? "").ToString();     //GetValueByKey(archiveData, i.ToString() + "_FIRST_NAME") + " " + i.ToString() + GetValueByKey(archiveData, "_SURNAME")).ToString())
                    xml.AppendLine(new XElement("birthdate",  i.ToString() + Convert.ToString(subMemberDetailsChild[0].DateOfBirth).Replace("-", "").Replace("/", "")).ToString());              //GetValueByKey(archiveData, i.ToString() + "_DATE_OF_BIRTH").Replace("-", "").Replace("/", "")).ToString());
                    xml.AppendLine("<idNumber/>");
                    xml.AppendLine(new XElement("gender", i.ToString() + subMemberDetailsChild[0].Gender ?? "").ToString());                                                                    //i.ToString() + GetValueByKey(archiveData, "_GENDER")).ToString()
                    xml.AppendLine(new XElement("seq", seq).ToString());

                    xml.AppendLine("</member>");
                }

                if (action == "AD" || action == "CH")
                {
                    if (seq == "")
                    {
                        seq = "CH" ?? "" + i.ToString();                                                                    //GetValueByKey(ADU_LIFE_DICT, "CH" + i.ToString());
                    }

                    xml.AppendLine("<member>");

                    xml.AppendLine(new XElement("relationship", "ch").ToString());
                    xml.AppendLine(new XElement("name",  i.ToString() + subMemberDetailsChild[0].FirstName ?? "") + " " + i.ToString() + subMemberDetailsChild[0].Surname ?? "").ToString();     //GetValueByKey(saleData, i.ToString() + "_FIRST_NAME") + " " + i.ToString() + GetValueByKey(saleData, "_SURNAME")).ToString());
                    xml.AppendLine(new XElement("birthdate",  i.ToString() + Convert.ToString(subMemberDetailsChild[0].DateOfBirth).Replace("-", "").Replace("/", "")).ToString());              //GetValueByKey(saleData, i.ToString() + "_DATE_OF_BIRTH").Replace("-", "").Replace("/", "")).ToString());
                    xml.AppendLine("<idNumber/>");
                    xml.AppendLine(new XElement("gender", i.ToString() + subMemberDetailsChild[0].Gender ?? "").ToString());                                                                     //i.ToString() + GetValueByKey(saleData, "_GENDER")).ToString());
                    xml.AppendLine(new XElement("seq", seq).ToString());

                    xml.AppendLine("</member>");
                }
            }
        }
    }
}
