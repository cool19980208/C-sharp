using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ioc1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<ITestService, TestServiceImpl>();//ITestService==服务 ；TestServiceImpl==注册
            services.AddScoped<ITestService, TestServiceImp2>();
            //services.AddScoped(typeof (ITestService), typeof (TestServiceImpl));
            //services.AddSingleton<ITestService, TestServiceImpl>();
            //services.AddSingleton(typeof(ITestService), new TestServiceImpl());
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                //GetService如果找不到服务，就返回null
                ITestService ts1 = sp.GetService<ITestService>();
                //ITestService ts1 = (ITestService)sp.GetService(typeof(ITestService));//非泛型
                //Required:必须的。如果找不到，直接抛异常
                //类似于显示类型转换和as
                ITestService ts2 = sp.GetRequiredService<ITestService>();
                ts1.Name = "zane";
                ts1.SayHi();
                Console.WriteLine(ts1.GetType());

                IEnumerable<ITestService> tests = sp.GetServices<ITestService>();
                foreach (ITestService t in tests)
                {
                    Console.WriteLine(t.GetType());
                }
            }
            Console.ReadLine();
        }
        static void Main1(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            //services.AddTransient<TestServiceImpl>();//瞬态服务
            //services.AddSingleton<TestServiceImpl>();//单例服务
            services.AddScoped<TestServiceImpl>();//范围服务
            using (ServiceProvider sp =services.BuildServiceProvider())//ServiceProvider == 服务定位器
            {
                /*
                TestServiceImpl testService = sp.GetService<TestServiceImpl>();//GetRequiredService
                testService.Name = "Tom";
                testService.SayHi();

                TestServiceImpl testService1 = sp.GetService<TestServiceImpl>();
                Console.WriteLine(object.ReferenceEquals(testService, testService1));//ReferenceEquals 比较两者是否为同一对象
                testService.Name = "Zane";
                testService1.SayHi();

                testService.SayHi();*/

                TestServiceImpl ttl;//仅作为测试比较两者，不要用于正式环境
                using (IServiceScope scope1 = sp.CreateScope())
                {
                    //在scope中获取Scope相关的对象，要用scope1.ServiceProvider 而不是sp
                    TestServiceImpl testService = scope1.ServiceProvider.GetService<TestServiceImpl>();
                    testService.Name = "Tom";
                    testService.SayHi();

                    TestServiceImpl testService1 = scope1.ServiceProvider.GetService<TestServiceImpl>();
                    //ReferenceEquals 比较两者是否为同一对象
                    Console.WriteLine(object.ReferenceEquals(testService, testService1));
                    ttl = testService;
                }
               
                using (IServiceScope scope2 = sp.CreateScope())
                {

                    TestServiceImpl testService = scope2.ServiceProvider.GetService<TestServiceImpl>();
                    testService.Name = "Zane";
                    testService.SayHi();

                    TestServiceImpl testService1 = scope2.ServiceProvider.GetService<TestServiceImpl>();
                    Console.WriteLine(object.ReferenceEquals(testService, testService1));
                    Console.WriteLine(object.ReferenceEquals(testService, ttl));
                }

            }

            
        }
    }

}
