using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace email
{
    public class EmailMessageBody
    {
        public EmailMessageBody()
        {
            this.To = new List<string>();
            this.Attachments = new List<string>();
        }

        public string Subject { set; get; }
        public string Body { set; get; }

        public List<string> To { set; get; }

        public string From { set; get; }

        public bool IsBodyHtml { set; get; }

        public List<string> Attachments { get; set; }
    }
}
