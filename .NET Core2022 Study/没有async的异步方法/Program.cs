using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace 没有async的异步方法
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string s = await ReadFileAsync(2);
            Console.WriteLine(s);
        }
        /*static async Task<string> ReadFileAsync(int num)//普通异步方法
        {
            switch(num)
            {
                case 1:
                    return await File.ReadAllTextAsync(@"D:\.NET Core Test\1.txt");//如果是1，就读取1.txt
                case 2:
                    return await File.ReadAllTextAsync(@"D:\.NET Core Test\2.txt");//如果是2，就读取2.txt
                default:
                    throw new ArgumentException("num invalid");
            }
        }*/
       
        static  Task<string> ReadFileAsync(int num)//未用async修饰的异步方法
        {
            switch (num)
            {
                case 1:
                    return  File.ReadAllTextAsync(@"D:\.NET Core Test\1.txt");//如果是1，就读取1.txt
                case 2:
                    return  File.ReadAllTextAsync(@"D:\.NET Core Test\2.txt");//如果是2，就读取2.txt
                default:
                    throw new ArgumentException("num invalid");
            }
        }
    }
}
