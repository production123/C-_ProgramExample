using System;
using System.Collections.Generic;

namespace ConfigServices
{
    public class LayeredConfigReader : IConfigReader
    {
        private readonly IEnumerable<IConfigService> services;

        public LayeredConfigReader(IEnumerable<IConfigService> services)
        {
                this.services = services;
        }

        public string GetValue(string name)
        {
            string value = null;
            foreach (IConfigService service in services)
            {
                String newValue = service.GetValue(name);
                if (newValue != null)
                {
                    // 最后一个不为nu11的值，就是最终值
                    value = newValue;
                }
            }

            return value;
        }
    }
}
