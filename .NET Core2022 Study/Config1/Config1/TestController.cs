using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Config1
{
    class TestController
    {
        private readonly IOptionsSnapshot<Config> optConfig;
        public TestController(IOptionsSnapshot<Config> optConfig)
        {
            this.optConfig = optConfig;
        }
        public void Test()
        {
            Config config = optConfig.Value;
            Console.WriteLine(config.Age);
            Console.WriteLine("****************");
            Console.WriteLine(config.Proxy.Address);
            Console.WriteLine(config.Proxy.Port);
        }
    }
}
