using Microsoft.Extensions.Options;
using System;

namespace Config1
{
    class demo
    {
        private readonly IOptionsSnapshot<Proxy> optProxy;
        public demo(IOptionsSnapshot<Proxy> optProxy)
        {
            this.optProxy = optProxy;
        }
        public void Test()
        {
            Console.WriteLine(optProxy.Value.Address);
            Console.WriteLine("****************");
            Console.WriteLine(optProxy.Value.Port);
        }
    }
}
