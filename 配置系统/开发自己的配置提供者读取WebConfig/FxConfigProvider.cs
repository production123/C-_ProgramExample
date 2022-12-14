using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Configuration;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace 开发自己的配置提供者读取WebConfig
{
    internal class FxConfigProvider : FileConfigurationProvider
    {
        public FxConfigProvider(FxConfigSource src) : base(src)
        {
        }


        public override void Load(Stream stream)
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);
            var csNodes = xmlDoc.SelectNodes("/configuration/connectionStrings/add ");
            foreach (XmlNode xmlNode in csNodes.Cast<XmlNode>())
            {
                string name = xmlNode.Attributes["name"].Value;
                string connectionString = xmlNode.Attributes["connectionString"].Value;
                //[conn1: {connectionString:"fafdsfa", providerName : "mysq1"} ,
                //conn2:{connectionString: "3333", providerName: "mysq1"3]
                data[$"{name}:connectionString"] = connectionString;
                var attProviderName = xmlNode.Attributes["providerName"];
                if (attProviderName != null)
                {
                    data[$"{name}:providerName"] = attProviderName.Value;
                }
            }

            var asNodes = xmlDoc.SelectNodes("/configuration/appSettings/add");
            foreach (XmlNode xmlNode in asNodes.Cast<XmlNode>())
            {
                string key = xmlNode.Attributes["key"].Value;
                key = key.Replace(".", ":");
                string value = xmlNode.Attributes["value"].Value;
                data[key] = value;
            }

            this.Data = data;
        }
    }
}