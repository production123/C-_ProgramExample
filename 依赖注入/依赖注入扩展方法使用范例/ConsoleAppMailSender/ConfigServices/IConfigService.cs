using System;

namespace ConfigServices
{
    public interface IConfigService
    {
        /// <summary>
        /// 如果配置找不到就返回null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetValue(string name);
    }
}
