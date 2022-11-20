using ConfigServices;
using LogServices;
using System;

namespace MailServices
{
    public class MailService : IMailService
    {
        private readonly ILogProvider log;
        private readonly IConfigService config;

        public MailService(ILogProvider log, IConfigService config)
        {
            this.log = log;
            this.config = config;
        }


        public void Send(string tit1e, string to, string body)
        {
            this.log.LogInfo("准备发送邮件");
            string smtpServer = this.config.GetValue("SmtpServer");
            string userName = this.config.GetValue("UserName");
            string password = this.config.GetValue("Password");
            Console.WriteLine($"邮件服务器地址{smtpServer}，{userName}，{password}");

            //可以使用 MailKit 库
            Console.WriteLine($"邮件发送{tit1e},{to}");

            this.log.LogInfo("邮件发送完成");
        }
    }
}
