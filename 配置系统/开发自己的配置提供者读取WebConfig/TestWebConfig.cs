using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 开发自己的配置提供者读取WebConfig;

namespace 开发自己的配置提供者读取WebConfig
{
    internal class TestWebConfig
    {
        private IOptionsSnapshot<WebConfig> optWC;

        public TestWebConfig(IOptionsSnapshot<WebConfig> optWC)
        {
            this.optWC = optWC;
        }

        public void Test()
        {
            var wc = optWC.Value;
            Console.WriteLine(wc.Connl.ConnectionString);
            Console.WriteLine(wc.Config.Age);
            Console.WriteLine(wc.Config.Proxy.Address);
        }
    }
}

