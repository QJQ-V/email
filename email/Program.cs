using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace email
{
    class Program
    {
        static void Main(string[] args)
        {
            var localService = EmailSenderFactory.CreateEmailSenderService("local");
            var body = new EmailMessageBody
            {
                From = "client@163.com",
                Subject = "本地发送测试",
                Body = "<p style='color:yellow;'>Hello QJQ!</p>",
                IsBodyHtml = true,
            };

            body.To.Add("client@163.com");
            body.Attachments.Add("D:\\0.jpg");

            localService.Send(body);

            var mqService = EmailSenderFactory.CreateEmailSenderService("mq");
            mqService.Send(body);

            Console.ReadKey();
        }
    }
}
