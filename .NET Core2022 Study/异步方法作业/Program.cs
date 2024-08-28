using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace 异步方法作业
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string url = "https://www.baiu.com/"; // 这里替换成你想要下载的URL
            try
            {
                var content =  await DownloadAsync(url);
                Console.WriteLine("下载成功:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"下载失败: {ex.Message}");
            }

        }

        public static async Task<string> DownloadAsync(string url)
        {
            using(HttpClient httpClient =new HttpClient())
            {
                int retryCount = 0;
                while(retryCount<4)//3次重试
                {
                    try
                    {
                        string s = await httpClient.GetStringAsync(url);//获取网址信息
                        return s;
                    }
                    catch (HttpRequestException)//抓取异常
                    {
                        retryCount++;
                        if (retryCount >= 4)
                        {
                            throw new Exception("下载失败");
                        }

                        Console.WriteLine($"尝试下载失败，‌正在重试...({retryCount}/3)");
                        await Task.Delay(500); // 等待500ms
                    }
                }
                throw new Exception("下载失败");
            }
        }

    }
   
}
