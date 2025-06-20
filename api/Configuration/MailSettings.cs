using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Configuration
{
    public class MailSettings
    {
        public string FromEmail { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }
}