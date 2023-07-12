using System;
using System.Text;
using System.Collections.Generic;
using BusinessLogic;
using Utils.Logger;
using ExportService.RoadCover.Extensions;

namespace ExportService.DoExport.Extension.WebService
{
    public class DoExportRCAUDC
    {
        public static bool DoExport(Sales exportSale, string source)
        {
            bool retVal = false;

            List<Campaign> campaign = Campaign.GetCampaignsByCampaignName("RCAUDC");
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

                    string strMemberNo = salesExport[0].Extra1 ?? "";   
                    string strTitle = personalDetails.Title ?? "";         
                    string strName = personalDetails.FirstName ?? "";      
                    string strSurname = personalDetails.Surname ?? "";     
                    string strBirthDate = Convert.ToString(personalDetails.DateOfBirth) ?? "".Replace("-", "/"); ; 
                    string strID = personalDetails.IDNumber ?? "";         
                    string strTelCell = personalDetails.TelCell ?? "";     
                    string strEmail = personalDetails.Email ?? "";         
                    string strPO1 = personalDetails.Address1 ?? "";        
                    string strPO2 = personalDetails.Address2 ?? "";        
                    string strCity = personalDetails.City ?? "";           

                    string strPO3 = (personalDetails.Address3 ?? "" + " " + personalDetails.Address4 ?? "" + " " + strCity).Trim();

                    string strPOCode = personalDetails.PostalCode ?? "";    
                    string strPaymethod = "A - MAG TAPE";
                    string strBankName = bankDetails.BankName ?? "";        
                    string strBankCode = bankDetails.BranchCode ?? "";      
                    string strAccNumber = bankDetails.AccountNumber ?? "";  

                    if (strAccNumber.Trim().Substring(0, 1) == "*")
                    {
                        //TODO : check accountbyreg method
                        //strAccNumber = salesExport.GetAccountNoByRegOrID(strID); 
                    }

                    string strAccType = bankDetails.AccountNumber ?? "";   

                    string strAccDetails = bankDetails.AccountType ?? "";  
                    string strMonthlyAction = Convert.ToString(bankDetails.FirstDebitDay) ?? ""; 

                    //TODO 
                    string strSetPremium = "";                            //"R" + KeyValues.GetValueByKey(saleData, "TOTAL_PREMIUM_HIDDEN") ?? "66.00";

                    string strJoinRef = exportSale.ID.ToString();

                    string strCommDate = "COMM_DATE";

                    string strPaymentFrequency = "Monthly";
                    string strPassport = personalDetails.PassportNumber ?? ""; 
                    string strContactMethod = "CONTACTCHOICE";
                    string strTelFax = personalDetails.TelFax ?? "";     
                    string strTelWork = personalDetails.TelWork ?? "";   
                    //TODO
                    string strAppDate = "";                              //saleToExport.CreatedDate.ToString("yyyy/MM/dd");
                    string strAgent = "AUD";
                    bool bLastDay = false;

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
                    string strNotes = "AUDI";
                    string strRep = "AUD001";
                    string strBankBranch = "";

                    string exportResponse = string.Empty;
                    if (ServiceValidator.IstServiceReady())
                    {
                        exportResponse = wsClient.fUpdateMember(ServiceValidator.GetImportServiceHeader(), strMemberNo, strJoinRef, strAppDate, strCommDate,
                                                            strTitle, strInit, strName, strSurname, strBirthDate, strID, strPassport,
                                                            strMaritalStatus, strGender, strTelHome, strTelWork, strTelCell, strTelFax,
                                                            strEmail, strPO1, strPO2, strPO3, strPOCode, strPO1, strPO2, strPO3,
                                                            strPOCode, strNotes, strBenName, strBenID, strBankName, strBankBranch,
                                                            strBankCode, strAccNumber, strAccType, strAccDetails, strJoinFeeDate,
                                                            strMonthlyAction, bLastDay, strPaymentFrequency, strPaymethod, strPersalNo,
                                                            strPersalRef, strOccupation, strEmployer, strEmpDate, "", strNationality,
                                                            strSetPremium, strSetCover, strAgent, strRep, strBarcode, strContactMethod,
                                                            strDeathDate, strUserRef1, strUserRef2);

                        if (!Validator.ValidateExportResults("RCAUDC", exportResponse, ref exportSale, ref personalDetails))
                        {
                            return retVal;
                        }
                    }
                    if (Validator.ValidateExportResults(source, exportResponse, ref exportSale, ref personalDetails))
                    {
                        //retVal = salesExport.PassSale("System", "Sale exported successfully.", DateTime.Now, exportSale.CampaignID, "Pre-RecUpload");
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
