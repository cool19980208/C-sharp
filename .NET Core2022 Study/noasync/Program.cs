using System;
using System.IO;
using System.Threading.Tasks;

namespace noasync
{
    class Program
    {
        static void Main(string[] args)
        {
           //string s=  File.ReadAllTextAsync(@"D:\.NET Core Test\1.txt").Result;
            // Task t = File.ReadAllTextAsync(@"D:\.NET Core Test\1.txt");
            // string s = t.Result;

             File.WriteAllTextAsync(@"D:\.NET Core Test\1.txt","aaaaaaaaa").Wait();
        }
    }
}
