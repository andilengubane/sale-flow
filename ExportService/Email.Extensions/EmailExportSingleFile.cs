using System;
using System.IO;
using System.Text;
using BusinessLogic;
using System.Net.Mail;
using System.Collections.Generic;

namespace ExportService.Email.Extensions
{
    public class EmailExportSingleFile
    {
        public static void SendEmailSingleFile(String campaignName, String exportWithBankingDetails, int withBankingDetails)
        {
            List<Campaign> campaign = Campaign.GetCampaignsByCampaignName(campaignName);
            int campaignId = campaign[0].CampaignID;

            Sales salelist = Sales.GetSale(campaignId);
            int saleID = salelist.ID;

            List<Sales> modelSale = Sales.GetAllSaleByCampaignID(campaign[0].CampaignID);
            int total = modelSale.Count;

            SmtpClient smtpClient = new SmtpClient("altrongroup-mail-onmicrosoft-com.mail.protection.outlook.com");
            MailMessage message = new MailMessage();

            smtpClient.EnableSsl = true;
            smtpClient.Port = 25;

            message.From = new MailAddress("noreply@altron.com");
            message.To.Add("Andile.Ngubane@altron.com");
            message.To.Add("Reuben.Alexander@altron.com");
            message.To.Add("Sibusiso.Shongwe@altron.com");
            message.To.Add("Pushpakhi.Sharma@altron.com");
            message.To.Add("Kgotso.Moloatsi@altron.com");
            message.To.Add("Yagashan.Govender@altron.com");
            message.To.Add("Roxanne@tdas.co.za");
            message.To.Add("RCCampaignsTDAS@roadcover.co.za");

            message.Subject = $"Exporter Email for Campaign: { campaign }";
            message.IsBodyHtml = true;

            int totalSales = withBankingDetails;
            String policyNumber = String.Empty;
            String bankingDetails = String.Empty;

            String totalExport = $"<strong>Total number of exports: { totalSales } </strong>";

            String numberOfSaleProcessWithBankingDetails = $"<strong>Total Number of Sales Processed: { withBankingDetails } </strong>";

            String numberOfSuccessfulSubmission = $"<strong>Total Number of Successful Submissions: { totalSales } </strong>";
            String numberOfFailedSubmission = String.Empty;

            String _withBankingDetails = $"<strong>{ DateTime.Now }_{ exportWithBankingDetails } uploaded to administrator.</strong> : { withBankingDetails }";

            StringBuilder emailBody = new StringBuilder();

            emailBody.AppendLine($"<h3>Date of export: { DateTime.Now }.</h3><br/>");
            emailBody.AppendLine("<table border='1'>");
            emailBody.AppendLine("<tr><th>Campaign Name</th><th>BPS Sale ID</th><th>BPS Lead ID</th><th>Policy Number</th><th>Agent Name</th><th>Agent Code</th><th>Workflow</th><th>Individual Riders</th><th>Family Rider</th><th>Date Sent</th><th>Status Message</th></tr>");

            if (totalSales != 0)
            {
                numberOfFailedSubmission = $"<strong>Total Number of Failed Submissions: { "salesToExport[0].FailCount" } </strong>";

                StringBuilder geneareteCSVFile = new StringBuilder();

                String header = String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"",
                                         "Campaign Name", "BPS Sale ID", "BPS Lead ID", "Policy Number", "Agent Name", "Agent Code", "Workflow", "Individual Rider", "Family Rider", "Date Sent", "Status Message");

               geneareteCSVFile.AppendLine(header.Replace(",", ";") + ' ');

                for (int i = 0; i < modelSale.Count; i++)
                {
                    PersonalDetails personalDetails = PersonalDetails.GetPersonalDetails(modelSale[0].ID);
                    BankDetails bankDetails = BankDetails.GetBankDetails(modelSale[0].ID);

                    List<SubMemberDetails> subMemberDetails = SubMemberDetails.GetSubMembers(modelSale[0].ID);

                    emailBody.AppendLine("<tr>");
                    emailBody.AppendLine("<td>" + campaignName + "</td>");
                    emailBody.AppendLine("<td>" + modelSale[i].ID + "</td>");
                    emailBody.AppendLine("<td>" + modelSale[i].LeadID + "</td>");
                    emailBody.AppendLine("<td>" + policyNumber + "</td>");
                    emailBody.AppendLine("<td>" + modelSale[i].CaptureBy + "</td>");
                    emailBody.AppendLine("<td>" + modelSale[i].CaptureDate + "</td>");
                    emailBody.AppendLine("<td>" + modelSale[i].Status + "</td>");
                    emailBody.AppendLine("<td>" + subMemberDetails.Count + "</td>");
                    emailBody.AppendLine("<td>" + "familyRider" + "</td>");
                    emailBody.AppendLine("<td>" + DateTime.Now + "</td>");
                    emailBody.AppendLine("<td> Submitted to administrator. </td>");

                    String list = String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\""
                                               , campaign
                                               , modelSale[i].ID
                                               , modelSale[i].LeadID
                                               , policyNumber
                                               , modelSale[i].CaptureBy
                                               , modelSale[i].CaptureDate
                                               , modelSale[i].Status
                                               , subMemberDetails.Count
                                               , "familyRider"
                                               , DateTime.Now
                                               , "Successfully processed.");

                    geneareteCSVFile.AppendLine(list.Replace(",", ",") + ' ');
                }

                File.WriteAllText(@"C:\Campaign_" + campaign + ".csv", geneareteCSVFile.ToString());

                var fileUploadWithbankingDetails = String.Empty;
                fileUploadWithbankingDetails = @"C:\Campaign_" + campaign + ".csv";

                Attachment attachment;
                attachment = new Attachment(fileUploadWithbankingDetails);
                message.Attachments.Add(attachment);

                emailBody.Append("</tr></table><br/>" + totalExport +
                                 "<br/>" + numberOfSaleProcessWithBankingDetails +
                                 "<br/>" + numberOfSuccessfulSubmission +
                                 "<br/>" + numberOfFailedSubmission +
                                 "<br/>" + _withBankingDetails);
                message.Body = emailBody.ToString();
                smtpClient.Send(message);
            }
        }
    }
}
