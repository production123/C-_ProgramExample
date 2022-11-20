using System;
using System.IO;
using System.Linq;

namespace ConfigServices
{
    public class IniFileConfigService : IConfigService
    {

        public string FilePath { get; set; }

        public string GetValue(string name)
        {
            var kv = File.ReadAllLines(FilePath)
                .Select(s => s.Split("="))
                .Select(strs => new
                {
                    Name = strs[0],
                    value = strs[1]
                }).SingleOrDefault( kv =>kv.Name == name);

            if (kv != null)
            {
                return kv.value;
            }
            else
            {
                return null;
            }
        }
    }
}
