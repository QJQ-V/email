using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace email
{
    public class MQEmailSenderService : IEmailSender
    {
        /// <summary>
        /// 待实现
        /// </summary>
        /// <param name="body"></param>
        public void Send(EmailMessageBody body)
        {
            Console.WriteLine("消息队列发送...");
        }
    }
}
