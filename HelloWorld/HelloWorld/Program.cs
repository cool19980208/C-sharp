using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld//这是名称空间
{
    class Program//class 后面的是类
    {
        static void Main(string[] args)
        {
            double result = Tools.Calcultor.Sub(10, 10);
            Console.WriteLine(result);
        }
    }
}
