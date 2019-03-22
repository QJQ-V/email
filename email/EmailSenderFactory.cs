using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace email
{
    public static class EmailSenderFactory
    {
        public static IEmailSender CreateEmailSenderService(string logType)
        {
            if (String.IsNullOrEmpty(logType))
            {
                return new LocalEmailSenderService();
            }
            switch (logType.ToLower())
            {
                case "local":
                    return new LocalEmailSenderService();
                case "mq":
                    return new MQEmailSenderService();
                default:
                    return new LocalEmailSenderService();
            }
        }
    }
}
