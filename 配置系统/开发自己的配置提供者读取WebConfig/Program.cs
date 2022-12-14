using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using 开发自己的配置提供者读取WebConfig;

internal class Program
{
    private static void Main(string[] args)
    {

        //初始化 IConfigurationRoot
        ConfigurationBuilder configBuilder = new ConfigurationBuilder();

        configBuilder.Add(new FxConfigSource() { Path = "web.config" });
        //configBuilder.AddFxConfig("web.config");
        //configBuilder.AddFxConfig();


        // 构建配置结构根对象
        IConfigurationRoot configRoot = configBuilder.Build();

        ServiceCollection services = new ServiceCollection();
        services.AddScoped<TestWebConfig>();
        services.AddOptions().Configure<WebConfig>(e => configRoot.Bind(e));

        using (var sp = services.BuildServiceProvider())
        {
            TestWebConfig c = sp.GetRequiredService<TestWebConfig>();
            c.Test();
        }

    }
}

class Config
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Proxy Proxy { get; set; }
}

class Proxy
{
    public string Address { get; set; }
    public int Port { get; set; }
}