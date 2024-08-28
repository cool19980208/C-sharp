using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace 没有async的异步方法2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string s = await ReadFileAsync(2);
            Console.WriteLine(s);
        }
        static async Task<string> ReadFileAsync(int num)//普通异步方法
       {
           if (num==1)
           {
                string s =await File.ReadAllTextAsync(@"D:\.NET Core Test\1.txt");
                return s+"cool";//把获取异步方法的返回值后再进一步的处理，比如后面+字符串cool，或者其他逻辑
            }
           else if(num==2)
           {
                string s = await File.ReadAllTextAsync(@"D:\.NET Core Test\2.txt");
                return s+"cool";
            }
           else
           {
               throw new ArgumentException("num invalid");
           }
       }
        /*static  Task<string> ReadFileAsync(int num)//未用async修饰的异步方法
        {
            if (num == 1)
            {
                return  File.ReadAllTextAsync(@"D:\.NET Core Test\1.txt");//返回值就是Task<string>类型，所以直接return
            }
            else if (num == 2)
            {
                return  File.ReadAllTextAsync(@"D:\.NET Core Test\2.txt");
            }
            else
            {
                throw new ArgumentException("num invalid");
            }
        }*/
    }
}
