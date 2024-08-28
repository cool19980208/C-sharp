using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程切换1
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            Console.WriteLine("线程1："+Thread.CurrentThread.ManagedThreadId);//获取线程ID
            /* StringBuilder txt = new StringBuilder();
             for (int i = 0; i < 100000; i++)
             {
                 txt.Append("aaaaaa");
             }*/
            string str = new string('a', 10000);//10000次
            await File.WriteAllTextAsync("D:/.NET Core Test/1.txt", str);
            Console.WriteLine("线程2：" + Thread.CurrentThread.ManagedThreadId);//获取线程ID
            await File.WriteAllTextAsync("D:/.NET Core Test/2.txt", str);
            Console.WriteLine("线程3：" + Thread.CurrentThread.ManagedThreadId);//获取线程ID
        }
    }
}
