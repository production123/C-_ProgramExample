using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 配置系统依赖注入
{
    internal class TestController2
    {      
        private readonly IOptionsSnapshot<Proxy> optionsSnapshot;

        public TestController2(IOptionsSnapshot<Proxy> optSnapshot)
        {

            this.optionsSnapshot = optSnapshot;
        }

        public void PrintConfig()
        {
            Proxy proxy = optionsSnapshot.Value;
            Console.WriteLine(proxy.Address);
        }
    }
}
