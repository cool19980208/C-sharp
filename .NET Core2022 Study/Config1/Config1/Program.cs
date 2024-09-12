using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Config1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<TestController>();
            services.AddScoped<demo>();

            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            //configBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: true);
            //TrustServerCertificate = True 忽略 SSL 证书的验证，只能在测试环境使用
            //数据库连接
            string conn1 = "Server=.;Database=School;Trusted_Connection=True;TrustServerCertificate=True"; 
            configBuilder.AddDbConfiguration(() => new SqlConnection(conn1), reloadOnChange: true,
                reloadInterval: TimeSpan.FromSeconds(2));

            IConfigurationRoot configRoot = configBuilder.Build();          

            //下面这个很重要
            services.AddOptions()
                .Configure<Config>(e => configRoot.Bind(e))
                .Configure<Proxy>(e => configRoot.GetSection("proxy").Bind(e));
            using (var sp = services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<TestController>();
                c.Test();
                /*while (true)
                {
                    using (var scope = sp.CreateScope())
                    {
                        var spScope = scope.ServiceProvider.GetRequiredService<TestController>();
                        spScope.Test();
                        var demo = scope.ServiceProvider.GetRequiredService<demo>();
                        demo.Test();
                    }
                    Console.WriteLine("可以改配置啦");
                    Console.ReadKey();
                }*/
            }

        }
        //static void Main(string[] args)
        // {
        //     ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        //     //optional参数表示这个文件是否可选。初学者，建议optional设置为false，这样写错了的话能够即使发现
        //     //reloadOnChange参数表示如果文件修改了，是否重新加载配置。
        //     configBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: false);
        //     IConfigurationRoot configRoot = configBuilder.Build();
        //     /*
        //     string name = configRoot["name"];
        //     Console.WriteLine($"name={name}");
        //     string add = configRoot.GetSection("proxy:address").Value;
        //     Console.WriteLine($"addr={add}");*/

        //     Config config = configRoot.Get<Config>();
        //     Console.WriteLine(config.Name);
        //     Console.WriteLine(config.Proxy.Port);

        //     Console.ReadKey();
        // } 
    }
    class Config
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Proxy Proxy { get; set; }
    }
    class Proxy
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }

}
