using Microsoft.Extensions.Configuration;
using System;

namespace 配置系统
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            // 读取 JSON 配置文件
            // optional: false 配置文件必须
            // reloadOnChange: false 配置文件改变时，不立即加载
            configBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: false);
            
            // 构建配置结构根对象
            IConfigurationRoot configRoot = configBuilder.Build();

            /*
            //读取 name配置 
            string name = configRoot["name"];
            Console.WriteLine($"name={name}");

            //读取 JSON 子对象配置
            string address = configRoot.GetSection("proxy:address").Value;
            Console.WriteLine($"address={address}");
            */

            Proxy proxy = configRoot.GetSection("proxy").Get<Proxy>();
            Console.WriteLine($"{proxy.Address},{proxy.Port}");

            Config config = configRoot.Get<Config>();
            Console.WriteLine(config.Name);
            Console.WriteLine(config.Proxy.Port);

            Console.ReadKey();
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

