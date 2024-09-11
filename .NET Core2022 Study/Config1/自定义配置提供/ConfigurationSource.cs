using Microsoft.Extensions.Configuration;

namespace 自定义配置提供
{
    //主要是提供参数使用
    public class ConfigurationSource : FileConfigurationSource
    {      
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);//处理Path等默认值问题
            return new ConfigurationProvider(this);
        }
    }
}
