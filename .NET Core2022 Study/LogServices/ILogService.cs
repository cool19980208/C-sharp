using System;
using System.Collections.Generic;
using System.Text;

namespace LogServices
{
    public interface ILogService
    {
        public void LogError(string msg);
        public void LogInfo(string msg);
    }
}
