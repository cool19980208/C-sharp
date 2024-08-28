using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace 接口的异步方法
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await foreach(var s in Test2())
            {
                Console.WriteLine(s);
            }
            
        }
        /*static IEnumerable<string> Test()
        {
            List<string> list = new List<string>();
            list.Add("hello");
            list.Add("cool");
            list.Add("youzack");
            return list;//这是上述代码都执行完成后再一起返回。
        }
        static IEnumerable<string> Test1()
        {
            yield return "hello";//这种是执行完后，就返回一次
            yield return "cool";
            yield return "youzack";
        }*/
        static async IAsyncEnumerable<string> Test2()
        {
            yield return "hello";
            yield return "yzk";
            yield return "youzack";
        }
    }

    interface ITest
    {
        Task<int> GetCharCount(string file);
    }
    class Test : ITest
    {
        public async Task<int> GetCharCount(string file)
        {
            string s = await File.ReadAllTextAsync(file);
            return s.Length;
        }
    }
}
