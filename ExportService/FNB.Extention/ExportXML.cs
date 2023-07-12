using System;
using System.Text;
using BusinessLogic;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ExportService.FNB.Extention
{
    public class ExportXML
    {
        public static string MakeExportXML(ref Users User, ref PersonalDetails saleToExport)
        {
            List<Campaign> campaign = Campaign.GetCampaignsByCampaignName("RCUNITRA");
            int campaignId = campaign[0].CampaignID;

            Sales salelist = Sales.GetSale(campaignId);
            int saleID = salelist.ID;

            List<Sales> salesExport = Sales.GetAllSaleByCampaignID(campaign[0].CampaignID);
            int total = salesExport.Count;

            PersonalDetails personalDetails = PersonalDetails.GetPersonalDetails(salesExport[0].ID);
            BankDetails bankDetails = BankDetails.GetBankDetails(salesExport[0].ID);

            Users users = Users.GetUserByID(salesExport[0].UserID);
            List<SubMemberDetails> subMemberDetailsBeneficiary = SubMemberDetails.GetSubMembersBeneficiaryDetails(campaign[0].CampaignID);
            List<SubMemberDetails> subMemberDetailsSpouse = SubMemberDetails.GetSubMembersSpouseDetails(campaign[0].CampaignID);

            StringBuilder xml = new StringBuilder();

            xml.AppendLine("<?xml version=\"1.0\" ?>");
            xml.AppendLine("<customer>");
            xml.AppendLine(new XElement("refnumber", salesExport[0].ID.ToString()).ToString());
            xml.AppendLine(new XElement("subChannel", "BPS").ToString());
            xml.AppendLine(new XElement("campaignNo", campaign[0].CampaignID).ToString());  //GetValueByKey(saleData, "FNB_CAMPAIGN_ID")).ToString());
            xml.AppendLine(new XElement("leadsno", salesExport[0].LeadID).ToString()); //GetValueByKey(saleData, "FNB_LEAD_ID")).ToString());
            xml.AppendLine(new XElement("productCode", "FIS").ToString());  //CampaignSetting1
            xml.AppendLine(new XElement("subProdCode", "PA").ToString());   //CampaignSetting2

            xml.AppendLine(new XElement("salesperson", salesExport[0].CaptureBy).ToString());
            xml.AppendLine(new XElement("salespersonID", users.IDNumber).ToString());
            xml.AppendLine(new XElement("salespersonno", users.EmployeeNo).ToString());

            xml.AppendLine(new XElement("capturedby", salesExport[0].CaptureBy).ToString());
            xml.AppendLine(new XElement("capturedbyno", users.EmployeeNo).ToString());
            xml.AppendLine(new XElement("capturedDate", salesExport[0].CaptureDate.ToString("yyyyMMdd")).ToString());

            xml.AppendLine(new XElement("grossIncome", personalDetails.Email).ToString());  
            xml.AppendLine(new XElement("email", personalDetails.Email).ToString());  

            string cellNo = personalDetails.TelCell.ToString(); 
            string workNo = personalDetails.TelWork.ToString(); 
            string homeNo = personalDetails.TelHome.ToString(); 

            if (cellNo.Length == 9) cellNo = "0" + cellNo;
            if (workNo.Length == 9) workNo = "0" + workNo;
            if (homeNo.Length == 9) homeNo = "0" + homeNo;

            if (cellNo.Length == 0)
            {
                xml.AppendLine("<cellNo/>");
            }
            else
            {
                xml.AppendLine(new XElement("cellNo", cellNo).ToString());
            }

            if (workNo.Length == 0)
            {
                xml.AppendLine("<workNo/>");
            }
            else
            {
                xml.AppendLine(new XElement("workNo", workNo).ToString());
            }

            if (homeNo.Length == 0)
            {
                xml.AppendLine(new XElement("homeNo", "0000000000").ToString());
            }
            else
            {
                xml.AppendLine(new XElement("homeNo", homeNo).ToString());
            }

            xml.AppendLine(new XElement("postaddstreet", personalDetails.Address1).ToString());  
            xml.AppendLine(new XElement("postaddsuburb", personalDetails.City).ToString()); 
            xml.AppendLine(new XElement("postaddcity", "").ToString());
            xml.AppendLine(new XElement("postaddcode", personalDetails.PostalCode).ToString()); 

            #region Policy Holder
            xml.AppendLine("<member>");

            xml.AppendLine(new XElement("relationship", "ph").ToString());
            xml.AppendLine(new XElement("name", personalDetails.Title).ToString() + " " + (personalDetails.FirstName).ToString() + " " + (personalDetails.FirstName.ToString()));
            xml.AppendLine(new XElement("middleName", personalDetails.Title).ToString());
            xml.AppendLine(new XElement("birthdate", personalDetails.DateOfBirth).ToString().Replace("-", "").Replace("/", "")).ToString();
            xml.AppendLine(new XElement("idType", "rsaid").ToString()); //CamapaignSetting3
            xml.AppendLine(new XElement("idNumber", personalDetails.IDNumber).ToString()); 
            xml.AppendLine(new XElement("gender", personalDetails.Gender).ToString()); 

            //xml.AppendLine(new XElement("coverAmount", GetValueByKey(saleData, "PH_BENEFIT")).ToString());
            //xml.AppendLine(new XElement("premium", GetValueByKey(saleData, "PH_PREMIUM_HIDDEN")).ToString());

            xml.AppendLine("</member>");
            #endregion

            #region Beneficiary
            xml.AppendLine("<member>");

            xml.AppendLine(new XElement("relationship", "be").ToString());
            xml.AppendLine(new XElement("name", subMemberDetailsBeneficiary[0].Title.ToString()) + " " + subMemberDetailsBeneficiary[0].FirstName.ToString() + " " + subMemberDetailsBeneficiary[0].Surname.ToString()).ToString();
            xml.AppendLine(new XElement("middleName", subMemberDetailsBeneficiary[0].SecondName).ToString()); 

            string idNo = subMemberDetailsBeneficiary[0].IDNumber.ToString();    
            string dob = subMemberDetailsBeneficiary[0].DateOfBirth.ToString();  

            if (dob == "")
            {
                xml.AppendLine(new XElement("birthdate", DateOfBirthVAlidation.IDtoDOB(idNo).ToString("yyyyMMdd")).ToString());
            }
            else
            {
                xml.AppendLine(new XElement("birthdate", subMemberDetailsBeneficiary[0].DateOfBirth.ToString().Replace("-", "").Replace("/", "")).ToString());
            }

            xml.AppendLine(new XElement("idType", "rsaid").ToString());
            xml.AppendLine(new XElement("idNumber", subMemberDetailsBeneficiary[0].IDNumber).ToString()); 
            xml.AppendLine(new XElement("gender", subMemberDetailsBeneficiary[0].Gender).ToString());

            xml.AppendLine("</member>");
            #endregion

            #region Spouse
            if (subMemberDetailsSpouse[0].Surname.ToString() != "" && subMemberDetailsSpouse[0].Surname.ToString() != null)
            {
                xml.AppendLine("<member>");

                xml.AppendLine(new XElement("relationship", "sp").ToString());
                xml.AppendLine(new XElement("name", subMemberDetailsSpouse[0].Title.ToString()) + " " + subMemberDetailsSpouse[0].FirstName.ToString() + " " + subMemberDetailsSpouse[0].Surname.ToString()).ToString();
                xml.AppendLine(new XElement("middleName", subMemberDetailsSpouse[0].Surname).ToString()); 

                string idNoSP = subMemberDetailsSpouse[0].IDNumber.ToString(); 
                string dobSP = subMemberDetailsSpouse[0].DateOfBirth.ToString();

                if (dob == "")
                {
                    xml.AppendLine(new XElement("birthdate", DateOfBirthVAlidation.IDtoDOB(idNoSP).ToString("yyyyMMdd")).ToString());
                }
                else
                {
                    xml.AppendLine(new XElement("birthdate", subMemberDetailsSpouse[0].DateOfBirth.ToString().Replace("-", "").Replace("/", "")).ToString());
                }

                xml.AppendLine(new XElement("idType", "rsaid").ToString());
                xml.AppendLine(new XElement("idNumber", subMemberDetailsSpouse[0].IDNumber).ToString()).ToString();
                xml.AppendLine(new XElement("gender", subMemberDetailsBeneficiary[0].Gender).ToString()); 
                //xml.AppendLine(new XElement("coverAmount", ((int.Parse(GetValueByKey(saleData, "PH_BENEFIT"))) / 2).ToString("#.00")).ToString());
                xml.AppendLine("<premium></premium>");

                xml.AppendLine("</member>");
            }
            #endregion

            #region children
            for (int i = 1; i < 6; i++)
            {
                string surname = ""; //GetValueByKey(saleData, "CH" + i.ToString() + "_SURNAME");  TODO
                if (surname != "" && surname != null)
                {
                    xml.AppendLine("<member>");

                    xml.AppendLine(new XElement("relationship", "ch").ToString());  
                    //xml.AppendLine(new XElement("name", GetValueByKey(saleData, "CH" + i.ToString() + "_TITLE") + " " + GetValueByKey(saleData, "CH" + i.ToString() + "FIRST_NAME") + " " + GetValueByKey(saleData, "CH" + i.ToString() + "_SURNAME")).ToString());
                    xml.AppendLine("<middleName/>");
                    //xml.AppendLine(new XElement("birthdate", GetValueByKey(saleData, "CH" + i.ToString() + "_DATE_OF_BIRTH").Replace("-", "").Replace("/", "")).ToString());
                    xml.AppendLine("<idType/>");
                    xml.AppendLine("<idNumber/>");
                    //xml.AppendLine(new XElement("gender", GetValueByKey(saleData, "CH" + i.ToString() + "_GENDER")).ToString());


                    //TODO : A child member detailss
                    string dobCH = "";//GetValueByKey(saleData, "CH" + i.ToString() + "_DATE_OF_BIRTH");
                    double age = 0;
                    DateTime cDate;
                    if (DateTime.TryParse(dobCH, out cDate))
                    {
                        age = (salesExport[0].CaptureDate - cDate).TotalDays / 365.25;
                    }

                    string childCover = string.Empty;

                    if (age < 6)
                    {
                        childCover = "5000.00";
                    }
                    else if (age >= 6 && age <= 17)
                    {
                        childCover = "10000.00";
                    }

                    xml.AppendLine(new XElement("coverAmount", childCover).ToString());
                    xml.AppendLine("<premium></premium>");
                    xml.AppendLine("</member>");
                }
            }
            #endregion

            #region banking details

            xml.AppendLine(new XElement("branchCode", "250655").ToString());
            xml.AppendLine(new XElement("accountNumber", salesExport[0].ID).ToString()); //saleToExport.AccountNoBySaleID).ToString()); //bankDetails
            xml.AppendLine(new XElement("accountType", DecodeAccountType.DecodeAccountTypeExport(bankDetails.AccountType)).ToString());
            xml.AppendLine(new XElement("paydate", bankDetails.FirstDebitDay).ToString());    
            xml.AppendLine(new XElement("duedate", MakeDateFromDay.MakeDateFromDayExport(Convert.ToString(bankDetails.FirstDebitDay))).ToString()); 

            #endregion
            xml.AppendLine("</customer>");
            return xml.ToString();
        }
    }
}
