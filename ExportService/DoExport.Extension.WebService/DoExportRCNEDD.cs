using BusinessLogic;
using ExportService.RoadCover.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;

namespace ExportService.DoExport.Extension.WebService
{
    public class DoExportRCNEDD
    {
        public static bool DoExport(Sales exportSale, string source)
        {
            bool retVal = false;

            List<Campaign> campaign = Campaign.GetCampaignsByCampaignName("RCNEDD");
            int campaignId = campaign[0].CampaignID;

            Sales salelist = Sales.GetSale(campaignId);
            List<Sales> salesExport = Sales.GetAllSaleByCampaignID(campaign[0].CampaignID);

            PersonalDetails personalDetails = PersonalDetails.GetPersonalDetails(salesExport[0].ID);
            BankDetails bankDetails = BankDetails.GetBankDetails(salesExport[0].ID);

            if (salesExport[0].Found)
            {

                string failMessage = string.Empty;

                try
                {
                    RC_NED.Service10SoapClient wsClient = new RC_NED.Service10SoapClient();
                    
                    StringBuilder member = new StringBuilder();

                    string strMemberNo = salesExport[0].Extra1 ?? "";      //Extra1               //KeyValues.GetValueByKey(saleData, "ECC_NUMBER") ?? "";    
                    string strTitle = personalDetails.Title ?? "";                                
                    string strName = personalDetails.FirstName ?? "";                            
                    string strSurname = personalDetails.Surname ?? "";                          
                    string strBirthDate = Convert.ToString(personalDetails.DateOfBirth) ?? "".Replace("-", "/");  //(KeyValues.GetValueByKey(saleData, "DOB") ?? "").Replace("-", "/");
                    string strID = personalDetails.IDNumber ?? "";                               
                    string strTelCell = personalDetails.TelCell ?? "";                            
                    string strEmail = personalDetails.Email ?? "";                               
                    string strPO1 = personalDetails.Address1 ?? "";                               
                    string strPO2 = personalDetails.Address2 ?? "";                               
                    string strCity = personalDetails.City ?? "";                                 

                    string strPO3 = personalDetails.Address3 ?? "" + " " + personalDetails.Address4 ?? "" + "" + strCity.Trim(); //((KeyValues.GetValueByKey(saleData, "ADDRESS3") ?? "") + " " + (KeyValues.GetValueByKey(saleData, "ADDRESS4") ?? "") + " " + strCity).Trim();

                    string strPOCode = personalDetails.PostalCode ?? "";                          
                    string strPaymethod = "A - MAG TAPE";
                    string strBankName = bankDetails.BankName ?? "";                              
                    string strBankCode = bankDetails.BranchCode ?? "";                             
                    string strAccNumber = bankDetails.AccountNumber ?? "";                        

                    if (strAccNumber.Trim().Substring(0, 1) == "*")
                    {
                        //strAccNumber = salesExport.GetAccountNoByRegOrID(strID);
                    }

                    string strAccType = Accounts.DecodeAccountType(bankDetails.AccountType ?? "");  

                    string strAccDetails = bankDetails.AccountName ?? "";                           
                    string strMonthlyAction = Convert.ToString(bankDetails.FirstDebitDay) ?? "";    

                    //TODO :TOTAL_PREMIUM_HIDDEN
                    string strSetPremium = "";//"R" + KeyValues.GetValueByKey(saleData, "TOTAL_PREMIUM_HIDDEN") ?? "39.00";

                    string strJoinRef = exportSale.ID.ToString();

                    string strNotes = DateTime.Now.ToString("yyyy/MM/dd");
                    string strCommDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy/MM/dd");

                    string strRep = string.Empty;

                    string strPaymentFrequence = "Monthly";
                    string strBranch = "ECC";
                    string strPassport =  personalDetails.PassportNumber ?? "";                   
                    //TODO
                    string strContactMethod = "";                                                 //KeyValues.GetValueByKey(saleData, "CONTACTCHOICE") ?? "";
                    string strTelFax = personalDetails.TelFax ?? "";                             
                    string strTelWork = personalDetails.TelWork ?? "";                            
                    //TODO
                    string strAppDate = "";                                                       //saleToExport.CreatedDate.ToString("yyyy/MM/dd");
                    string strAgent = "NED";

                    bool bLastDay = false;
                    //TODO
                    string str_rep_code_notes = "";                                               //KeyValues.GetValueByKey(saleData, "LEAD_REP_CODE") ?? "";

                    if (str_rep_code_notes == "")
                    { strNotes = "NED006(2018) - MAY 2018|"; }
                    else { strNotes = str_rep_code_notes + "|"; }

                    strRep = RepCode.GetRepCode(strNotes);

                    strNotes = strNotes + member.ToString();
                    if (strNotes.Substring(strNotes.Length - 1, 1) == "|")
                    {
                        strNotes = strNotes.Substring(0, strNotes.Length - 1);
                    }

                    string strInit = string.Empty;
                    string strMaritalStatus = string.Empty;
                    string strGender = string.Empty;
                    string strTelHome = string.Empty;
                    string strBenName = string.Empty;
                    string strBenID = string.Empty;
                    string strJoinFeeDate = string.Empty;
                    string strPersalRef = string.Empty;
                    string strOccupation = string.Empty;
                    string strPersalNo = string.Empty;
                    string strEmployer = string.Empty;
                    string strEmpDate = string.Empty;
                    string strEmpdDate = string.Empty;
                    string strNationality = string.Empty;
                    string strBarcode = string.Empty;
                    string strSetCover = string.Empty;
                    string strDeathDate = string.Empty;
                    string strUserRef1 = string.Empty;
                    string strUserRef2 = string.Empty;

                    string strActve = string.Empty;

                    string exportResponse = string.Empty;
                    if (ServiceValidator.IstServiceReady())
                    {
                        exportResponse = wsClient.fUpdateMember(ServiceValidator.GetImportServiceHeader(), strMemberNo, strJoinRef, strAppDate, strCommDate,
                                                                strTitle, strInit, strName, strSurname, strBirthDate, strID, strPassport,
                                                                strMaritalStatus, strGender, strTelHome, strTelWork, strTelCell, strTelFax,
                                                                strEmail, strPO1, strPO2, strPO3, strPOCode, strPO1, strPO2, strPO3,
                                                                strPOCode, strNotes, strBenName, strBenID, strBankName, strBranch,
                                                                strBankCode, strAccNumber, strAccType, strAccDetails, strJoinFeeDate,
                                                                strMonthlyAction, bLastDay, strPaymentFrequence, strPaymethod, strPersalNo,
                                                                strPersalRef, strOccupation, strEmployer, strEmpDate, strNationality,
                                                                strSetPremium, strSetCover, strAgent, strBenID, strBarcode, strContactMethod,
                                                                strDeathDate, strUserRef1, strUserRef2, strActve);

                        if (!Validator.ValidateExportResults("RCNEDD", exportResponse, ref exportSale, ref personalDetails))
                        {
                            return retVal;
                        }

                        for (int i = 1; i < 6; i++)
                        {
                            List<SubMemberDetails> subMemberDetailsRider = SubMemberDetails.GetSubMembersRiderDetails(campaign[0].CampaignID);

                            string relation = subMemberDetailsRider[0].RelationShipTypeName + i.ToString() ?? "";                            
                            string dob = subMemberDetailsRider[0].DateOfBirth + i.ToString() ?? "";                    

                        if (relation != "")
                            {
                                member.Append("[" + dob + " for INDIVIDUAL RIDER]");
                                string ind_uniqueid = salesExport[0].ID + "_ind_" + i.ToString();                      
                                
                                string ind_strName = subMemberDetailsRider[0].FirstName + i.ToString() ?? "";                                                              
                                string ind_strSurname = subMemberDetailsRider[0].Surname + i.ToString() ?? "";                                                            
                                string ind_strDOB = subMemberDetailsRider[0].DateOfBirth + i.ToString() ?? "";                                                                
                                DateTime indDOB = DateTime.MinValue;

                                if (DateTime.TryParse(ind_strDOB, out indDOB))
                                {
                                    string memberRelResponse = wsClient.fUpdateRelation(ServiceValidator.GetImportServiceHeader(), strMemberNo, strJoinRef
                                        , "", strAppDate, strCommDate, ind_strName, ind_strSurname, indDOB.ToString("yyyyMMdd"),
                                        "", ind_strDOB, "", "X - EXTENDED", strNotes, "");

                                    if (!Validator.ValidateExportResults("RCNEDD", memberRelResponse, ref exportSale, ref personalDetails))
                                    {
                                        return retVal;
                                    }
                                }
                            }
                        }

                        for (int i = 1; i < 6; i++)
                        {
                         
                            List<SubMemberDetails> subMemberDetailsFamily = SubMemberDetails.GetSubMembersFamilyRiderDetails(campaign[0].CampaignID);

                            string relation = subMemberDetailsFamily[0].RelationShipTypeName + i.ToString() ?? "";                         
                            string dob = subMemberDetailsFamily[0].DateOfBirth + i.ToString() ?? "";                                          

                            if (relation != "")
                            {
                                member.Append("[" + dob + " for FAMILY RIDER]");
                                member.Append("[" + dob + " for INDIVIDUAL RIDER]");

                                string ind_uniqueid = salesExport[0].ID + "_ind_" + i.ToString();                 
                                string ind_strName = subMemberDetailsFamily[0].FirstName + i.ToString() ?? "";                                                           
                                string ind_strSurname = subMemberDetailsFamily[0].Surname + i.ToString() ?? "";                                                        
                                string ind_strDOB = subMemberDetailsFamily[0].DateOfBirth + i.ToString() ?? "";                                                           

                                DateTime indDOB = DateTime.MinValue;

                                if (DateTime.TryParse(ind_strDOB, out indDOB))
                                {
                                    string memberRelResponse = wsClient.fUpdateRelation(ServiceValidator.GetImportServiceHeader(), strMemberNo, strJoinRef
                                        , "", strAppDate, strCommDate, ind_strName, ind_strSurname, indDOB.ToString("yyyyMMdd"),
                                        "", ind_strDOB, "", "X - EXTENDED", strNotes, "");

                                    if (!Validator.ValidateExportResults("RCNEDD", memberRelResponse, ref exportSale, ref personalDetails))
                                    {
                                        return retVal;
                                    }
                                }
                            }
                        }
                    }
                    if (Validator.ValidateExportResults(source, exportResponse, ref exportSale, ref personalDetails))
                    {
                        //retVal = saleToExport.PassSale("System", "Sale exported successfully.", DateTime.Now, exportSale.CampaignID, "Pre-RecUpload");
                        //exportSale.MarkAsCompleted();
                    }
                }
                catch (Exception ex)
                {
                    evLogger.LogEvent("Campaign Name " + ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            salesExport = null;
            return retVal;
        }
    }
}
