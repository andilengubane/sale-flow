using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLogic;
using Utils.Logger;
using System.Data.SqlClient;

namespace salesFlowLeadLoader
{
    /// <summary>
    /// Summary description for LeadImport
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LeadImport : System.Web.Services.WebService
    {

        [WebMethod]
        public bool CheckAvailability()
        {
            return Validators.IsDBAvailable();
        }
        /// <summary>
        /// Creates a unique batch ID to be used as a reference when loading leads. this returns a batch ID which should be passed as a parameter on CreateSaleRecord 
        /// </summary>
        /// <param name="batchRef">unique reference to track back external sources</param>
        /// <returns>Int</returns>
        [WebMethod]
        public int CreateBatch(string batchRef)
        {
            int retVal = 0;
            try
            {
                retVal = Batch.SaveBatch(DateTime.Now, false, batchRef);
                evLogger.LogEvent(string.Format("Batch Created Successfully : {0}", retVal.ToString()), System.Diagnostics.EventLogEntryType.Information);
            }
            catch(Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }
            return retVal;
        }
        /// <summary>
        /// captures the lead record and returns a string in this format... status pipe message
        /// example + : "true|saleId:12"
        /// example - : "false|campaign not found"
        /// </summary>
        /// <param name="campaignName"></param>
        /// <param name="leadID"></param>
        /// <param name="title"></param>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <param name="idNumber"></param>
        /// <param name="passportNumber"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="telWork"></param>
        /// <param name="telCell"></param>
        /// <param name="telHome"></param>
        /// <param name="telFax"></param>
        /// <param name="gender"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="address3"></param>
        /// <param name="address4"></param>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <param name="email"></param>
        /// <param name="bankName"></param>
        /// <param name="bankAccountName"></param>
        /// <param name="bankAccountNumber"></param>
        /// <param name="bankAccountType"></param>
        /// <param name="branchCode"></param>
        /// <param name="firstDebitDay"></param>
        /// <param name="firstDebitMonth"></param>
        /// <param name="primaryOrSecondaryAccount"></param>
        /// <param name="batchID"></param>
        /// <param name="extra1"></param>
        /// <param name="extra2"></param>
        /// <param name="extra3"></param>
        /// <param name="extra4"></param>
        /// <param name="extra5"></param>
        /// <param name="extra6"></param>
        /// <param name="extra7"></param>
        /// <param name="extra8"></param>
        /// <param name="extra9"></param>
        /// <param name="extra10"></param>
        /// <returns>"true/false"  |  "Message"</returns>
        [WebMethod]
        public string CreateSaleRecord(string campaignName, int leadID, string title, string initials, string firstName, string surname, string idNumber, string passportNumber, DateTime dateOfBirth, string telWork, string telCell, string telHome, string telFax, string gender, string address1, string address2, string address3, string address4, string city, string postalCode, string email, string bankName, string bankAccountName, string bankAccountNumber, string bankAccountType, string branchCode, int firstDebitDay, int firstDebitMonth, string primaryOrSecondaryAccount, int batchID, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7, string extra8, string extra9, string extra10, string secondName = "", decimal grossIncome = 0)
        {
            string retVal = "true|";
            bool proceedWithLoad = false;
            try
            {
                // 1. Find Campaign:
                Campaign xCamp = new Campaign(campaignName);
                int campaignID = 0;
                if(xCamp.Found)
                {
                    campaignID = xCamp.CampaignID;
                    // 2. Check if leadId - campaignName combination exists
                    Sales chk = Sales.GetSale(leadID, campaignID);
                    if (chk.Found)
                    {
                        if (chk.IsDialed)
                        {
                            retVal = string.Format("LeadID: @lid found, loaded and dialed already.", leadID.ToString());
                            evLogger.LogEvent(string.Format("LeadID: {0} found, loaded and dialed already.", leadID.ToString()), System.Diagnostics.EventLogEntryType.Information);
                        }
                        else
                        {
                            proceedWithLoad = true;
                        }
                    }
                    else
                    {
                        proceedWithLoad = true;
                    }

                    if (proceedWithLoad)
                    {
                        // 3. Create a sale with "IsDialed" tag set to FALSE by Default
                        int newSaleId = Sales.CreateSale(leadID, campaignID, "", DateTime.Now, 1, "", DateTime.Now, "Lead Imported", batchID, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);

                        if (newSaleId > 0)
                        {
                            retVal+= "SaleID=" + newSaleId.ToString() + ", ";
                            evLogger.LogEvent(string.Format("Step 1 of 3: SaleID: {0} created successfully", newSaleId.ToString()), System.Diagnostics.EventLogEntryType.Information);

                            // 4. Create personal details if provided...
                            if (telCell.Length > 9)
                            {
                                int memberID = PersonalDetails.SavePersonalDetails
                                               (
                                                    newSaleId, 
                                                    title.Replace(".", ""),
                                                    initials,
                                                    firstName, 
                                                    secondName, 
                                                    surname, 
                                                    idNumber, 
                                                    passportNumber, 
                                                    dateOfBirth, 
                                                    telWork, 
                                                    telCell, 
                                                    telHome, 
                                                    telFax, 
                                                    gender, 
                                                    address1, 
                                                    address2, 
                                                    address3, 
                                                    address4, 
                                                    city, 
                                                    postalCode, 
                                                    email, 
                                                    grossIncome

                                               );

                                if (memberID > 0)
                                {
                                    retVal += "MainMemberID=" + memberID.ToString() + ", ";
                                    evLogger.LogEvent(string.Format("Step 2 of 3: MemberID: {0} created successfully", memberID.ToString()), System.Diagnostics.EventLogEntryType.Information);
                                }
                            }

                            // 5. Create banking details
                            if (bankName.Trim().Length > 0)
                            {
                                int newBankAccountDetailsID = BankDetails.CreateBankDetails(bankAccountNumber, bankAccountName, bankName, bankAccountType, branchCode, DateTime.Now.AddMonths(1).Month, 1, primaryOrSecondaryAccount, newSaleId);
                                if (newBankAccountDetailsID > 0)
                                {
                                    retVal += "BankDetailID=" + newBankAccountDetailsID.ToString();
                                    evLogger.LogEvent(string.Format("Step 3 of 3: BankingDetailsID: {0} created successfully", newBankAccountDetailsID.ToString()), System.Diagnostics.EventLogEntryType.Information);
                                }
                            }
                        }
                    }
                    else
                    {
                        retVal = string.Format("false|LeadID: {0} found, loaded and dialed already.", leadID.ToString());
                        evLogger.LogEvent(string.Format("LeadID: {0} found, loaded and dialed already.", leadID.ToString()), System.Diagnostics.EventLogEntryType.Information);
                    }
                }
                else
                {
                    retVal = string.Format("false|Campaign with name: {0}  not found.", campaignName);
                    evLogger.LogEvent(string.Format("Campaign with name: {0}  not found.", campaignName), System.Diagnostics.EventLogEntryType.Information);
                }

                xCamp = null;
            }
            catch(Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
                retVal = "false|" + ex.Message + "\n\n" + ex.StackTrace;
            }
            return retVal;
        }
    }
}
