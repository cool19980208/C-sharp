using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.CommandLine;
using System;

namespace 书本上的例子
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            //configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);读取json
            //configBuilder.AddCommandLine(args);//从命名行读取配置
            configBuilder.AddEnvironmentVariables("TEST_");//从环境变量读取配置  建议有前缀去区分 比如：TEST_
            IConfigurationRoot config = configBuilder.Build();
            ServiceCollection services = new ServiceCollection();
            services.AddOptions()
                .Configure<DbSettings>(e => config.GetSection("DB").Bind(e))
                .Configure<SmtpSettings>(e => config.GetSection("Smtp").Bind(e));
            services.AddTransient<Demo>();
            using (var sp = services.BuildServiceProvider())
            {
                while (true)
                {
                    using (var scope = sp.CreateScope())
                    {
                        var spScope = scope.ServiceProvider;
                        var demo = spScope.GetRequiredService<Demo>();
                        demo.Test();
                    }
                    Console.WriteLine("可以改配置啦");
                    Console.ReadKey();
                }
            }
        }
    }
}
