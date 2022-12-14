using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 开发自己的配置提供者读取WebConfig
{
    internal class FxConfigSource : FileConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            
            EnsureDefaults(builder); // 处理路径 Path 等默认值问题
            return new FxConfigProvider(this);
        }
    }
}
