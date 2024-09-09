using System;
using System.Collections.Generic;
using System.Text;

namespace LogServices
{
    class LogService : ILogService
    {
        public void LogError(string msg)
        {
            Console.WriteLine($"Error：{msg}");
        }

        public void LogInfo(string msg)
        {
            Console.WriteLine($"Info：{msg}");
        }
    }
}
