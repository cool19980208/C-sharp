using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using SystemServices;

namespace Logging视频中的例子
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();//DI注入


            services.AddLogging(logBuilder =>
            {
                //logBuilder.AddConsole();
                logBuilder.AddNLog();
                //logBuilder.SetMinimumLevel(LogLevel.Trace); //最低级别设置          
            });
            services.AddScoped<Text1>();
            services.AddScoped<Test2>();


            using (var sp = services.BuildServiceProvider())//DI注入
            {
                var text1 = sp.GetRequiredService<Text1>();
                var text2 = sp.GetRequiredService<Test2>();

                for (int i = 0; i < 10000; i++)
                {
                    text1.Test();
                    text2.Test();
                }
            }
        }
    }
}
