using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace asyncAwait原理1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string html = await httpClient.GetStringAsync("https://www.baidu.com");
                Console.WriteLine(html);
            }
            string txt = "hello cool";
            string filename = @"D:\.NET Core Test\1.txt";
            await File.WriteAllTextAsync(filename, txt);
            Console.WriteLine("写入成功");
            string s = await File.ReadAllTextAsync(filename);
            Console.WriteLine("文件内容"+s);
        }
    }
}
