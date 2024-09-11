using Microsoft.Extensions.Options;
using System;

namespace 自定义配置提供
{
    class TestWebConfig
    {
        private IOptionsSnapshot<WebConfig> optWebConfig;
        public TestWebConfig(IOptionsSnapshot<WebConfig> optWebConfig)
        {
            this.optWebConfig = optWebConfig;
        }
        public void Test()
        {
            var wc = optWebConfig.Value;
            Console.WriteLine(wc.Connstr1.connectionString);
            Console.WriteLine(wc.Connstr1.providerName);
            Console.WriteLine(wc.appSettings.Smtp.Server);
            Console.WriteLine(wc.appSettings.Smtp.Port);
            Console.WriteLine(wc.appSettings.RedisServer);
            Console.WriteLine(wc.appSettings.RedisPassword);

        }
    }
}
