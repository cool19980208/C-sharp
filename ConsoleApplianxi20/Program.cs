using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplianxi20
{
    class Program
    {
        static void Main(string[] args)
        {
            ////(int a, int b) => { return a + b; } Lambda表达式
            ////分析，带入两个int的值，然后return  int 的值。
            ////Func<int, int, int> func = new Func<int, int, int>((int a, int b) => { return a + b; });

            ////简化1
            ////Func<int, int, int> func = new Func<int, int, int>((a, b) => { return a + b; });

            ////简化2
            //Func<int, int, int> func = (a, b) => { return a + b; };

            //int res = func(100, 200);//100+200 = 300
            //Console.WriteLine(res);
            ////func = new Func<int, int, int>((int x, int y) => { return x * y; });//重用  

            ////简化1 int x, int y 前面的int 可以省略变成(x, y)
            //func = new Func<int, int, int>((int x, int y) => { return x * y; });
            ////简化2 
            //func = (int x, int y) => { return x * y; };
            //res = func(3, 4);//重用
            //Console.WriteLine(res);

            //解析  T都变成int，带入 a=100，b=200，return 20000
            //DoSomeCalc<int>((a, b) => { return a * b; }, 100, 200);

            //简化1  根据后面的100和200可以判断出来是int的数据类型
            DoSomeCalc((a, b) => { return a * b; }, 100, 200);



        }
        static void DoSomeCalc<T>(Func<T, T, T> func, T x, T y)
        {
            T res = func(x, y);
            Console.WriteLine(res);
        }
    }
}
