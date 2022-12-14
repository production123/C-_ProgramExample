using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 配置系统依赖注入
{
    internal class TestController1
    {      
        //private readonly Config _config;
        private readonly IOptionsSnapshot<Config> optionsSnapshot;

        public TestController1(IOptionsSnapshot<Config> optSnapshot)
        {

            this.optionsSnapshot = optSnapshot;

            //注意：不要这样写，在构造函数中直接获取配置对象
            //因为没有了 IOptionsSnapshot 对象，所以不会响应配置文件的修改
            //this._config = optSnapshot.Value;
        }

        public void PrintConfig()
        {

            Config config = optionsSnapshot.Value;
            Console.WriteLine($"姓名：{config.Name}");
            Console.WriteLine($"年龄：{config.Age}");
            Console.WriteLine($"代理地址：{config.Proxy.Address}");
            Console.WriteLine("Ids:" + string.Join(",", config.Proxy.Ids));

        }
    }
}
