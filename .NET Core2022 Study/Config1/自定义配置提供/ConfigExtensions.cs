using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义配置提供
{
    static class ConfigExtensions
    {
        //扩展方法
        public static IConfigurationBuilder AddConfig(this IConfigurationBuilder cb, string path = null)
        {
            if (path == null)
            {
                path = "web.config";
            }
            cb.Add(new ConfigurationSource() { Path = path });
            return cb;
        }
    }
}
