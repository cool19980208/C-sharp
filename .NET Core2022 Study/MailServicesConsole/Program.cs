using System;
using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;
namespace MailServicesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            //通过配置文件来读取
            services.AddIniFileConfig("mail.ini");
            //services.AddScoped(typeof(IConfigService), s => new IniFileConfigService { FilePath = "mail.ini" });
            //services.AddScoped<IConfigService, ConfigService>();
            services.AddConsoleLog();//提供一个AddXX方法，能够自动提示出来
            //services.AddScoped<ILogService, LogService>();
            services.AddMail();
            //services.AddScoped<IMailService, MailService>();
            using(var sp=services.BuildServiceProvider())
            {
                //第一个根对象只能用ServiceLocator
                var mailService = sp.GetRequiredService<IMailService>();
                mailService.Send("Hello", "888888@qq.com", "你好");
            }
            Console.Read();
        }
    }
}
