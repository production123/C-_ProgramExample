using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace 配置系统依赖注入
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //初始化 ServiceCollection
            ServiceCollection services = new ServiceCollection();

            //注册服务类
            services.AddScoped<TestController>();
            services.AddScoped<TestController2>();

            //初始化 IConfigurationRoot
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("config.json", optional: true, reloadOnChange: true);
            // 构建配置结构根对象
            IConfigurationRoot configRoot = configBuilder.Build();

            services.AddOptions()
                .Configure<Config>(configureOptions => configRoot.Bind(configureOptions))
                .Configure<Proxy>(configureOptions => configRoot.GetSection("Proxy").Bind(configureOptions));

            //using (ServiceProvider sp = services.BuildServiceProvider())
            //{
            //    TestController testController = sp.GetRequiredService<TestController>();
            //    testController.PrintConfig();

            //    TestController2 testController2 = sp.GetRequiredService<TestController2>();
            //    testController2.PrintConfig();
            //}

            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                while (true)
                {
                    using (IServiceScope scope = sp.CreateScope())
                    {
                        //注意使用  scope 获取区域载调用区域的  ServiceProvider
                        TestController testController = scope.ServiceProvider.GetRequiredService<TestController>();

                        //同区域第1次读取配置
                        testController.PrintConfig();

                        Console.WriteLine("修改配置文件，改一下age");
                        Console.ReadKey();

                        //同区域第2次读取配置（修改配置后读取）
                        testController.PrintConfig();

                        TestController2 testController2 = scope.ServiceProvider.GetRequiredService<TestController2>();
                        testController2.PrintConfig();
                    }
                    Console.WriteLine("点击任意键继续");
                    Console.ReadKey();
                }
            }
        }
    }


    class Proxy
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }

    class Config
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Proxy Proxy { get; set; }
    }
}

