using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 配置系统依赖注入
{
    internal class TestController
    {      
        //private readonly Config _config;
        private readonly IOptionsSnapshot<Config> optionsSnapshot;

        public TestController(IOptionsSnapshot<Config> optSnapshot)
        {

            this.optionsSnapshot = optSnapshot;

            //注意：不要这样写，在构造函数中直接获取配置对象
            //因为没有了 IOptionsSnapshot 对象，所以不会响应配置文件的修改
            //this._config = optSnapshot.Value;
        }

        public void PrintConfig()
        {
            Console.WriteLine(optionsSnapshot.Value.Age);
            Console.WriteLine("************************");
            Console.WriteLine(optionsSnapshot.Value.Age);
        }
    }
}
