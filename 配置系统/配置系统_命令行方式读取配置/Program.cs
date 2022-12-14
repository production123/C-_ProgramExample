using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using static System.Formats.Asn1.AsnWriter;

namespace 配置系统依赖注入
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //初始化 ServiceCollection
            ServiceCollection services = new ServiceCollection();

            //注册服务类
            services.AddScoped<TestController1>();
            services.AddScoped<TestController2>();

            //初始化 IConfigurationRoot
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();

            //使用JSON配置文件获取配置
            //configBuilder.AddJsonFile("config.json", optional: true, reloadOnChange: true);

            //使用命令行获取配置
            configBuilder.AddCommandLine(args);

            // 构建配置结构根对象
            IConfigurationRoot configRoot = configBuilder.Build();

            services.AddOptions()
                .Configure<Config>(configureOptions => configRoot.Bind(configureOptions))
                .Configure<Proxy>(configureOptions => configRoot.GetSection("Proxy").Bind(configureOptions));

            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                TestController1 testController1 = sp.GetRequiredService<TestController1>();
                testController1.PrintConfig();

                //TestController2 testController2 = sp.GetRequiredService<TestController2>();
                //testController2.PrintConfig();  
            }
            Console.ReadKey();
        }
    }


    class Proxy
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public int[] Ids { get; set; }
    }

    class Config
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Proxy Proxy { get; set; }
    }
}

