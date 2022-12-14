using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 开发自己的配置提供者读取WebConfig
{
    class WebConfig
    {
        public ConnectStr Connl { get; set; }

        public ConnectStr ConnTest { get; set; }

        public Config Config { get; set; }
    }

    class ConnectStr
    {
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }
}
