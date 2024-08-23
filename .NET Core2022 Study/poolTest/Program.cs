using System;
using System.IO;
using System.Threading;

namespace poolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(async(obj) =>
            {

                while (true)
                {
                   await File.WriteAllTextAsync(@"D:\.NET Core Test\1.txt", "aaaaaaaaa");
                }
            });
            Console.Read();
        }
    }
}
