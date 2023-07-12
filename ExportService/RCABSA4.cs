using System;
using System.IO;
using System.Linq;
using System.Text;
using Utils.Logger;
using BusinessLogic;
using System.Collections.Generic;
using ExportService.Email.Extensions;
using BusinessLogic.Campaigns.ROADCOVER;
using ExportService.RoadCover.Extensions;

namespace ExportService
{
    public class RCABSA4
    {
        public static void DoExport()
        {
            List<Campaign> campaign = Campaign.GetCampaignsByCampaignName("RCABSA4");
            int campaignId = campaign[0].CampaignID;

            Sales salelist = Sales.GetSale(campaignId);
            int saleID = salelist.ID;

            List<Sales> salesExport = Sales.GetAllSaleByCampaignID(campaign[0].CampaignID);
            int total = salesExport.Count;

            StringBuilder exportWithBankingDetailsToCsvFile = new StringBuilder();
            StringBuilder exportWithNoBankingDetailsToCsvFile = new StringBuilder();

            String header = String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"" +
                                         ",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\"" +
                                         ",\"{21}\",\"{22}\",\"{23}\",\"{24}\",\"{25}\",\"{26}\",\"{27}\",\"{28}\",\"{29}\",\"{30}\"" +
                                         ",\"{31}\",\"{32}\",\"{33}\",\"{34}\",\"{35}\",\"{36}\",\"{37}\",\"{38}\",\"{39}\",\"{40}\"" +
                                         ",\"{41}\",\"{42}\",\"{43}\",\"{44}\",\"{45}\",\"{46}\",\"{47}\",\"{48}\",\"{49}\",\"{50}\"" +
                                          ",\"{51}\",\"{52}\",\"{53}\",\"{54}\",\"{55}\",\"{56}\",\"{57}\",\"{58}\",\"{59}\""

                                          , "File Status", "Cons File Number", "Our Reference", "Customer Number1", "Customer Number2", "Customer Number3"
                                          , "YourReference", "Member Type", "Title", "Initials", "First Name", "Last Name", "Identity Number", "Passport Number"
                                          , "Date Of Birth", "Gender", "Langauge", "Salary Day", "Cell Phone Number", "Work Phone", "Home Phone", "Email Address"
                                          , "Postal Address1", "Postal Address2", "Postal Address3", "PostalCode", "Province", "Bank Account Holder", "Bank Name"
                                          , "Bank Branch", "Bank Branch Code", "Bank Account Type", "Bank Account Number", "Debit Order Day", "Debit Order Date"
                                          , "Vehicle Detail 1", "Vehicle Detail 2", "Vehicle Detail 3", "Vehicle Detail 4", "Vehicle Detail 5", "Product 1" 
                                          , "Product 2", "Product 3", "Product 4", "Product 5", "Date 1", "Date 2", "Date 3", "Date 4", "Date 5", "Allocatedto" 
                                          , "Date Allocated", "Asset Short Description", "Date Expiry", "First Licensed", "Make Description", "Registration Num" 
                                          , "Premium", "Application Date", "QA Date"); 

            exportWithBankingDetailsToCsvFile.AppendLine(header.Replace(",", ",") + ' ');
            exportWithNoBankingDetailsToCsvFile.AppendLine(header.Replace(",", ",") + ' ');

