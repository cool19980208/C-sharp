using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace 自定义配置提供
{
    public class ConfigurationProvider : FileConfigurationProvider
    {
        public ConfigurationProvider(ConfigurationSource src) : base(src)//构造函数
        {

        }
        //读取配置
        public override void Load(Stream stream)
        {

            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);//Key是大小写不敏感的
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            //connectionStrings的读取
            var nodeConnStrs = xmlDoc.SelectNodes("/configuration/connectionStrings/add");//获取配置文件的节点
            foreach (XmlNode nodeConnStr in nodeConnStrs.Cast<XmlNode>())//nodeConnStrs转换为XmlNode
            {
                string name = nodeConnStr.Attributes["name"].Value;//读取name
                string connectionString = nodeConnStr.Attributes["connectionString"].Value;//读取connectionString

                //[connstr1:connectionString="Data Source=.;Initial Catalog=DemoDB;User ID=sa;Password=123456" providerName = "System.Data.SqlClient{}]
                data[$"{name}:connectionString"] = connectionString;
                var providerNameProp = nodeConnStr.Attributes["providerName"];//读取providerName
                if (providerNameProp != null)
                {
                    string providerName = providerNameProp.Value;
                    data[$"{name}:providerName"] = providerName;
                }
            }
            //appSettings的读取
            var nodeAppSets = xmlDoc.SelectNodes("/configuration/appSettings/add");//获取配置文件的节点
            foreach (XmlNode nodeAppSet in nodeAppSets.Cast<XmlNode>())//nodeConnStrs转换为XmlNode
            {
                string key = nodeAppSet.Attributes["key"].Value;//读取key
                key = key.Replace(".", ":");//把.都替换成：
                string value = nodeAppSet.Attributes["value"].Value;//读取value
                data[key] = value;
            }
            this.Data = data;
        }
    }
}
