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
            configBuilder.Add(new ConfigurationSource() { Path = "web.config" });
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