            for (int i = 0; i < salesExport.Count; i++)
            {
                PersonalDetails personalDetails = PersonalDetails.GetPersonalDetails(salesExport[0].ID);
                BankDetails bankDetails = BankDetails.GetBankDetails(salesExport[0].ID);
                List<Languages> languages = Languages.GetLanguagesByUserID(salesExport[0].ID);
                List<RoadCoverProducts> roadCoverProducts = RoadCoverProducts.GetRoadCoverProduct("RCABSA4", salesExport[0].ID);
                List<Verification> verifications = Verification.GetVerificationDetails(salesExport[0].ID);
                SaleDetailsRCABSA4 saleDetailsRCABSA4 = SaleDetailsRCABSA4.GetSaleDetails(salesExport[0].ID);
                List<Province> provinces = Province.GetProvince(saleDetailsRCABSA4.ProvinceID);

                String idNumber = String.Empty;

                if (String.IsNullOrWhiteSpace(personalDetails.IDNumber))
                {
                    idNumber = personalDetails.PassportNumber;
                }
                else
                {
                    idNumber = personalDetails.IDNumber;
                }

                string name = personalDetails.FirstName.Substring(0, 1);
                string surname = personalDetails.Surname.Substring(0, 1);
                string initials = $"{name}{surname}";

                if (bankDetails.Found)
                {
                    String list = String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"" +
                                               ",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\"" +
                                               ",\"{21}\",\"{22}\",\"{23}\",\"{24}\",\"{25}\",\"{26}\",\"{27}\",\"{28}\",\"{29}\",\"{30}\"" +
                                               ",\"{31}\",\"{32}\",\"{33}\",\"{34}\",\"{35}\",\"{36}\",\"{37}\",\"{38}\",\"{39}\",\"{40}\"" +
                                               ",\"{41}\",\"{42}\",\"{43}\",\"{44}\",\"{45}\",\"{46}\",\"{47}\",\"{48}\",\"{49}\",\"{50}\"" +
                                               ",\"{51}\",\"{52}\",\"{53}\",\"{54}\",\"{55}\",\"{56}\",\"{57}\",\"{58}\",\"{59}\""

                                             , campaign[0].CampaignSetting1, campaign[0].CampaignSetting2, campaign[0].CampaignSetting3, String.Empty, String.Empty, String.Empty
                                             , campaign[0].CampaignSetting4, saleDetailsRCABSA4.MemberType, personalDetails.Title, initials, personalDetails.FirstName
                                             , personalDetails.Surname, idNumber, personalDetails.PassportNumber, personalDetails.DateOfBirth, personalDetails.Gender
                                             , languages[0].Title, bankDetails.SalaryDay, personalDetails.TelCell, personalDetails.TelWork, personalDetails.TelHome, personalDetails.Email
                                             , personalDetails.Address1, personalDetails.Address2, personalDetails.Address3, personalDetails.PostalCode, provinces[0].Name, bankDetails.BankAccountHolder, bankDetails.BankName
                                             , bankDetails.BankBranch, bankDetails.BranchCode, bankDetails.AccountType, bankDetails.AccountNumber, bankDetails.FirstDebitMonth, bankDetails.FirstDebitDay
                                             , roadCoverProducts[0].VehicleDetail, String.Empty, String.Empty, String.Empty, String.Empty, roadCoverProducts[0].ProductDetail 
                                             , String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, roadCoverProducts[0].Allocatedto 
                                             , roadCoverProducts[0].DateAllocated, roadCoverProducts[0].AssetShortDescription, roadCoverProducts[0].DateExpiry, roadCoverProducts[0].FirstLicensed
                                             , roadCoverProducts[0].MakeDescription, roadCoverProducts[0].RegistrationNum, saleDetailsRCABSA4.Premium, salelist.CaptureDate, verifications[0].TimeFinished); 

                    exportWithBankingDetailsToCsvFile.AppendLine(list.Replace(",", ",") + ' ');
                }
            }

            File.WriteAllText(@"C:\RCABSA_SalesExport_ELB_" + DateTime.Now.ToString("yyyyMMdd") + ".csv", exportWithBankingDetailsToCsvFile.ToString());
            String fileUploadWithbankingDetails = @"C:\RCABSA_SalesExport_ELB_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

            var _fileWithBankingDetails = File.ReadAllLines(fileUploadWithbankingDetails);
            int totalNumberOfRecordBankingDetails = _fileWithBankingDetails.Skip(1).Count();

            if (total > 0)
            {
                ExportFileToSFTP.UplaodRCABSA4ToSFTP(fileUploadWithbankingDetails, "/Absa/Sales Files");
                EmailExportSingleFile.SendEmailSingleFile("RCABSA4", "RCABSA_SalesExport_ELB_" + DateTime.Now.ToString("yyyyMMdd") + ".csv",
                                                                           totalNumberOfRecordBankingDetails);
            }
        }
    }
}
