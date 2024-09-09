using Microsoft.Extensions.DependencyInjection;
using System;

namespace DI依赖注入1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<Controller>();
            services.AddScoped<ILog,LogImpl>();
            services.AddScoped<IStorage,StorageImpl>();
            //services.AddScoped<IConfig,ConfigImpl>();//注册服务
            services.AddScoped<IConfig,DBConfigImpl>();
            //所有用到的服务都写到services.BuildServiceProvider()之前
            using (var sp =services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<Controller>();
                c.Test();
            }
            Console.ReadKey();
        }
    }
    class Controller
    {
        private readonly ILog log;
        private readonly IStorage storage;
        public Controller(ILog log, IStorage storage)
        {
            this.log = log;
            this.storage = storage;
        }
        public void Test()
        {
            this.log.Log("开始上传");
            this.storage.Sava("asdasdas", "1.txt");
            this.log.Log("上传完毕");
        }
    }
    interface ILog
    {
        public void Log(string msg);
    }
    class LogImpl : ILog
    {
        public void Log(string msg)
        {
            Console.WriteLine($"日志：{msg}");
        }
    }
    interface IConfig
    {
        public string GetValue(string name);
    }
    class ConfigImpl : IConfig
    {
        public string GetValue(string name)
        {
            return "Hello";
        }
    }
    
    class DBConfigImpl : IConfig
    {
        public string GetValue(string name)
        {
            Console.WriteLine("从数据库中读取");
            return "Hello db";
        }
    }
    interface IStorage
    {
        public void Sava(string content, string name);
    }
    class StorageImpl : IStorage
    {
        //DI:降低模块之间的耦合
        private readonly IConfig config;//取配置文件中的数据
        public StorageImpl(IConfig config)//注入：IConfig config |  StorageImpl==构造函数
        {
            this.config = config;
        }
        public void Sava(string content, string name)
        {
            string server = config.GetValue("server");//去配置文件夹中的服务器
            Console.WriteLine($"向{server}服务器上传文件名为{name}，文件内容为：{content}");
        }
    }


}
