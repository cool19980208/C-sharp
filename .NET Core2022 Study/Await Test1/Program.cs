using System;
using System.IO;
using System.Threading.Tasks;

namespace Await_Test1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string filename = @"D:\.NET Core Test\1.txt";//创建txt文本
            string text = new string('a', 100000);
            await File.WriteAllTextAsync(filename, text);//写入text
            string s = await File.ReadAllTextAsync(filename);//阅读文本
            Console.WriteLine(s);//打印

        }
    }
}
