using System;

namespace MailServices
{
    public interface IMailService
    {
        public void Send(string tit1e, string to,string body); 
    }
}
