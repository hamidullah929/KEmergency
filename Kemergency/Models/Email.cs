using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Models
{
    public class Email
    {
        public long ID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string Host { get; set; }
        public string EnableSSL { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
