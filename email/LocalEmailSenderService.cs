using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace email
{
    public class LocalEmailSenderService : IEmailSender
    {
        private string _smtpServer;
        private int _smtpPort;
        private string _adminAccount;
        private string _adminPassword;

        public LocalEmailSenderService()
        {
            _smtpServer = "smtp.263xmail.com";
            _smtpPort = 25;
            _adminAccount = "client@163.com";
            _adminPassword = "xxx";
        }

        public void Send(EmailMessageBody body)
        {
            Console.WriteLine("本地发送...");
            var emailSendService = new EmailSenderService(_smtpServer, _smtpPort, _adminAccount, _adminPassword);

            if (string.IsNullOrEmpty(body.From))
            {
                body.From = this._adminAccount;
            }

            emailSendService.SendEmail(body);
        }
    }
}
