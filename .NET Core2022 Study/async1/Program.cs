using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace async1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int i = await DownloadHtmlAsync("https://www.youzack.com", @"D:\.NET Core Test\1.txt");
            Console.WriteLine("ok" + i);
        }
        /* 不带返回值的
         * static async Task DownloadHtmlAsync(string url,String filename)
         {
             //因为HttpClient里面实现了IDisposable这个接口，所以用using来进行资源的回收
             //HttpClientFactory  一般都是搭配这个使用
             using (HttpClient httpClient=new HttpClient())
             {
                String html = await httpClient.GetStringAsync(url);
                await File.WriteAllTextAsync(filename, html);
             }
         }*/

        //带返回值的
        static async Task<int> DownloadHtmlAsync(string url, String filename)
        {
            //因为HttpClient里面实现了IDisposable这个接口，所以用using来进行资源的回收
            //HttpClientFactory  一般都是搭配这个使用
            using (HttpClient httpClient = new HttpClient())
            {
                String html = await httpClient.GetStringAsync(url);
                await File.WriteAllTextAsync(filename, html);
                return html.Length;//返回长度
            }
        }
    }
}
