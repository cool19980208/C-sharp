using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemServices
{
    class Test2
    {
        private readonly ILogger<Test2> logger;
        public Test2(ILogger<Test2> logger)
        {
            this.logger = logger;
        }
        public void Test()
        {
            logger.LogDebug("开始执行FTP同步");
            logger.LogDebug("连接FTP成功");
            logger.LogWarning("查找数据失败，重试第一次");
            logger.LogWarning("查找数据失败，重试第二次");
            logger.LogError("查找数据最终失败");

          
        }
    }
}
