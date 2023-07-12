using System;
using System.IO;
using System.Text;
using System.Net.Mail;
using BusinessLogic;
using System.Collections.Generic;

namespace ExportService.Email.Extensions
{
    public class EmailExportWebServices
    {
        public static void SendEmail(string campaignName)
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
            message.To.Add("Sibusiso.Shongwe@altron.com");
            message.To.Add("Pushpakhi.Sharma@altron.com");
            //message.To.Add("Reuben.Alexander@altron.com");
            message.To.Add("Kgotso.Moloatsi@altron.com");
            message.To.Add("Yagashan.Govender@altron.com");
            //message.To.Add("Roxanne@tdas.co.za");
            //message.To.Add("RCCampaignsTDAS@roadcover.co.za");
            message.To.Add("Phakamacampaigns@roadcover.co.za");
            message.To.Add("chanell@roadcover.co.za");

            message.Subject = $"Exporter Email for Campaign: { campaign }";
            message.IsBodyHtml = true;

            string policyNumber = string.Empty;

            string totalExport = $"<strong>Total number of export { modelSale.Count }";
            string numberOfSaleProcessWithBankingDetails = $"<strong>Total Number of Sales Processed : { modelSale.Count } </strong>";
            string numberOfSuccessfulSubmission = $"<strong>Total Number of Successful Submissions: { modelSale.Count } </strong>";
            string numberOfFailedSubmission = string.Empty;

            StringBuilder emailBody = new StringBuilder();

            emailBody.AppendLine($"<h3>Date of export: { DateTime.Now }.</h3><br/>");
            emailBody.AppendLine("<table border='1'>");
            emailBody.AppendLine("<tr><th>Campaign Name</th><th>BPS Sale ID</th><th>BPS Lead ID</th><th>Policy Number</th><th>Agent Name</th><th>Agent Code</th><th>Workflow</th><th>Individual Rider</th><th>Family Rider</th><th>Date Sent</th><th>Status Message</th></tr>");

            StringBuilder geneareteCSVFile = new StringBuilder();

            string header = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"",
                                         "Campaign Name", "BPS Sale ID", "BPS Lead ID", "Policy Number", "Agent Name", "Agent Code", "Workflow", "Individual Rider", "Family Rider", "Date Sent", "Status Message");

            geneareteCSVFile.AppendLine(header.Replace(",", ";") + ' ');

            if (modelSale.Count > 0)
            {
                numberOfFailedSubmission = $"<strong>Total Number of Failed Submissions: { "modelSale[0].FailCount" } </strong>";

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
                    emailBody.AppendLine("<td>" + modelSale[i].CaptureBy + "</td>");
                    emailBody.AppendLine("<td>" + modelSale[i].Status + "</td>");
                    emailBody.AppendLine("<td>" + subMemberDetails.Count + "</td>");   //TODO : Is there need to put in riders.
                    emailBody.AppendLine("<td>" + "familyRider" + "</td>");            //TODO : Is there need to put in riders.
                    emailBody.AppendLine("<td>" + DateTime.Now + "</td>");
                    emailBody.AppendLine("<td> Successfully Processed. </td>");

                    string list = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\""
                                            , campaign
                                            , modelSale[i].ID
                                            , modelSale[i].LeadID
                                            , policyNumber
                                            , modelSale[i].CaptureBy
                                            , modelSale[i].CaptureBy
                                            , modelSale[i].Status
                                            , modelSale[i].Status
                                            , "familyRider"
                                            , DateTime.Now
                                            , "Successfully Processed.");

                    geneareteCSVFile.AppendLine(list.Replace(",", ";") + ' ');

                    //                Saless.InsertSalesReport(campaign, salesToExport[i].SaleID, salesToExport[i].LeadID, policyNumber, salesToExport[i].UserAssigned, saleToExport.ModifiedBy
                    //                                        , currentStatus, "Submitted to administrator.", "", individualRider, familyRider);
                  
                }

                File.WriteAllText(@"C:\Campaign_" + campaign + ".csv", geneareteCSVFile.ToString());

                var fileUploadWithbankingDetails = string.Empty;
                fileUploadWithbankingDetails = @"C:\Campaign_" + campaign + ".csv";

                Attachment attachment;
                attachment = new Attachment(fileUploadWithbankingDetails);
                message.Attachments.Add(attachment);

                emailBody.Append("</tr></table><br/>" + totalExport +
                                 "<br/>" + numberOfSaleProcessWithBankingDetails +
                                 "<br/>" + numberOfSuccessfulSubmission +
                                 "<br/>" + numberOfFailedSubmission);
                message.Body = emailBody.ToString();
                smtpClient.Send(message);
            }
        }
    }
}
