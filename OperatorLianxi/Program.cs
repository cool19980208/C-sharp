using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorLianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 7;
            int y = 28;
            int z = x & y;
            string strX = Convert.ToString(x, 2).PadLeft(32, '0');
            string strY = Convert.ToString(y, 2).PadLeft(32, '0');
            string strZ = Convert.ToString(z, 2).PadLeft(32, '0');
            Console.WriteLine(strX);
            Console.WriteLine(strY);
            Console.WriteLine(strZ);
        }
    } //Ctrl+}  可以在上下{}来回跳转
}
