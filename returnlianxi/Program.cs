using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace returnlianxi
{
    class Program
    {
        static void Main(string[] args)
        {
           var alias = WholsWho("Cool1");
            Console.WriteLine(alias);
        }

        static string WholsWho(string alias)
        {
            if (alias =="Cool")
            {
                return "Tim";
            }
            else
            {
                return "I do not know";
            }
        }
        static void Greeting(string name)
        {
            if (string.IsNullOrEmpty(name))//判断字符串是否为空
            {
                return;//尽早return原则  避免头重脚轻
            }
            Console.WriteLine("Hello,{0}!",name);
        }
    }
}
