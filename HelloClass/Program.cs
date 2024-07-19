using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib.MyNamespace;

namespace HelloClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            double x = calculator.Add(100.5, 600.8);
            Console.WriteLine(x);
        }

    }

}

