using System.Net.Mail;

namespace ExportService.Email.Extensions
{
    public class FNBEmailExport
    {
        public static void SendEmail(string campaignName, int numberOfSales)
        {
            SmtpClient smtpClient = new SmtpClient("altrongroup-mail-onmicrosoft-com.mail.protection.outlook.com");
            MailMessage message = new MailMessage();

            smtpClient.EnableSsl = true;
            smtpClient.Port = 25;

            message.From = new MailAddress("noreply@altron.com");
            message.To.Add("Andile.Ngubane@altron.com");
            message.To.Add("Reuben.Alexander@altron.com");
            message.To.Add("Sibusiso.Shongwe@altron.com");
            message.To.Add("stewart.naidoo@altron.com");
            message.To.Add("DeryllM@bytespeoplesolutions.co.za");
            message.To.Add("Dillon.Pillay@altron.com");
            message.To.Add("person3@domain.com");

            message.Subject = $"{ campaignName } Sales Export";
            message.IsBodyHtml = true;

            int totalNumberOfSales = numberOfSales;

            message.Body = $"The number of sales exported: {numberOfSales}";
            smtpClient.Send(message);
        }
    }
}
