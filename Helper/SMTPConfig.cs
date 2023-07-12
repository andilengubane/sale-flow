using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class SMTPConfig
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool SslEnabled { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string AddressDelimiter { get; set; }
    }
}
