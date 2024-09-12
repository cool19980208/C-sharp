using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging视频中的例子
{
    class Text1
    {
        private readonly ILogger<Text1> logger;
        public Text1(ILogger<Text1> logger)
        {
            this.logger = logger;
        }
        public void Test()
        {
            logger.LogDebug("开始执行数据库同步");
            logger.LogDebug("连接数据库成功");
            logger.LogWarning("查找数据失败，重试第一次");
            logger.LogWarning("查找数据失败，重试第二次");
            logger.LogError("查找数据最终失败");

            try
            {
                File.ReadAllText("A:1.txt");
                logger.LogDebug("读取文件成功");
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "读取文件失败");
            }
        }
    }
}
