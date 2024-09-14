using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace LoggingDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection(); //DI注入
            //services.AddScoped<>();
            services.AddLogging(logBuilder =>
            {
                logBuilder.AddConsole(); //可多个Provider
            });

            using (var sp = services.BuildServiceProvider()) //DI注入
            {
                var logger = sp.GetRequiredService<ILogger<Program>>();
                logger.LogWarning("这是一条警告信息");
                logger.LogError("这是一条错误消息");
                string age = "abc";
                logger.LogInformation("用户输入的年龄：{0}", age);
                try
                {
                    int i = int.Parse(age);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "解析字符串为int失败");
                }
            }
        }
    }
}
