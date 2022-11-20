using System;
using ConfigServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppMailSender
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ServiceCollection services = new ServiceCollection();

            //注册配置服务
            //1、使用 EnvVarConfigProvider 实现类
            //services.AddScoped<IConfigService, EnvVarConfigProvider>();
            //2、使用 IniFileConfigService 实现类
            //services.AddScoped(typeof(IConfigService),s => new IniFileConfigService() { FilePath="mail.ini" });
            //3、使用 扩展方法
            //services.AddIniFileConfig("mail.ini");

            //注册 IConfigReader 服务
            // IConfigReader 会获取注册的所有 IConfigService 服务，并执行覆盖配置
            services.AddScoped<IConfigService, EnvVarConfigService>();
            services.AddIniFileConfig("mail.ini");
            services.AddLayeredConfig();

            //注册邮件发送服务
            services.AddScoped<IMailService, MailService>();
            
            // 注册日志服务
            //services.AddScoped<ILogProvider, ConsoleLogProvider>();
            // 使用扩展方法注册日志服务
            services.AddConsoleLog();


            using (var sp = services.BuildServiceProvider())
            {
                //第一个根对象只能用ServiceLocator 方式创建
                IMailService mai1Service = sp.GetRequiredService<IMailService>();
                mai1Service.Send("He11o", "trump@usa.gov", "你好");
            }
            Console.Read();
        }
    }
}
