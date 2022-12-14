using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 开发自己的配置提供者读取WebConfig
{
    static class FxConfigExtensions
    {
        public static IConfigurationBuilder AddFxConfig(this IConfigurationBuilder cb,string path = null)
        {
            if (path == null)
            {
                path = "web.config";
            }

            cb.Add(new FxConfigSource() { Path = path });
            return cb;
        }
    }
}
