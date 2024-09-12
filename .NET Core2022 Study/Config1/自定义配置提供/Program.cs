using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace 自定义配置提供
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<TestWebConfig>();

            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            //configBuilder.Add(new ConfigurationSource() { Path = "web.config" });
            configBuilder.AddConfig();//上面的简写，写了个扩展方法，方便使用
            IConfigurationRoot configRoot = configBuilder.Build();
            services.AddOptions().Configure<WebConfig>(e => configRoot.Bind(e));//Bind依赖于Microsoft.Extensions.Configuration.Binder

            using (var sp = services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<TestWebConfig>();
                c.Test();
            }
        }
    }

}
