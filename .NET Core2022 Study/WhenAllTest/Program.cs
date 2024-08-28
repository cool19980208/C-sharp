using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WhenAllTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
           /* Task<string> t1 = File.ReadAllTextAsync(@"D:\.NET Core Test\1.txt");
            Task<string> t2 = File.ReadAllTextAsync(@"D:\.NET Core Test\2.txt");
            Task<string> t3 = File.ReadAllTextAsync(@"D:\.NET Core Test\3.txt");
            string[] results = await Task.WhenAll(t1, t2, t3);
            string s1 = results[0];
            string s2 = results[1];
            string s3 = results[2];
            Console.WriteLine(s1+s2+s3);*/

            string[] files = Directory.GetFiles(@"D:\.NET Core Test");
            Task<int>[] countTasks = new Task<int>[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                string filename = files[i];
                Task<int> t = ReadCharsCount(filename);
                countTasks[i] = t;
            }
            int[] counts = await Task.WhenAll(countTasks);
            int c = counts.Sum();//计算数组的和
            Console.WriteLine(c);
        }
        static async Task<int> ReadCharsCount(string filename)
        {
            string s = await File.ReadAllTextAsync(filename);
            return s.Length;
        }
    }
}
