using Microsoft.Extensions.Configuration;

ConfigurationBuilder configBuilder = new ConfigurationBuilder();

//读取环境变量配置
configBuilder.AddEnvironmentVariables("C1_");

// 读取 JSON 配置文件
configBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: false);

//读取命令行配置
configBuilder.AddCommandLine(args);


// 构建配置结构根对象
IConfigurationRoot configRoot = configBuilder.Build();


//绑定配置类
Config config = configRoot.Get<Config>();
Proxy proxy = configRoot.GetSection("proxy").Get<Proxy>();


Console.WriteLine("获取配置：");
Console.WriteLine($"Name:{config.Name}");
Console.WriteLine($"Prot:{config.Proxy.Port}");
Console.WriteLine($"proxy.Address:{proxy.Address},proxy.Address:{proxy.Port}");


Console.ReadKey();




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