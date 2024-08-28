using System;
using System.Threading;
using System.Threading.Tasks;

namespace 异步方法不等于多线程
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1-Main: "+ Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(await Calc2Async(1000));
            Console.WriteLine("2-Main: " + Thread.CurrentThread.ManagedThreadId);
        }
        public static async Task<double> CalcAsync(int n)
        {
            /*Console.WriteLine("CalcAsync: " + Thread.CurrentThread.ManagedThreadId);
            double result = 0;
            Random rand = new Random();
            for (var i = 0; i < n*n; i++)
            {
                result = result + (double)rand.NextDouble();
            }
            return result;*/
            return await Task.Run(() => //Task.Run 新线程
            {
                Console.WriteLine("CalcAsync: " + Thread.CurrentThread.ManagedThreadId);
                double result = 0;
                Random rand = new Random();
                for (var i = 0; i < n * n; i++)
                {
                    result = result + (double)rand.NextDouble();
                }
                return result;
            });
        }
        public static  Task<double> Calc2Async(int n)//改成不用async的方法
        {
            return  Task.Run(() => //Task.Run 新线程
            {
                Console.WriteLine("CalcAsync: " + Thread.CurrentThread.ManagedThreadId);
                double result = 0;
                Random rand = new Random();
                for (var i = 0; i < n * n; i++)
                {
                    result = result + (double)rand.NextDouble();
                }
                return result;
            });
        }
    }
}
