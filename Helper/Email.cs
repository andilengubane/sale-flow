using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Helper
{
    // TODO: It's still a bit RAW!
    public class Email
    {
        public string Host { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool SslEnabled { get; set; }
        
        public string AddressDelimiter { get; set; }
        public List<MailAddress> ToAddresses { get; set; }
        public List<MailAddress> CcAddresses { get; set; }
        public List<MailAddress> BccAddresses { get; set; }
        public string MailType { get; set; }

        public List<Attachment> Attachments { get; set; } // Use a delimited list of full paths?

        public string Subject { get; set; }
        public string Message { get; set; }

        public Email()
        {
            ToAddresses = new List<MailAddress>();
            CcAddresses = new List<MailAddress>();
            BccAddresses = new List<MailAddress>();
            Attachments = new List<Attachment>();
        }

        public Email(SMTPConfig configObject)
            : base()
        {
            Host = configObject.Host;
            AccountName = configObject.AccountName;
            Password = configObject.Password;
            Port = configObject.Port;
            SslEnabled = configObject.SslEnabled;
            AddressDelimiter = configObject.AddressDelimiter;
        }

        private List<Tobject> ParseAddressString<Tobject>(string valueString, string delimiter) where Tobject : new()
        {
            List<Tobject> objectsToReturn = new List<Tobject>();

            string[] splitValues = valueString.Split(delimiter[0]);

            for (int i = 0; i < splitValues.Length - 1; i++)
            {
                objectsToReturn.Add(new Tobject());
            }

            return objectsToReturn;
        }

        public static void SendMail(string configName)
        {
            SMTPConfig mailConfig = DataAccess.getEmailConfig(configName);
            Email mailToSend = new Email(mailConfig);           
            
        }
    }
}
