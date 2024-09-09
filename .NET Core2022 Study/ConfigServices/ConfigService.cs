using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServices
{
     class ConfigService : IConfigService
    {
        public string GetValue(string name)
        {
            return "Hello";
        }
    }
}
