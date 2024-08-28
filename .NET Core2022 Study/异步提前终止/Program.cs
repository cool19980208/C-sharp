using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace 异步提前终止
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000);//5S 没有请求完，就取消
            CancellationToken cToken = cts.Token;//取出token
           await DownloadAsync("https://www.baidu.com", 1000, cToken);
            while(Console.ReadLine()!="q")//用户敲按键实现
            {

            }
            cts.Cancel();
            Console.ReadLine();
        }
        static async Task Main1(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000);//5S 没有请求完，就取消
            CancellationToken cToken = cts.Token;//取出token
            await DownloadAsync("https://www.baidu.com", 1000, cToken);
        }
        static async Task DownloadAsync(string url,int n,CancellationToken cancellationToken)//第一种写法  
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    string html = await httpClient.GetStringAsync(url);//这边请求耗时1分钟，遇到取消异常返回，在由判断去手动处理
                    Console.WriteLine($"{DateTime.Now}:{html}");
                    if (cancellationToken.IsCancellationRequested)//建议用这个
                    {
                        Console.WriteLine("请求被取消");
                        break;
                    }

                }
            }
        }
        static async Task Download2Async(string url, int n, CancellationToken cancellationToken)//第二种写法
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    string html = await httpClient.GetStringAsync(url);
                    Console.WriteLine($"{DateTime.Now}:{html}");
                    /*if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("请求被取消");
                        break;
                    }*/
                    cancellationToken.ThrowIfCancellationRequested();//发现请求取消了，就把异常抛出去

                }
            }
        }
        static async Task Download3Async(string url, int n, CancellationToken cancellationToken)//第三种写法
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    //GetAsync的实现，微软内置的。有可能请求还没到1分钟，就被请求取消5s自动处理了.这个可以在后续在手动处理
                    //缺点：不能自己控制cancellationToken响应的处理
                    var resp = await httpClient.GetAsync(url, cancellationToken);
                    string html = await resp.Content.ReadAsStringAsync();
                    Console.WriteLine($"{DateTime.Now}:{html}");
                    if (cancellationToken.IsCancellationRequested)//后续加的手动处理， 微软自动+手动 
                    {
                        Console.WriteLine("请求被取消");
                        break;
                    }

                }
            }
        }
    }
}
