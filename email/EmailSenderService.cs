using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace email
{
    /// <summary>
    /// 发件服务
    /// </summary>
    public class EmailSenderService: IDisposable
    {
        /// <summary>
        /// 邮件服务器配置
        /// </summary>
        private SmtpClient _smtpClient;

        public EmailSenderService(string smtpServer, int smtpPort, string adminAccount, string adminPassword)
        {
            _smtpClient = new SmtpClient()
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = smtpServer,
                Port = smtpPort,
                Credentials = new NetworkCredential(adminAccount, adminPassword),
                Timeout = 60000
            };
        }

        public void SendEmail(EmailMessageBody body)
        {
            CheckEmailMessage(body);

            // 发送邮件配置
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(body.From), // 必须指定发件人
                Subject = body.Subject,
                Body = body.Body,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = body.IsBodyHtml,
                Priority = MailPriority.High
            };

            foreach (var item in body.To)
            {
                mailMessage.To.Add(new MailAddress(item));
            }

            // 添加附件
            foreach (var item in body.Attachments)
            {
                mailMessage.Attachments.Add(new Attachment(item));
            }

            // 发送邮件
            _smtpClient.Send(mailMessage);
        }

        private void CheckEmailMessage(EmailMessageBody body)
        {
            if (String.IsNullOrEmpty(body.From))
            {
                throw new Exception("未设置发件人地址!");
            }

            if (body.To == null || body.To.Count() == 0)
            {
                throw new Exception("未设置收件人地址!");
            }

            if (String.IsNullOrEmpty(body.Body))
            {
                throw new Exception("未设置邮件内容!");
            }
        }

        /// <summary>
        /// 暂时不知道何时使用
        /// </summary>
        public void Dispose() {
            _smtpClient.Dispose();
        }
    }
}
