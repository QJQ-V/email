using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace email
{
    public interface IEmailSender
    {
        void Send(EmailMessageBody body);
    }
}
